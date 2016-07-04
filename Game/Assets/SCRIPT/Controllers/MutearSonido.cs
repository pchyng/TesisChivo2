using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using System.Xml;

[RequireComponent(typeof(AudioSource))]
public class MutearSonido : MonoBehaviour {

	public bool mute;
	string lPath;
	string lPath2;

	void Start() {
	    lPath = Application.streamingAssetsPath + "/Scores/config.xml";
		lPath2 = Application.persistentDataPath + "/config.xml";
		try {
			var lConfigCollection = ConfigManager.Load(lPath2);
			var lStatus = lConfigCollection.getConfigs (0).Status;
			mute = lStatus;
		}
		catch (Exception e) {
			createXML (lPath2);
			var lConfigCollection = ConfigManager.Load(lPath2);
			var lStatus = lConfigCollection.getConfigs (0).Status;
			mute = lStatus;
		} 







//		var lPath = Application.streamingAssetsPath + "!/assets/Scores/config.xml";

		//var lConfigCollection = ConfigManager.Load(lPath);

		//cONGIFURANDO SONIDO, VALORES PERMITIDOS EN config.xml true = un-mute & false = mute
		//var lStatus = lConfigCollection.getConfigs (0).Status;
		//mute = lStatus;

	}
	
	public void handleMute(){
		mute = !mute;
		lPath = Application.streamingAssetsPath + "/Scores/config.xml";
		lPath2 = Application.persistentDataPath + "/config.xml";


		var lConfigCollection = ConfigManager.Load(lPath2);
		var lConfig = new Config ();
		lConfig = lConfigCollection.getConfigs (0);
		lConfig.Status = mute;
		lConfigCollection.Save(lPath,0);
		AudioSource source2 = GameObject.Find("Camara").GetComponent<AudioSource>();
		AudioSource source3 = GameObject.Find("Jugador").GetComponent<AudioSource>();
		source2.mute=!mute;
		source3.mute=!mute;
	}

	static void createXML(string path) {
		XmlDocument doc = new XmlDocument( );
		
		//(1) the xml declaration is recommended, but not mandatory
		XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration( "1.0", "UTF-8", null );
		XmlElement root = doc.DocumentElement;
		doc.InsertBefore( xmlDeclaration, root );

		//(2) string.Empty makes cleaner code
		XmlElement element0 = doc.CreateElement( string.Empty, "ConfigCollection", string.Empty );
		element0.SetAttribute("xmlns:xsi","http://www.w3.org/2001/XMLSchema-instance");
		element0.SetAttribute("xmlns:xsd","http://www.w3.org/2001/XMLSchema");
		doc.AppendChild( element0 );

		XmlElement element1 = doc.CreateElement( string.Empty, "Listado", string.Empty );
		element0.AppendChild( element1 );
		
		XmlElement element2 = doc.CreateElement( string.Empty, "Items",  string.Empty );
		element2.SetAttribute("name","Volumen");
		element1.AppendChild( element2 );
		
		XmlElement element3 = doc.CreateElement( string.Empty, "Status", string.Empty );
		XmlText text1 = doc.CreateTextNode( "true" );
		element3.AppendChild( text1 );
		element2.AppendChild( element3 );
		
		doc.Save( path );
	}
}
