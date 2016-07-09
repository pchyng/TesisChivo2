using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using System.Xml;

public class Puntaje : MonoBehaviour {
	public GUIText guiText;
	static int score = 0;
	static int highScore = 0;
	public float dist = 0f;
	static bool saved = false;
	public Transform other;

	string lPath;

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
				lPath = Application.streamingAssetsPath + "/Scores/config.xml";
				lPath= ConfigManager.getPath("scores.xml");
			}
			try {
				var lConfigCollection = ConfigManager.Load(lPath);
				var lStatus = lConfigCollection.getConfigs (0);
				}
			catch (Exception e) {
				createXML (lPath);
				var lConfigCollection = ConfigManager.Load(lPath);
				var lStatus = lConfigCollection.getConfigs (0);
			} 
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

	static void createXML(string path) {
		XmlDocument doc = new XmlDocument( );
		
		//(1) the xml declaration is recommended, but not mandatory
		XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration( "1.0", "Windows-1252", null );
		XmlElement root = doc.DocumentElement;
		doc.InsertBefore( xmlDeclaration, root );
		
		//(2) string.Empty makes cleaner code
		XmlElement element0 = doc.CreateElement( string.Empty, "ScoreListCollection", string.Empty );
		element0.SetAttribute("xmlns:xsi","http://www.w3.org/2001/XMLSchema-instance");
		element0.SetAttribute("xmlns:xsd","http://www.w3.org/2001/XMLSchema");
		doc.AppendChild( element0 );
		
		XmlElement element1 = doc.CreateElement( string.Empty, "Listado", string.Empty );
		element0.AppendChild( element1 );
		
		XmlElement elementPN1 = doc.CreateElement( string.Empty, "Items",  string.Empty );
		elementPN1.SetAttribute("name","Primero");
		element1.AppendChild( elementPN1 );
		XmlElement elementPP1 = doc.CreateElement( string.Empty, "Points", string.Empty );
		XmlText text1 = doc.CreateTextNode( "5" );
		elementPP1.AppendChild( text1 );
		elementPN1.AppendChild( elementPP1 );

		XmlElement elementPN2 = doc.CreateElement( string.Empty, "Items",  string.Empty );
		elementPN2.SetAttribute("name","Segundo");
		element1.AppendChild( elementPN2 );
		XmlElement elementPP2 = doc.CreateElement( string.Empty, "Points", string.Empty );
		XmlText text2 = doc.CreateTextNode( "4" );
		elementPP2.AppendChild( text2 );
		elementPN2.AppendChild( elementPP2 );

		XmlElement elementPN3 = doc.CreateElement( string.Empty, "Items",  string.Empty );
		elementPN3.SetAttribute("name","Tercero");
		element1.AppendChild( elementPN3 );
		XmlElement elementPP3 = doc.CreateElement( string.Empty, "Points", string.Empty );
		XmlText text3 = doc.CreateTextNode( "3" );
		elementPP3.AppendChild( text3 );
		elementPN3.AppendChild( elementPP3 );

		XmlElement elementPN4 = doc.CreateElement( string.Empty, "Items",  string.Empty );
		elementPN4.SetAttribute("name","Cuarto");
		element1.AppendChild( elementPN4 );
		XmlElement elementPP4 = doc.CreateElement( string.Empty, "Points", string.Empty );
		XmlText text4 = doc.CreateTextNode( "2" );
		elementPP4.AppendChild( text4 );
		elementPN4.AppendChild( elementPP4 );

		XmlElement elementPN5 = doc.CreateElement( string.Empty, "Items",  string.Empty );
		elementPN5.SetAttribute("name","Quinto");
		element1.AppendChild( elementPN5 );
		XmlElement elementPP5 = doc.CreateElement( string.Empty, "Points", string.Empty );
		XmlText text5 = doc.CreateTextNode( "1" );
		elementPP5.AppendChild( text5 );
		elementPN5.AppendChild( elementPP5 );

		doc.Save( path );
	}
	}
	

