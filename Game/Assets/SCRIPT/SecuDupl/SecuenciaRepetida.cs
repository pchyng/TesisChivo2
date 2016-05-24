using UnityEngine;
using System.Collections;

public class SecuenciaRepetida : MonoBehaviour {

	float monsyMax = 14f;
	float monsyMin = -15.5f;

	float monsxMax = 500f;
	float monsxMin = 20f;

	int numDBPanel = 4;

	void OnTriggerEnter2D(Collider2D collider){
		
		float widthOfBGObject =((BoxCollider2D)collider).size.x;
		Vector3 posi = collider.transform.position;

		posi.x += widthOfBGObject * numDBPanel - widthOfBGObject+150f;

		if (collider.tag == "Monstruos") {
			//posi.y =Random.Range(monsyMax,monsyMin);
			DestroyObject(collider.gameObject);
			int aux = GameObject.Find("Monstruos").GetComponent<GeneraMonstr>().actualMonsterNumber;
			GameObject.Find("Monstruos").GetComponent<GeneraMonstr>().actualMonsterNumber = aux-1;
		}

		if (collider.tag == "Obstaculos") {
			//posi.y =Random.Range(monsyMax,monsyMin);
			//DestroyObject(collider.transform.parent.gameObject);
			DestroyObject(collider.gameObject);
			int aux = GameObject.Find("Obstaculos").GetComponent<GeneraRocas>().actualMonsterNumber;
			GameObject.Find("Obstaculos").GetComponent<GeneraRocas>().actualMonsterNumber = aux-1;
		
		}

		/*if (collider.tag == "Obstaculos") {
		
		}*/

		if (collider.tag == "Galleta") {
			DestroyObject(collider.gameObject);
			GameObject.Find("Galletas").GetComponent<Generator>().noCookie = true;
	//		Destroy(GameObject.FindGameObjectWithTag["Galleta"]);

	//		posi.x =Random.Range(monsyMax,monsyMin);
		}
		if (collider.tag != "Galleta") {
			collider.transform.position = posi;
		}
		if (collider.tag == "PowerStar") {
			DestroyObject(collider.gameObject);
			GameObject.Find("PowerStar").GetComponent<G_PowerStar>().noPoweStar = true;
			//		Destroy(GameObject.FindGameObjectWithTag["Galleta"]);
			
			//		posi.x =Random.Range(monsyMax,monsyMin);
		}

		if (collider.tag != "PowerShield") {
			collider.transform.position = posi;
		}
		if (collider.tag == "PowerShield") {
			DestroyObject(collider.gameObject);
			GameObject.Find("PowerShield").GetComponent<G_PowerShield>().noPoweShield = true;
			//		Destroy(GameObject.FindGameObjectWithTag["Galleta"]);
			
			//		posi.x =Random.Range(monsyMax,monsyMin);
		}

		if (collider.tag != "PowerShiel") {
			collider.transform.position = posi;
		}
		if (collider.tag == "PowerVida") {
			DestroyObject(collider.gameObject);
			GameObject.Find("PowerVida").GetComponent<G_PowerVida>().noPoweVida = true;
			//		Destroy(GameObject.FindGameObjectWithTag["Galleta"]);
			
			//		posi.x =Random.Range(monsyMax,monsyMin);
		}
		if (collider.tag != "PowerVida") {
			collider.transform.position = posi;
		}

	}
}


