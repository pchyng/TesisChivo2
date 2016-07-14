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
		}
	}
	
	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static ScoreList LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(ScoreList));
		return serializer.Deserialize(new StringReader(text)) as ScoreList;
	}

	public static string getPath(string fileName){
		#if UNITY_EDITOR
		return Application.dataPath +"/StreamingAssets/Scores/"+fileName;
		#elif UNITY_ANDROID
		return Application.persistentDataPath+"/"+fileName;
		#elif UNITY_IPHONE
		return Application.persistentDataPath+"/"+fileName;
		#else
		return Application.dataPath +"/"+ fileName;
		#endif
	}
}
