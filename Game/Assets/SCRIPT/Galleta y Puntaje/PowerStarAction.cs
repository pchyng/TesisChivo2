using UnityEngine;
using System.Collections;

public class PowerStarAction : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){

		if (collider.tag == "Player") {

			DestroyObject(gameObject);
			bool isDead = GameObject.Find("PowerStar").GetComponent<G_PowerStar>().noPoweStar = true;
		
		}
	}
}
