//
//  UnityBridge.m
//  CrashProbeFramework
//
//  Created by Kevin Liu on 9/18/17.
//  Copyright © 2017 jamcity. All rights reserved.
//

#import "UnityBridge.h"

void crashNULL() {
    [CrashFunctionWrapper crashNULL];
}

void crashGarbage() {
    [CrashFunctionWrapper crashGarbage];
}

void crashROPage() {
    [CrashFunctionWrapper crashROPage];
}

void crashNXPage() {
    [CrashFunctionWrapper crashNXPage];
}

void crashUndefInst() {
    [CrashFunctionWrapper crashUndefInst];
}

void crashPrivInst() {
    [CrashFunctionWrapper crashPrivInst];
}

void crashAbort() {
    [CrashFunctionWrapper crashAbort];
}

void crashTrap() {
    [CrashFunctionWrapper crashTrap];
}

void crashObjCException() {
    [CrashFunctionWrapper crashObjCException];
}

void crashCXXException() {
    [CrashFunctionCXXWrapper crashCXXException];
}

void crashReleasedObject() {
    [CrashFunctionWrapper crashReleasedObject];
}

void crashObjCMsgSend() {
    [CrashFunctionWrapper crashObjCMsgSend];
}

void crashCorruptMalloc() {
    [CrashFunctionWrapper crashCorruptMalloc];
}

void crashSmashStackTop() {
    [CrashFunctionWrapper crashSmashStackTop];
}

void crashSmashStackBottom() {
    [CrashFunctionWrapper crashSmashStackBottom];
}

void crashCorruptObjC() {
    [CrashFunctionWrapper crashCorruptObjC];
}

void crashNSLog() {
    [CrashFunctionWrapper crashNSLog];
}

void crashAsyncSafeThread() {
    [CrashFunctionWrapper crashAsyncSafeThread];
}

void crashOverwriteLinkRegister() {
    [CrashFunctionWrapper crashOverwriteLinkRegister];
}

void crashStackGuard() {
    [CrashFunctionWrapper crashStackGuard];
}

void crashFramelessDWARF() {
    [CrashFunctionWrapper crashFramelessDWARF];
}

void crashSwift() {
    [CrashFunctionWrapper crashSwift];
}
