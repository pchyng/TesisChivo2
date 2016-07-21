using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.IO;
using System.Text;


[RequireComponent(typeof(AudioSource))]
public class PrincipeVueScript : MonoBehaviour {
	public float maxSpeed = 100f;
	public float dereSpeed =0f;
	public float jumpForce =1f;
	public double timer =1f;
	public float hitVol  = 0.5f;
	
	public AudioClip crashHard;
	public AudioClip Galleta;
	private AudioSource source;
	
	
	bool didFlap = false;
	public float deathCooldown;
	
	Animator animator;
	Animator animator2;
	
	
	public bool muerte =false;
	public bool powerStar = false;
	public bool powerShield = false;
	int psCounter = 0;
	public bool powerVida = false;
	public bool powerClock = false;
	
	float psCoolDown = 0f;
	// Use this for initialization
	
	
	void Start () {
		animator = transform.GetComponentInChildren<Animator> ();
		
		if (animator == null) {
			Debug.LogError("No cambia la animacion");
		}
		
		AudioSource source2 = GameObject.Find("Camara").GetComponent<AudioSource>();
		AudioSource source3 = GameObject.Find("Jugador").GetComponent<AudioSource>();
		
		//AQUI ESTOY LEYENDO LA CONFIGURACION		
		var lConfigCollection = ConfigManager.Load(Path.Combine(Path.Combine(Application.dataPath,"Scores"),"config.xml"));
		
		//cONGIFURANDO SONIDO, VALORES PERMITIDOS EN config.xml true = un-mute & false = mute
		var lStatus = lConfigCollection.getConfigs (0).Status;
		source2.mute=!lStatus;
		source3.mute=!lStatus;
		
		
	}
	//Aqui son los graficos mas las entrada(Update is called once per frame)
	void Update () {
		
		if (powerStar) {
			GameObject.Find("UpM2").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("StarM1").GetComponent<SpriteRenderer>().enabled = true;
			psCoolDown += Time.deltaTime;
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
				didFlap = true;
			}
			if (timer > 2.5) {
				timer += (Time.deltaTime * .1000);
				dereSpeed += 0.01f;
				
			}
			Debug.LogWarning(psCoolDown);
			
			if (psCoolDown >= 15f) {
				powerStar=false;
				psCoolDown=0.0f;
				GameObject.Find("UpM2").GetComponent<SpriteRenderer>().enabled = false;
				GameObject.Find("StarM1").GetComponent<SpriteRenderer>().enabled = false;
			}
		}else{
			if (muerte) {
				deathCooldown -= Time.deltaTime;
				if (deathCooldown <= 0) {
					if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
						Application.LoadLevel (Application.loadedLevel);
						
					}
				}
			} else {
				
				if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
					didFlap = true;
				}
				if (timer > 2.5) {
					timer += (Time.deltaTime * .1000);
					dereSpeed += 0.01f;
					
				}
			}
		}
		
		if (powerShield) {
			if(psCounter==0){
				psCounter=2;
			}
			GameObject.Find ("UpM3").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find("CascoM1").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.Find("PowerExploC02").GetComponent<SpriteRenderer>().enabled = true;
			
		} else {
			GameObject.Find("UpM3").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("CascoM1").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("PowerExploC02").GetComponent<SpriteRenderer>().enabled = false;
		}
		
		if (powerVida) {
			GameObject.Find ("UpM1").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find("VidaM1").GetComponent<SpriteRenderer>().enabled = true;
		} else {
			GameObject.Find("UpM1").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("VidaM1").GetComponent<SpriteRenderer>().enabled = false;
		}
		
		
		
	}
	
	// Aqui para los frame y motores de fisica
	void FixedUpdate () {
		if (muerte) {
			return;
		}
		
		Rigidbody2D myRB2D = GetComponent<Rigidbody2D> ();
		myRB2D.AddForce (Vector2.right * dereSpeed);
		
		
		
		
		
		if (didFlap) {
			myRB2D.AddForce(Vector2.up * jumpForce);
			//Debug.LogWarning("Esta Saltando");
			animator.SetTrigger("SueloP");
			didFlap = false;
			
		}
		
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
	void OnTriggerEnter2D(Collider2D  collision) {
		if (collision.gameObject.name == "Monstruos" || collision.gameObject.tag == "Monstruos") {
			if(powerStar){
				source = GetComponent<AudioSource>();
				source.PlayOneShot(crashHard,hitVol);
			}else{
				if(powerShield){
					psCounter=psCounter-1;
					if(psCounter==0){
						powerShield=false;
					}
					//Audio vidrios rotos
					source = GetComponent<AudioSource>();
					source.PlayOneShot(crashHard,hitVol);
					DestroyObject(collision.gameObject);
					int aux = GameObject.Find("Monstruos").GetComponent<GeneraMonstr>().actualMonsterNumber;
					GameObject.Find("Monstruos").GetComponent<GeneraMonstr>().actualMonsterNumber = aux-1;
					
				}else{
					if(powerVida){
						powerVida=false;
					}else{
						
						animator.SetTrigger ("GolpeP");
						muerte = true;
						timer =45f;
						dereSpeed =3f;
						deathCooldown = 0.5f;
						
						source = GetComponent<AudioSource>();
						source.PlayOneShot(crashHard,hitVol);
					}
				}
			}
			
			
		}
		
		if (collision.gameObject.name == "Obstaculos" || collision.gameObject.tag == "Obstaculos") {
			if(powerStar){
				source = GetComponent<AudioSource>();
				source.PlayOneShot(crashHard,hitVol);
				
				//animator2 = collision.gameObject.GetComponentInChildren<Animator> ();
				//animator2.SetTrigger ("GolpeP");
				
				DestroyObject(collision.gameObject);
				int aux = GameObject.Find("Obstaculos").GetComponent<GeneraRocas>().actualMonsterNumber;
				GameObject.Find("Obstaculos").GetComponent<GeneraRocas>().actualMonsterNumber = aux-1;
				
			}else{
				if(powerShield){
					psCounter-=1;
					if(psCounter==0){
						powerShield=false;
					}
					//Audio vidrios rotos
					source = GetComponent<AudioSource>();
					source.PlayOneShot(crashHard,hitVol);
					DestroyObject(collision.gameObject);
					int aux = GameObject.Find("Obstaculos").GetComponent<GeneraRocas>().actualMonsterNumber;
					GameObject.Find("Obstaculos").GetComponent<GeneraRocas>().actualMonsterNumber = aux-1;
				}else{
					if(powerVida){
						powerVida=false;
					}else{
						
						animator.SetTrigger ("GolpeP");
						muerte = true;
						timer =45f;
						dereSpeed =3f;
						deathCooldown = 0.5f;
						
						source = GetComponent<AudioSource>();
						source.PlayOneShot(crashHard,hitVol);
					}
				}
			}
		}
		
		if (collision.gameObject.name == "Galletas" || collision.gameObject.tag == "Galleta") {
			source = GetComponent<AudioSource>();
			source.PlayOneShot(Galleta,hitVol);
		}
		
		if (collision.gameObject.name == "CakeM1" || collision.gameObject.tag == "PowerStar") {
			powerStar=true;
			powerShield=false;
			psCoolDown=0f;
			source = GetComponent<AudioSource>();
			source.PlayOneShot(Galleta,hitVol);
			//TODO: animacion activar
		}
		
		if (collision.gameObject.name == "PowerShield" || collision.gameObject.tag == "PowerShield") {
			if(!powerStar){
				powerShield=true;
				source = GetComponent<AudioSource>();
				source.PlayOneShot(Galleta,hitVol);
				//TODO: animacion activar
			}
		}
		
		if (collision.gameObject.name == "VidaM1" || collision.gameObject.tag == "PowerVida") {
			powerVida=true;
			source = GetComponent<AudioSource>();
			source.PlayOneShot(Galleta,hitVol);
			//TODO: animacion activar
		}
		
		if (collision.gameObject.name == "pExplode" || collision.gameObject.tag == "PowerTimer") {
			//powerVida=true;
			source = GetComponent<AudioSource>();
			source.PlayOneShot(Galleta,hitVol);
			//TODO: animacion activar
		}
	}
	
	
}

