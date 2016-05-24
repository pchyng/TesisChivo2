using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Score{

	[XmlAttribute("name")]
	public string Name;
	public int Points;

}
