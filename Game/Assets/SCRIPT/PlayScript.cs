using UnityEngine;
using System.Collections;

public class PlayScript : MonoBehaviour {
	static bool vistoUnavz = false;
	// Use this for initialization
	void Start () {
		if (!vistoUnavz) {
			GetComponent<SpriteRenderer>().enabled = false;
		}
		vistoUnavz = false;
	}
	
	// Update is called once per frame
	void Update () {
		bool isDead = GameObject.Find("Jugador").GetComponent<PrincesavueScript>().muerte;
		if(isDead){
			GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}
