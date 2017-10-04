using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCCrash : Crash {
	public delegate void CrashDelegate();
	public CrashDelegate m_crashMethod;

	public ObjectiveCCrash(string category, string title, string description, CrashDelegate crashMethod) {
		this.category = category;
		this.title = title;
		this.description = description;

		this.m_crashMethod = crashMethod;
	}

	override public void crash() {
		this.m_crashMethod();
	}
}
