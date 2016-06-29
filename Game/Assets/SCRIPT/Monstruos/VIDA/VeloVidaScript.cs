using UnityEngine;
using System.Collections;

public class VeloVidaScript : MonoBehaviour {

	// variable decimal que sea menor a los frame para que se mueva mas lento
	static float velocidad = -(int)(Random.Range (-5, 10));
	
	// Update is called once per frame (se hace uso del Fixed para que no haya problemas con la fisica
	void FixedUpdate () {
		// vector 3 puesto que toma todos los ejes (x,y,z)
		// creas una variable en ese vector para poderla transformar a otra posicion
		Vector3 posic = transform.position;
		//se mueve en el eje de las x
		posic.x += velocidad * Time.deltaTime;
		// de vuelta a su pose
		transform.position = posic;
		
	}
}
