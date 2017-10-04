using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashArgumentException : Crash {
	private Texture texture;

	public CrashArgumentException() {
		this.category = "Unity";
		this.title = "Null as Argument";
		this.description = "Using null as argument when calling unity graphic BlitMultiTap.";

		texture = new Texture ();
	}

	override public void crash() {
		Graphics.BlitMultiTap (texture, null, null, new Vector2(0.0f, 0.0f));
	}
}
