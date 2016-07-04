using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class totales : MonoBehaviour {
	public GUIText guiText;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool isDead = GameObject.Find("Jugador").GetComponent<PrincesavueScript>().muerte;
		var lPath = Application.streamingAssetsPath + "/Scores/scores.xml";

		//var scoreCollection = ScoreList.Load(Path.Combine(Path.Combine(Application.dataPath,"Scores"),"scores.xml"));
		var scoreCollection = ScoreList.Load(lPath);
		if(isDead){
			isDead=true;
				
				//				Debug.LogWarning(serializer.Deserialize(stream));
				
				
			guiText.text="";
			//CAMBIAR POR OTRO GUI TEXT
			guiText.text = scoreCollection.getScores(0).Name+ ": "+ scoreCollection.getScores(0).Points+" ptos\n" +
				""+scoreCollection.getScores(1).Name+ ": "+ scoreCollection.getScores(1).Points+" ptos\n" +
					""+scoreCollection.getScores(2).Name+ ": "+ scoreCollection.getScores(2).Points+" ptos\n" +
					""+scoreCollection.getScores(3).Name+ ": "+ scoreCollection.getScores(3).Points+" ptos\n" +
					""+scoreCollection.getScores(4).Name+ ": "+ scoreCollection.getScores(4).Points+" ptos\n";
			

	}
}
}
