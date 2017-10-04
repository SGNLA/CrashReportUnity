using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using AOT;

public class ObjectiveCBridge : MonoBehaviour {
	#if UNITY_IOS
	[DllImport ("__Internal")]
	private static extern void crashNULL();

	[DllImport ("__Internal")]
	private static extern void crashGarbage();

	[DllImport ("__Internal")]
	private static extern void crashROPage();

	[DllImport ("__Internal")]
	private static extern void crashNXPage();

	[DllImport ("__Internal")]
	private static extern void crashUndefInst();

	[DllImport ("__Internal")]
	private static extern void crashPrivInst();

	[DllImport ("__Internal")]
	private static extern void crashAbort();

	[DllImport ("__Internal")]
	private static extern void crashTrap();

	[DllImport ("__Internal")]
	private static extern void crashObjCException();

	[DllImport ("__Internal")]
	private static extern void crashCXXException();

	[DllImport ("__Internal")]
	private static extern void crashReleasedObject();

	[DllImport ("__Internal")]
	private static extern void crashObjCMsgSend();

	[DllImport ("__Internal")]
	private static extern void crashCorruptMalloc();

	[DllImport ("__Internal")]
	private static extern void crashSmashStackTop();

	[DllImport ("__Internal")]
	private static extern void crashSmashStackBottom();

	[DllImport ("__Internal")]
	private static extern void crashCorruptObjC();

	[DllImport ("__Internal")]
	private static extern void crashNSLog();

	[DllImport ("__Internal")]
	private static extern void crashAsyncSafeThread();

	[DllImport ("__Internal")]
	private static extern void crashOverwriteLinkRegister();

	[DllImport ("__Internal")]
	private static extern void crashStackGuard();

	[DllImport ("__Internal")]
	private static extern void crashFramelessDWARF();

	[DllImport ("__Internal")]
	private static extern void crashSwift();
	#endif

	public static void objCCrashNULL() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashNULL();
		}
		#endif
	}

	public static void objCCrashGarbage() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashGarbage();
		}
		#endif
	}

	public static void objCCrashROPage() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashROPage();
		}
		#endif
	}

	public static void objCCrashNXPage() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashNXPage();
		}
		#endif
	}

	public static void objCCrashUndefInst() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashUndefInst();
		}
		#endif
	}

	public static void objCCrashPrivInst() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashPrivInst();
		}
		#endif
	}

	public static void objCCrashAbort() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashAbort();
		}
		#endif
	}

	public static void objCCrashTrap() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashTrap();
		}
		#endif
	}

	public static void objCCrashObjCException() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashObjCException();
		}
		#endif
	}

	public static void objCCrashCXXException() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashCXXException();
		}
		#endif
	}

	public static void objCCrashReleasedObject() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashReleasedObject();
		}
		#endif
	}

	public static void objCCrashObjCMsgSend() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashObjCMsgSend();
		}
		#endif
	}

	public static void objCCrashCorruptMalloc() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashCorruptMalloc();
		}
		#endif
	}

	public static void objCCrashSmashStackTop() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashSmashStackTop();
		}
		#endif
	}

	public static void objCCrashSmashStackBottom() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashSmashStackBottom();
		}
		#endif
	}

	public static void objCCrashCorruptObjC() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashCorruptObjC();
		}
		#endif
	}

	public static void objCCrashNSLog() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashNSLog();
		}
		#endif
	}

	public static void objCCrashAsyncSafeThread() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashAsyncSafeThread();
		}
		#endif
	}

	public static void objCCrashOverwriteLinkRegister() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashOverwriteLinkRegister();
		}
		#endif
	}

	public static void objCCrashStackGuard() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashStackGuard();
		}
		#endif
	}

	public static void objCCrashFramelessDWARF() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashFramelessDWARF();
		}
		#endif
	}

	public static void objCCrashSwift() {
		#if UNITY_IOS
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			crashSwift();
		}
		#endif
	}
}
