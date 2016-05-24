using UnityEngine;
using System.Collections;

public class PrincesaStatic : MonoBehaviour {
	public float maxSpeed = 100f;
	public float dereSpeed =0f;
	public float jumpForce =1f;
	public double timer =1f;
	public float hitVol  = 0.5f;
	
	public AudioClip crashHard;
	public AudioClip Galleta;
	private AudioSource source;
	
	

	public float deathCooldown;
	
	Animator animator;
	
	
	public bool muerte =false;
	
	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator> ();
		
		if (animator == null) {
			Debug.LogError("No cambia la animacion");
		}
	}
	//Aqui son los graficos mas las entrada(Update is called once per frame)
	void Update () {
	
	}
	
	// Aqui para los frame y motores de fisica
	void FixedUpdate () {
		if (muerte) {
			return;
		}
		
		Rigidbody2D myRB2D = GetComponent<Rigidbody2D> ();
		myRB2D.AddForce (Vector2.right * dereSpeed);

		
		if (myRB2D.velocity.y > 0) {
			transform.rotation = Quaternion.Euler(0,0,0);
		}else{
			//   float angle = Mathf.Lerp(0,-90, -myRB2D.velocity.y /10f );
			//   transform.rotation = Quaternion.Euler(0,0,angle);
		}
	}
	
	/*	void Awake () {
		
		source = GetComponent<AudioSource>();
	}
*/

}
