using UnityEngine;
using System.Collections;

public class LluviaScript : MonoBehaviour {
	float lluviaTiempo = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lluviaTiempo += Time.deltaTime;

		//Debug.LogWarning(lluviaTiempo);
		
		if (lluviaTiempo >= 15f) {

			GameObject.Find("lluvia1").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("lluvia2").GetComponent<SpriteRenderer>().enabled = true;
			if (lluviaTiempo >= 20f) {
			lluviaTiempo=0.0f;
			GameObject.Find("lluvia1").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("lluvia2").GetComponent<SpriteRenderer>().enabled = false;
			}
		}


	}
}
