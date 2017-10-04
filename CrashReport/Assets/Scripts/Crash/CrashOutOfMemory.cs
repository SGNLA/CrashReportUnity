using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashOutOfMemory : Crash {

	public CrashOutOfMemory() {
		this.category = "SIGSEGV";
		this.title = "Out of Memory";
		this.description = "New a very large Vector array to make app out of memory";
	}

	override public void crash() {
		Vector2[,,,,] dummyVector2 = new Vector2[100, 100, 100, 100, 100];
	}
}
