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
	static bool saved;
	public Transform other;
	string lPath;
	public bool calculoEnd = false;
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
		calculoEnd = false;
		saved = false;
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
				lPath= ScoreList.getPath("scores.xml");
			
				try {
					var scoreCollection = ScoreList.Load(lPath);
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
				}catch{
					createXML (lPath);
					var scoreCollection = ScoreList.Load(lPath);
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
				var lTotales = GameObject.Find ("Totales2").GetComponent<totales> ();
				lTotales.test();
			}
		}
	}

	static void createXML(string path) {
		XmlDocument doc = new XmlDocument( );
		
		//(1) the xml declaration is recommended, but not mandatory
		XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration( "1.0", "UTF-8", null );
		XmlElement root = doc.DocumentElement;
		doc.InsertBefore( xmlDeclaration, root );
		
		//(2) string.Empty makes cleaner code
		XmlElement element0 = doc.CreateElement( string.Empty, "ScoreListCollection", string.Empty );
		element0.SetAttribute("xmlns:xsi","http://www.w3.org/2001/XMLSchema-instance");
		element0.SetAttribute("xmlns:xsd","http://www.w3.org/2001/XMLSchema");
		doc.AppendChild( element0 );
		
		XmlElement element1 = doc.CreateElement( string.Empty, "Listado", string.Empty );
		element0.AppendChild( element1 );
		
		XmlElement element2 = doc.CreateElement( string.Empty, "Items",  string.Empty );
		element2.SetAttribute("name","Primero");
		element1.AppendChild( element2 );
		
		XmlElement element3 = doc.CreateElement( string.Empty, "Status", string.Empty );
		XmlText text1 = doc.CreateTextNode( "5" );
		element3.AppendChild( text1 );
		element2.AppendChild( element3 );

		XmlElement element4 = doc.CreateElement( string.Empty, "Items",  string.Empty );
		element4.SetAttribute("name","Segundo");
		element1.AppendChild( element4 );
		
		XmlElement element5 = doc.CreateElement( string.Empty, "Status", string.Empty );
		XmlText text2 = doc.CreateTextNode( "4" );
		element5.AppendChild( text2 );
		element4.AppendChild( element5 );

		XmlElement element6 = doc.CreateElement( string.Empty, "Items",  string.Empty );
		element6.SetAttribute("name","Tercero");
		element1.AppendChild( element6 );
		
		XmlElement element7 = doc.CreateElement( string.Empty, "Status", string.Empty );
		XmlText text3 = doc.CreateTextNode( "3" );
		element7.AppendChild( text3 );
		element6.AppendChild( element7 );

		XmlElement element8 = doc.CreateElement( string.Empty, "Items",  string.Empty );
		element8.SetAttribute("name","Cuarto");
		element1.AppendChild( element8 );
		
		XmlElement element9 = doc.CreateElement( string.Empty, "Status", string.Empty );
		XmlText text4 = doc.CreateTextNode( "4" );
		element9.AppendChild( text4 );
		element8.AppendChild( element9 );

		XmlElement element10 = doc.CreateElement( string.Empty, "Items",  string.Empty );
		element10.SetAttribute("name","Quinto");
		element1.AppendChild( element10 );
		
		XmlElement element11 = doc.CreateElement( string.Empty, "Status", string.Empty );
		XmlText text5 = doc.CreateTextNode( "5" );
		element11.AppendChild( text5 );
		element10.AppendChild( element11 );

		doc.Save( path );
	}
}
	

