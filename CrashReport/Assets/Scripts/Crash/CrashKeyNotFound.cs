using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashKeyNotFound : Crash {
	public CrashKeyNotFound() {
		this.category = "SIGSEGV";
		this.title = "Non-exist Key on Dictionary";
		this.description = "Using non exist key on dictionary.";
	}

	override public void crash() {
		Dictionary<string, string> testDictionary = new Dictionary<string, string> ();
		Debug.Log(testDictionary["nonexist"]);
	}
}
