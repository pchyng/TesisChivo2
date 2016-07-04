using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;


[RequireComponent(typeof(AudioSource))]
public class MutearSonido : MonoBehaviour {

	public bool mute;
	string lPath;

	void Start() {
		lPath=Path.Combine (Path.Combine (Application.dataPath, "Scores"), "config.xml");
		//#if UNITY_ANDROID

		//	lPath= Application.streamingAssetsPath + "/assets/Scores/config.xml";
		//#endif

//		var lPath = Application.streamingAssetsPath + "!/assets/Scores/config.xml";

		var lConfigCollection = ConfigManager.Load(lPath);

		//cONGIFURANDO SONIDO, VALORES PERMITIDOS EN config.xml true = un-mute & false = mute
		var lStatus = lConfigCollection.getConfigs (0).Status;
		mute = lStatus;

	}
	
	public void handleMute(){
		mute = !mute;
		lPath = Application.streamingAssetsPath + "/Scores/config.xml";
		//lPath=Path.Combine (Path.Combine (Application.dataPath, "Scores"), "config.xml");
	//	var lConfigCollection = ConfigManager.Load(Path.Combine(Path.Combine(Application.dataPath,"Scores"),"config.xml"));
		var lConfigCollection = ConfigManager.Load(lPath);
		var lConfig = new Config ();
		lConfig = lConfigCollection.getConfigs (0);
		lConfig.Status = mute;
		lConfigCollection.Save(lPath,0);
		AudioSource source2 = GameObject.Find("Camara").GetComponent<AudioSource>();
		AudioSource source3 = GameObject.Find("Jugador").GetComponent<AudioSource>();
		source2.mute=!mute;
		source3.mute=!mute;
	}

}
