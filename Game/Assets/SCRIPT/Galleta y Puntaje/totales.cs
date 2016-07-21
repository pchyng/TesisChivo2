using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

public class totales : MonoBehaviour {
	public GUIText guiText;
	private ScoreList scoreCollection;
	private bool isDead;
	string lPath;
	public bool evaluation;

	// Use this for initialization
	void Start () {
		bool isDead = false;
		lPath= ScoreList.getPath("scores.xml");
		evaluation = false;
	}


	// Update is called once per frame
	//void Update () {
		public void test() {
		if (!isDead) {
			isDead = GameObject.Find ("Jugador").GetComponent<PrincesavueScript> ().muerte;
			if(isDead){
				try {
					scoreCollection = ScoreList.Load(lPath);
				}
				catch{
					createXML3 (lPath);
					scoreCollection = ScoreList.Load(lPath);
				} 	


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

	static void createXML3(string path) {
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
