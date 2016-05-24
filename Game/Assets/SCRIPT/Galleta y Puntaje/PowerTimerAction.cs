using UnityEngine;
using System.Collections;

public class PowerTimerAction : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		
		if (collider.tag == "Player") {
			
			DestroyObject(gameObject);
			bool isDead = GameObject.Find("PowerTimer").GetComponent<G_PowerTimer>().noTimer = true;
			float dist = GameObject.Find("Puntajes").GetComponent<Puntaje>().dist += 100;

		}
	}
}