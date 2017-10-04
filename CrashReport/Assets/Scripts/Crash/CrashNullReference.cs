using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashNullReference : Crash {
	private GameObject fakeGameObject;

	public CrashNullReference() {
		this.category = "SIGSEGV";
		this.title = "Null Reference";
		this.description = "Crash on null reference.";
	}

	override public void crash() {
		if (fakeGameObject.activeSelf) {
		}
	}
}
