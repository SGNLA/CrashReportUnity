using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class CrashDirectoryNotFound : Crash {
	public CrashDirectoryNotFound() {
		this.category = "Accessing";
		this.title = "Access Non-exist Directory";
		this.description = "Try to create a new file in non-exist directory.";
	}

	override public void crash() {

		var serializer = new XmlSerializer(typeof(int));
		using (var stream = new FileStream("Assets/Resource/noSuchFolder/noSuchFile", FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}
}
