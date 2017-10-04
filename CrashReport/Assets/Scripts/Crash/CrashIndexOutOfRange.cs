using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashIndexOutOfRange : Crash {
	private int[] dummyArray;

	public CrashIndexOutOfRange() {
		this.category = "SIGSEGV";
		this.title = "Index Out of Range";
		this.description = "Accessing array with index that's over the limit.";

		dummyArray = new int[5];
	}

	override public void crash() {
		Debug.Log (dummyArray[10]);
	}
}
