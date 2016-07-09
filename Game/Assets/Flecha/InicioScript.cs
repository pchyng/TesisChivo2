using UnityEngine;
using System.Collections;

public class InicioScript : MonoBehaviour {
	


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadAddOnClick(int Menu)
	{
		Application.LoadLevelAdditive("Menu");
	}
}