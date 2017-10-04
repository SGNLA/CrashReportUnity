using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashOverFlow : Crash {

	public CrashOverFlow() {
		this.category = "C Sharp";
		this.title = "Hex to Char Overflow";
		this.description = "Convert large int to char";
	}

	override public void crash() {
		System.Convert.ToChar (0xffffffff);
	}
}
