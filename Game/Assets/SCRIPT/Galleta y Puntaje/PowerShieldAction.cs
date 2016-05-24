using UnityEngine;
using System.Collections;

public class PowerShieldAction : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player") {
			
			DestroyObject(gameObject);
			GameObject.Find("PowerShield").GetComponent<G_PowerShield>().noPoweShield = true;
		}
	}
}
