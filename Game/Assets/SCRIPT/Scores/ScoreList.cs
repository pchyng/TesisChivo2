using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

[XmlRoot("ScoreListCollection")]

public class ScoreList{
	[XmlArray("Listado"),XmlArrayItem("Items")]
	public Score[] Scores;

	public Score getScores(int i)
	{
		return Scores [i];
	}

	public void Save(string path,int pos)
	{
		//var lScore = new Score ();
		//lScore.Name="meh";
		//lScore.Points = (int)GameObject.Find("Puntajes").GetComponent<Puntaje>().dist;
		//Scores[pos]=lScore;

		var serializer = new XmlSerializer(typeof(ScoreList));
		using(var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}
	
	public static ScoreList Load(string path)
	{
		var serializer = new XmlSerializer(typeof(ScoreList));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as ScoreList;
		//	Debug.LogWarning(serializer.Deserialize(stream));

		}
	}
	
	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static ScoreList LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(ScoreList));
		return serializer.Deserialize(new StringReader(text)) as ScoreList;
	}
}
