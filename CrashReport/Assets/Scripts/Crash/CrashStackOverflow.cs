using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashStackOverflow : Crash {

	public CrashStackOverflow() {
		this.category = "SIGSEGV";
		this.title = "Stack Overflow";
		this.description = "Call function recursively to make it stack overflow";
	}

	override public void crash() {
		this.crash();
	}
}
