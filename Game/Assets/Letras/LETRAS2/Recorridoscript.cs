using UnityEngine;
using System.Collections;

public class Recorridoscript : MonoBehaviour {
	float puntoTiempo = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		puntoTiempo += Time.deltaTime;

		if (puntoTiempo >= 10f) {
			
			GameObject.Find("recorrido").GetComponent<SpriteRenderer>().enabled = false;
			puntoTiempo=0.0f;
		
		}
	}
}