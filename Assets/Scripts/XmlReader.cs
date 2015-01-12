using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

using System.IO;

public class XmlReader 
{
	public static T LoadFromXml<T> (string path)
		where T : class
	{
		TextAsset xml = Resources.Load( path ) as TextAsset;

		if(xml == null){ return null; }

		var ser = new XmlSerializer (typeof(T));

		var stringReader = new StringReader(xml.text);

		var obj = ser.Deserialize(stringReader);

		var retClass = (T)obj;

		return retClass;
	}
}
