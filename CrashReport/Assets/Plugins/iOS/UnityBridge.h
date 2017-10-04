//
//  UnityBridge.h
//  CrashProbeFramework
//
//  Created by Kevin Liu on 9/18/17.
//  Copyright © 2017 jamcity. All rights reserved.
//

#import "CrashFunctionWrapper.h"
#import "CrashFunctionCXXWrapper.h"

#ifdef __cplusplus
extern "C" {
#endif
    
    void crashNULL();
    void crashGarbage();
    void crashROPage();
    void crashNXPage();
    void crashUndefInst();
    void crashPrivInst();
    void crashAbort();
    void crashTrap();
    void crashObjCException();
    void crashCXXException();
    void crashReleasedObject();
    void crashObjCMsgSend();
    void crashCorruptMalloc();
    void crashSmashStackTop();
    void crashSmashStackBottom();
    void crashCorruptObjC();
    void crashNSLog();
    void crashAsyncSafeThread();
    void crashOverwriteLinkRegister();
    void crashStackGuard();
    void crashFramelessDWARF();
    void crashSwift();
    
#ifdef __cplusplus
}
#endif
