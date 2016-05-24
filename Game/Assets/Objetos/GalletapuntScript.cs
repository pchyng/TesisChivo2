using UnityEngine;
using System.Collections;

public class GalletapuntScript : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public float dereSpeed =1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		velocity.x = dereSpeed;
	}
}
