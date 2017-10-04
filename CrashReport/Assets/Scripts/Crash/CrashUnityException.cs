using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashUnityException : Crash {

	public CrashUnityException() {
		this.category = "Unity";
		this.title = "Unity Exception";
		this.description = "Throw Unity exception";
	}

	override public void crash() {
		throw new UnityException ();
	}
}
