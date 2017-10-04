using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCrashFactory{
	static public void generateAllCrashCasesInto(Dictionary<string, List<Crash> > dictionary) {
		addCrashIntoDictionary (dictionary, new CrashArgumentException());
		addCrashIntoDictionary (dictionary, new CrashCCharpException());
		addCrashIntoDictionary (dictionary, new CrashDirectoryNotFound());
		addCrashIntoDictionary (dictionary, new CrashDivideByZero());
		addCrashIntoDictionary (dictionary, new CrashFileNotFound());
		addCrashIntoDictionary (dictionary, new CrashIndexOutOfRange());
		addCrashIntoDictionary (dictionary, new CrashKeyNotFound());
		addCrashIntoDictionary (dictionary, new CrashNullReference());
		addCrashIntoDictionary (dictionary, new CrashOutOfMemory());
		addCrashIntoDictionary (dictionary, new CrashOverFlow());
		addCrashIntoDictionary (dictionary, new CrashStackOverflow());
		addCrashIntoDictionary (dictionary, new CrashTooLongTextMeshGenerator());
		addCrashIntoDictionary (dictionary, new CrashUnityException());
	}

	/// <summary>
	/// Adds the crash into dictionary.
	/// This can be public, just put here and set to private first, can be extended.
	/// </summary>
	/// <param name="dictionary">Dictionary.</param>
	/// <param name="crash">Crash.</param>
	static public void addCrashIntoDictionary(Dictionary<string, List<Crash> > dictionary, Crash crash) {
		if(!dictionary.ContainsKey(crash.category)) {
			dictionary[crash.category] = new List<Crash>();
		}
		dictionary[crash.category].Add(crash);
	}
}
