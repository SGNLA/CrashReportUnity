//
//  CrashFunctionWrapper.m
//  CrashProbeFramework
//
//  Created by Kevin Liu on 9/26/17.
//  Copyright © 2017 jamcity. All rights reserved.
//

/*
 * Copyright (c) 2014 HockeyApp, Bit Stadium GmbH.
 * All rights reserved.
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 */

#import "CrashFunctionWrapper.h"

#import <sys/mman.h>
#import <malloc/malloc.h>
#import <mach/mach.h>
#import <pthread.h>

/* Our assembly implemented test function */
extern void CRLFramelessDWARF_test();

/* Called by the assembly code paths to trigger the actual NULL dereference */
extern void CRLFramelessDWARF_test_crash (void);
void CRLFramelessDWARF_test_crash (void) {
    *((volatile uint8_t *) NULL) = 0xFF;
}

@implementation CrashFunctionWrapper

+ (void)crashNULL {
    volatile char *ptr = NULL;
    (void)*ptr;
}

+ (void)crashGarbage {
    void *ptr = mmap(NULL, (size_t)getpagesize(), PROT_NONE, MAP_ANON | MAP_PRIVATE, -1, 0);
    
    if (ptr != MAP_FAILED)
        munmap(ptr, (size_t)getpagesize());
    
#if __i386__
    asm volatile ( "mov %0, %%eax\n\tmov (%%eax), %%eax" : : "X" (ptr) : "memory", "eax" );
#elif __x86_64__
    asm volatile ( "mov %0, %%rax\n\tmov (%%rax), %%rax" : : "X" (ptr) : "memory", "rax" );
#elif __arm__ && __ARM_ARCH == 7
    asm volatile ( "mov r4, %0\n\tldr r4, [r4]" : : "X" (ptr) : "memory", "r4" );
#elif __arm__ && __ARM_ARCH == 6
    asm volatile ( "mov r4, %0\n\tldr r4, [r4]" : : "X" (ptr) : "memory", "r4" );
#elif __arm64__
    asm volatile ( "mov x4, %0\n\tldr x4, [x4]" : : "X" (ptr) : "memory", "x4" );
#endif
}

static void __attribute__((used)) dummyfunc(void)
{
}

+ (void)crashROPage {
    volatile char *ptr = (char *)dummyfunc;
    *ptr = 0;
}

static void __attribute__((noinline)) real_NXcrash(void)
{
    void *ptr = mmap(NULL, (size_t)getpagesize(), PROT_READ | PROT_WRITE, MAP_ANON | MAP_PRIVATE, -1, 0);
    
    if (ptr != MAP_FAILED) {
        ((void (*)(void))ptr)();
    }
    
    munmap(ptr, (size_t)getpagesize());
}

+ (void)crashNXPage {
    real_NXcrash();
}

+ (void)crashUndefInst {
#if __i386__
    asm volatile ( "ud2" : : : );
#elif __x86_64__
    asm volatile ( "ud2" : : : );
#elif __arm__ && __ARM_ARCH == 7 && __thumb__
    asm volatile ( ".word 0xde00" : : : );
#elif __arm__ && __ARM_ARCH == 7
    asm volatile ( ".long 0xf7f8a000" : : : );
#elif __arm__ && __ARM_ARCH == 6 && __thumb__
    asm volatile ( ".word 0xde00" : : : );
#elif __arm__ && __ARM_ARCH == 6
    asm volatile ( ".long 0xf7f8a000" : : : );
#elif __arm64__
    asm volatile ( ".long 0xf7f8a000" : : : );
#endif
}

+ (void)crashPrivInst {
#if __i386__
    asm volatile ( "hlt" : : : );
#elif __x86_64__
    asm volatile ( "hlt" : : : );
#elif __arm__ && __ARM_ARCH == 7 && __thumb__
    asm volatile ( ".long 0xf7f08000" : : : );
#elif __arm__ && __ARM_ARCH == 7
    asm volatile ( ".long 0xe1400070" : : : );
#elif __arm__ && __ARM_ARCH == 6 && __thumb__
    asm volatile ( ".long 0xf5ff8f00" : : : );
#elif __arm__ && __ARM_ARCH == 6
    asm volatile ( ".long 0xe14ff000" : : : );
#elif __arm64__
    // Invalidate all EL1&0 regime stage 1 and 2 TLB entries. This should
    // not be possible from userspace, for hopefully obvious reasons :-)
    asm volatile ( "tlbi alle1" : : : );
#endif
}

+ (void)crashAbort {
    abort();
}

+ (void)crashTrap {
    __builtin_trap();
}

+ (void)crashObjCException {
    @throw [NSException exceptionWithName:NSGenericException reason:@"An uncaught exception! SCREAM."
                                 userInfo:@{ NSLocalizedDescriptionKey: @"I'm in your program, catching your exceptions!" }];
}

+ (void)crashReleasedObject {
#if __i386__ && !TARGET_IPHONE_SIMULATOR
    NSObject *object = [[NSObject alloc] init];
#else
    NSObject * __unsafe_unretained object = (__bridge NSObject *)CFBridgingRetain([[NSObject alloc] init]);
#endif
    
#if __i386__ && !TARGET_IPHONE_SIMULATOR
    [object release];
#else
    CFRelease((__bridge CFTypeRef)object);
#endif
    ^ __attribute__((noreturn)) {
        for (;;) {
            [object self];
            [object description];
            [object debugDescription];
        }
    }();
}

