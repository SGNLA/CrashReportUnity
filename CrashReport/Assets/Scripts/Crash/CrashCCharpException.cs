using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCCharpException : Crash {

	public CrashCCharpException() {
		this.category = "C Sharp";
		this.title = "C Sharp Exception";
		this.description = "Throw C sharp system exception";
	}

	override public void crash() {
		throw new System.Exception ();
	}
}
