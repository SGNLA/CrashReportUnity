using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CrashFileNotFound : Crash {
	public CrashFileNotFound() {
		this.category = "Accessing";
		this.title = "Copy Non-exist File";
		this.description = "Try to copy Non-exist file";
	}

	override public void crash() {
		File.Copy(Path.Combine("Assets/Resource", "nonExist"), Path.Combine("Assets/Resource", "alsoNonExist"), true);
	}
}
