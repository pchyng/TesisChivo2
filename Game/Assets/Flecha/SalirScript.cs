using UnityEngine;
using System.Collections;

public class SalirScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit ();
	}

	public void onClick(){
		Application.Quit ();
	}


}
