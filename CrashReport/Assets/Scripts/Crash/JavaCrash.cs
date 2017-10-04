using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaCrash : Crash {
	private AndroidJavaObject _refJavaObject;

	public JavaCrash(AndroidJavaObject javaObject) {
		_refJavaObject = javaObject;

		this.category = _refJavaObject.Get<string> ("category");
		this.title = _refJavaObject.Get<string> ("title");
		this.description = _refJavaObject.Get<string> ("description");
	}

	override public void crash() {
		if (_refJavaObject != null) {
			using(AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
				AndroidJavaObject activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");

				_refJavaObject.Call("crash", activityContext);
			}
		}
	}
}
