using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Config{

	[XmlAttribute("name")]
	public string Name;
	public bool Status;

}
