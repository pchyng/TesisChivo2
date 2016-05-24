using UnityEngine;
using System.Collections;

public class GalletaPuntaje : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player") {
			Puntaje.AddPoint();
			DestroyObject(gameObject);
			GameObject.Find("Galletas").GetComponent<Generator>().noCookie = true;
		}
	}
}