+ (void)crashObjCMsgSend {
    struct {
        void *isa;
    } corruptObj = {
        .isa = (void *) 42
    };
    
#if __i386__ && !TARGET_IPHONE_SIMULATOR
#define __bridge
#endif
    [(__bridge id)&corruptObj stringWithFormat:
     @"%u, %u, %u, %u, %u, %u, %f, %f, %c, %c, %s, %s, %@, %@"
     " %u, %u, %u, %u, %u, %u, %f, %f, %c, %c, %s, %s, %@, %@",
     0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 9.0, 10.0, 'a', 'b', "C", "D", @"E", @"F",
     0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 9.0, 10.0, 'a', 'b', "C", "D", @"E", @"F"];
}

+ (void)crashCorruptMalloc {
    /* Smash the heap, and keep smashing it until we eventually hit something non-writable, or trigger
    * a malloc error (e.g., in NSLog). */
    uint8_t *memory = malloc(10);
    while (true) {
        NSLog(@"Smashing [%p - %p]", memory, memory + PAGE_SIZE);
        memset((void *) trunc_page((vm_address_t)memory), 0xAB, PAGE_SIZE);
        memory += PAGE_SIZE;
    }
}

+ (void)crashSmashStackTop {
    void *sp = NULL;
    
#if __i386__
    asm volatile ( "mov %%esp, %0" : "=X" (sp) : : );
#elif __x86_64__
    asm volatile ( "mov %%rsp, %0" : "=X" (sp) : : );
#elif __arm__ && __ARM_ARCH == 7
    asm volatile ( "mov %0, sp" : "=X" (sp) : : );
#elif __arm__ && __ARM_ARCH == 6
    asm volatile ( "mov %0, sp" : "=X" (sp) : : );
#elif __arm64__
    asm volatile ( "mov %0, sp" : "=X" (sp) : : );
#endif
    
    memset(sp - 0x100, 0xa5, 0x100);
}

+ (void)crashSmashStackBottom {
    void *sp = NULL;
    
#if __i386__
    asm volatile ( "mov %%esp, %0" : "=X" (sp) : : );
#elif __x86_64__
    asm volatile ( "mov %%rsp, %0" : "=X" (sp) : : );
#elif __arm__ && __ARM_ARCH == 7
    asm volatile ( "mov %0, sp" : "=X" (sp) : : );
#elif __arm__ && __ARM_ARCH == 6
    asm volatile ( "mov %0, sp" : "=X" (sp) : : );
#elif __arm64__
    asm volatile ( "mov %0, sp" : "=X" (sp) : : );
#endif
    
    memset(sp, 0xa5, 0x100);
}

+ (void)crashCorruptObjC {
    Class objClass = [NSObject class];
    
    // VERY VERY PRIVATE INTERNAL RUNTIME DETAILS VERY VERY EVIL THIS IS BAD!!!
    struct objc_cache_t {
        uintptr_t mask;            /* total = mask + 1 */
        uintptr_t occupied;
        void *buckets[1];
    };
    struct objc_class_t {
        struct objc_class_t *isa;
        struct objc_class_t *superclass;
        struct objc_cache_t cache;
        IMP *vtable;
        uintptr_t data_NEVER_USE;  // class_rw_t * plus custom rr/alloc flags
    };
    
#if __i386__ && !TARGET_IPHONE_SIMULATOR
#define __bridge
#endif
    
    struct objc_class_t *objClassInternal = (__bridge struct objc_class_t *)objClass;
    
    // Trashes NSObject's method cache
    memset(&objClassInternal->cache, 0xa5, sizeof(struct objc_cache_t));
    
    [self description];
}

+ (void)crashNSLog {
#if __i386__ && !TARGET_IPHONE_SIMULATOR
#define __bridge
#endif
    
    NSLog(@"%@", (__bridge id)(void *)16);
}

+ (void)crashAsyncSafeThread {
    pthread_getname_np(pthread_self(), ((char *) 0x1), 1);
    
    /* This is unreachable, but prevents clang from applying TCO to the above when
     * optimization is enabled. */
    NSLog(@"I'm here from the tail call prevention department.");
}

+ (void)crashOverwriteLinkRegister {
    /* Call a method to trigger modification of LR. We use the result below to
     * convince the compiler to order this function the way we want it. */
    uintptr_t ptr = (uintptr_t) [NSObject class];
    
    /* Make-work code that simply advances the PC to better demonstrate the discrepency. We use the
     * 'ptr' value here to make sure the compiler doesn't optimize-away this code, or re-order it below
     * the method call. */
    ptr += ptr;
    ptr -= 42;
    ptr += ptr % (ptr - 42);
    
    /* Crash within the method (using a write to the NULL page); the link register will be pointing at
     * the make-work code. We use the 'ptr' value to control compiler ordering. */
    *((uintptr_t volatile *)NULL) = ptr;
}

+ (void)crashStackGuard {
    [CrashFunctionWrapper crashStackGuard];
    
    /* This is unreachable, but prevents clang from applying TCO to the above when
     * optimization is enabled. */
    NSLog(@"I'm here from the tail call prevention department.");
}

+ (void)crashFramelessDWARF {
    CRLFramelessDWARF_test();
}

+ (void)crashSwift {
    [[[CrashFunctionSwiftWrapper alloc] init] crashSwift];
}

@end
