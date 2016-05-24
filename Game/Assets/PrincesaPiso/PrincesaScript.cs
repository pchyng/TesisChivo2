using UnityEngine;
using System.Collections;

public class PrincesaScript : MonoBehaviour {
	Vector3 velocity= Vector3.zero;
	public float forwardSpeed = 1f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		velocity.x = forwardSpeed;

		
	}
}
