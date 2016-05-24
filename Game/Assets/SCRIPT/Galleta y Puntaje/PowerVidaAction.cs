using UnityEngine;
using System.Collections;

public class PowerVidaAction : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		
		if (collider.tag == "Player") {
			
			DestroyObject(gameObject);
			//bool isDead = GameObject.Find("PowerVida").GetComponent<G_PowerVida>().noPoweVida = true;
			
		}
	}
}