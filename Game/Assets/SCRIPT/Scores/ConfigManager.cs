using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

[XmlRoot("ConfigCollection")]


public class ConfigManager{
	[XmlArray("Listado"),XmlArrayItem("Items")]
	public Config[] Config;

	public Config getConfigs(int i)
	{
		return  Config [i];
	}
	public void Save(string path,int pos)
	{
		//var lScore = new Score ();
		//lScore.Name="meh";
		//lScore.Points = (int)GameObject.Find("Puntajes").GetComponent<Puntaje>().dist;
		//Scores[pos]=lScore;
		
		var serializer = new XmlSerializer(typeof(ConfigManager));
		using(var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}
	
	public static ConfigManager Load(string path)
	{
		var serializer = new XmlSerializer(typeof(ConfigManager));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as ConfigManager;
			//	Debug.LogWarning(serializer.Deserialize(stream));
			
		}
	}
	
	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static ConfigManager LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(ConfigManager));
		return serializer.Deserialize(new StringReader(text)) as ConfigManager;
	}
}
