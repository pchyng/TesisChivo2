using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Puntaje : MonoBehaviour {
	public GUIText guiText;
	static int score = 0;
	static int highScore = 0;
	public float dist = 0f;
	static bool saved = false;
	public Transform other;
	
	static Puntaje instance;

	static public void AddPoint(){
		if (instance.princesa.muerte)
			return;
		score++;
		if (score > highScore) {
			highScore = score;
		}
	}
	PrincesavueScript princesa;
	
	void Start(){
		instance = this;
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		if(player_go == null){
			Debug.LogError("No se encuentra objeto con tag 'Player'");
		}
		princesa = player_go.GetComponent<PrincesavueScript>();
		score=0;
		PlayerPrefs.GetInt ("highScore", 0);
		
	}
	
	void OnDestroy(){
		instance = null;
		PlayerPrefs.SetInt ("highScore", highScore);
		
	}
	
	void Update (){
		//CON ESTO AGARRAS JUSTO CUANDO MUERE EL PLAYER
		bool isDead = GameObject.Find("Jugador").GetComponent<PrincesavueScript>().muerte;
		bool isPowerClock = GameObject.Find("Jugador").GetComponent<PrincesavueScript>().powerClock;

		if (!isDead) {
			//			dist = Vector3.Distance(other.position, transform.position);
			dist = isPowerClock ? dist + (Time.deltaTime*10*2):dist + (Time.deltaTime * 10);

			guiText.text = "Galleta: " + score + "\nDistancia: " + (int)(dist);
		} else {
			if(!saved){
				saved=true;
				var lPath = Application.streamingAssetsPath + "/Scores/config.xml";
				lPath= ConfigManager.getPath("scores.xml");

				//var scoreCollection = ScoreList.Load(Path.Combine(Path.Combine(Application.dataPath,"Scores"),"scores.xml"));
				var scoreCollection = ScoreList.Load(lPath);
				//				Debug.LogWarning(serializer.Deserialize(stream));
				var lScore = new Score ();
				int auxPints = (int)(dist);
				
				for (int i = 0; i < 5; i++) {
					lScore = scoreCollection.getScores(i);
					Debug.LogWarning(lScore.Name);
					Debug.LogWarning(lScore.Points);
					if(lScore.Points<=auxPints){
						int aux2 = lScore.Points; 
						lScore.Points = auxPints;
						auxPints = aux2;
					}
				}
				scoreCollection.Save(lPath,0);
				guiText.text ="";
			}
			
		}
	}
}
