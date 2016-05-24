using UnityEngine;
using System.Collections;

public class pauseScript : MonoBehaviour {

	public bool paused;


	// Use this for initialization
	void Start () {
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Pause(){
		paused = !paused;
		if (paused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	
	}
}
