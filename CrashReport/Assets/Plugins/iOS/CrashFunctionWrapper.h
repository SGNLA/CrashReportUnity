//
//  CrashFunctionWrapper.h
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

#import <Foundation/Foundation.h>
// #import "<ModuleName>-Swift.h"

@interface CrashFunctionWrapper : NSObject

+ (void)crashNULL;
+ (void)crashGarbage;
+ (void)crashROPage;
+ (void)crashNXPage;
+ (void)crashUndefInst;
+ (void)crashPrivInst;
+ (void)crashAbort;
+ (void)crashTrap;
+ (void)crashObjCException;
+ (void)crashReleasedObject;
+ (void)crashObjCMsgSend;
+ (void)crashCorruptMalloc;
+ (void)crashSmashStackTop;
+ (void)crashSmashStackBottom;
+ (void)crashCorruptObjC;
+ (void)crashNSLog;
+ (void)crashAsyncSafeThread;
+ (void)crashOverwriteLinkRegister;
+ (void)crashStackGuard;
+ (void)crashFramelessDWARF;
+ (void)crashSwift;

@end
