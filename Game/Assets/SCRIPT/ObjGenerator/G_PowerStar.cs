using UnityEngine;
using System.Collections;

public class G_PowerStar : MonoBehaviour {
	
	public GameObject[] _Items;
	public int range = 90;
	public float xFar = 80f;
	public bool noPoweStar = true;
	public float elapsetTime = 0f;
	
	float monsyMax = 14f;
	float monsyMin = -15.5f;
	
	void CreatePrefab()
	{
		GameObject player_obj = GameObject.FindGameObjectWithTag("Player");
		Transform player = player_obj.transform;
		Vector3 Playposic = player.position;
		
		GameObject clone = Instantiate(_Items[RandomNumber()])as GameObject;
		Transform tClone = clone.transform;
		Vector3 posic = tClone.position;
		
		posic.z = -2f;
		posic.x = Playposic.x + 80f; 
		posic.y = Random.Range(monsyMax,monsyMin);
		
		tClone.position = posic;
	}
	
	void Update (){
		int lrand = (int)(Random.Range (0, 100));
		elapsetTime = elapsetTime + Time.deltaTime;
		if (elapsetTime > 5) {
			if (noPoweStar && lrand > range) {
				CreatePrefab ();
				noPoweStar = false;
				elapsetTime=0;
			}else{
				elapsetTime=0;
			}
		}
	}
	
	int RandomNumber()
	{
		System.Random rand = new System.Random();
		return rand.Next(0,_Items.Length);
	}
}
