using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;


[RequireComponent(typeof(AudioSource))]
public class MutearSonido : MonoBehaviour {

	public bool mute;
	
	void Start() {
		var lConfigCollection = ConfigManager.Load(Path.Combine(Path.Combine(Application.dataPath,"Scores"),"config.xml"));
		
		//cONGIFURANDO SONIDO, VALORES PERMITIDOS EN config.xml true = un-mute & false = mute
		var lStatus = lConfigCollection.getConfigs (0).Status;
		mute = lStatus;

	}
	
	public void handleMute(){
		mute = !mute;
		var lConfigCollection = ConfigManager.Load(Path.Combine(Path.Combine(Application.dataPath,"Scores"),"config.xml"));
		var lConfig = new Config ();
		lConfig = lConfigCollection.getConfigs (0);
		lConfig.Status = mute;
		lConfigCollection.Save(Path.Combine(Path.Combine(Application.dataPath,"Scores"),"config.xml"),0);
		AudioSource source2 = GameObject.Find("Camara").GetComponent<AudioSource>();
		AudioSource source3 = GameObject.Find("Jugador").GetComponent<AudioSource>();
		source2.mute=!mute;
		source3.mute=!mute;
	}

}
