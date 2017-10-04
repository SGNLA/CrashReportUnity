using System.Collections.Generic;

public class ObjectiveCCrashFactory {
	static public void generateAllCrashCasesInto(Dictionary<string, List<Crash> > dictionary) {
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"Async-Safety",
			"Crash with _pthread_list_lock held",
			"Triggers a crash with libsystem_pthread's _pthread_list_lock held, causing non-async-safe crash reporters that use pthread APIs to deadlock.",
			ObjectiveCBridge.objCCrashAsyncSafeThread
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"Exceptions",
			"Throw C++ exception",
			"Throw an uncaught C++ exception. This is a difficult case for crash reporters to handle, as it involves the destruction of the data necessary to generate a correct backtrace.",
			ObjectiveCBridge.objCCrashCXXException
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"Exceptions",
			"Throw Objective-C exception",
			"Throw an uncaught Objective-C exception. It's possible to generate a better crash report here compared to the C++ Exception case because NSUncaughtExceptionHandler can be used, which isn't available for C++ extensions.",
			ObjectiveCBridge.objCCrashObjCException
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"Objective-C",
			"Access a non-object as an object",
			"Call NSLog(@\\\"%@\\\", 16);, causing a crash when the runtime attempts to treat 16 as a pointer to an object.",
			ObjectiveCBridge.objCCrashNSLog
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"Objective-C",
			"Crash inside objc_msgSend()",
			"Send a message to an invalid object, resulting in a crash inside objc_msgSend().",
			ObjectiveCBridge.objCCrashObjCMsgSend
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"Objective-C",
			"Message a released object",
			"Send a message to an object whose memory has already been freed.",
			ObjectiveCBridge.objCCrashReleasedObject
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"SIGBUS",
			"Write to a read-only page",
			"Attempt to write to a page into which the app's code is mapped.",
			ObjectiveCBridge.objCCrashROPage
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"SIGILL",
			"Execute a privileged instruction",
			"Attempt to execute an instruction that can only be executed in supervisor mode.",
			ObjectiveCBridge.objCCrashPrivInst
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"SIGILL",
			"Execute an undefined instruction",
			"Attempt to execute an instructiondinn not to be defined on the current architecture.",
			ObjectiveCBridge.objCCrashUndefInst
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"SIGSEGV",
			"Dereference a NULL pointer",
			"Attempt to read from 0x0, which causes a segmentation violation.",
			ObjectiveCBridge.objCCrashNULL
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"SIGSEGV",
			"Dereference a bad pointer",
			"Attempt to read from a garbage pointer that's not mapped but also isn't NULL.",
			ObjectiveCBridge.objCCrashGarbage
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"SIGSEGV",
			"Jump into an NX page",
			"Call a function pointer to memory in a non-executable page.",
			ObjectiveCBridge.objCCrashNXPage
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"SIGSEGV",
			"Stack overflow",
			"Execute an infinitely recursive method, which overflows the stack and causes a crash by attempting to write to the guard page at the end.",
			ObjectiveCBridge.objCCrashStackGuard
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"SIGTRAP",
			"Call __builtin_trap()",
			"Call __builtin_trap() to generate a trap exception.",
			ObjectiveCBridge.objCCrashTrap
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"SIGTRAP",
			"Call abort()",
			"Call abort() to terminate the program.",
			ObjectiveCBridge.objCCrashAbort
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"Various",
			"Corrupt malloc()'s internal tracking information",
			"Write garbage into data areas used by malloc to track memory allocations. This simulates the kind of heap overflow and/or heap corruption likely to occur in an application; if the crash reporter itself uses malloc, the corrupted heap will likely trigger a crash in the crash reporter itself.",
			ObjectiveCBridge.objCCrashCorruptMalloc
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"Various",
			"Corrupt the Objective-C runtime's structures",
			"Write garbage into data areas used by the Objective-C runtime to track classes and objects. Bugs of this nature are why crash reporters cannot use Objective-C in their crash handling code, as attempting to do so is likely to lead to a crash in the crash reporting code.",
			ObjectiveCBridge.objCCrashCorruptObjC
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"Various",
			"DWARF Unwinding",
			"Trigger a crash in a frame that requires DWARF or Compact Unwind support to correctly unwind. Unwinders that do not support DWARF will terminate on the second frame. The tests will fail for all unwinders on ARMv6 and ARMv7 (DWARF/eh_frame is unsupported). ",
			ObjectiveCBridge.objCCrashFramelessDWARF
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"Various",
			"Overwrite link register, then crash",
			"Trigger a crash after first overwriting the link register. Crash reporters that insert a stack frame based on the link register can generate duplicate or incorrect stack frames in the report. This does not apply to architectures that do not use a link register, such as x86-64.",
			ObjectiveCBridge.objCCrashOverwriteLinkRegister
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"Various",
			"Smash the bottom of the stack",
			"Overwrite data below the current stack pointer. This will destroy the current function. Reporting of this crash is expected to fail. Succeeding is basically luck.",
			ObjectiveCBridge.objCCrashSmashStackBottom
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"Various",
			"Smash the top of the stack",
			"Overwrite data above the current stack pointer. This will destroy the current stack trace. Reporting of this crash is expected to fail. Succeeding is basically luck.",
			ObjectiveCBridge.objCCrashSmashStackTop
		));
		UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"Various",
			"Swift",
			"Trigger a crash from inside a Swift method.",
			ObjectiveCBridge.objCCrashSwift
		));
		/*UnityCrashFactory.addCrashIntoDictionary(dictionary, new ObjectiveCCrash(
			"",
			"",
			"",
			ObjectiveCBridge.
		));*/
	}
}
