using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDivideByZero : Crash {
	private int zero = 0;

	public CrashDivideByZero() {
		this.category = "Arithmetic";
		this.title = "Divide by Zero";
		this.description = "Crash on int divide by 0 int.";
	}

	override public void crash() {
		float value = 1 / zero;
	}
}
