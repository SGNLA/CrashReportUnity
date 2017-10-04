//
//  CrashFunctionSwiftWrapper.swift
//  Unity-iPhone
//
//  Created by Kevin Liu on 9/29/17.
//
//

import Foundation

@objc class CrashFunctionSwiftWrapper : NSObject {
    func crashSwift(){
        let buf: UnsafeMutablePointer<UInt>? = nil;
        
        buf![1] = 1;
    }
}

