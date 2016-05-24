using UnityEngine;
using System.Collections;

public class LogicalFlo : MonoBehaviour {

	Transform player;
	float offsetX;

	// Use this for initialization
	void Start () {
		GameObject player_obj = GameObject.FindGameObjectWithTag("Player");
		if(player_obj == null) {
			Debug.LogError("No se puede encontrar un objeto con el tag 'Player'!");
			return;
		}
		player = player_obj.transform;
		offsetX = transform.position.x - player.position.x;

	}
	
	// Update is called once per frame
	void Update () {
		if(player != null) {
			Vector3 posic = transform.position;
			posic.x = player.position.x + offsetX;
			transform.position = posic;
		}
	}
}
