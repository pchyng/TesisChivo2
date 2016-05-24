using UnityEngine;
using System.Collections;

public class pausaboton : MonoBehaviour {
	bool pausa = false;


	// Update is called once per frame
		/*public void onClick(){
			pausa = true;
			Time.timeScale = 0;
	
	}*/
	

	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {

			pausa = true;
			Time.timeScale = 1.0f-Time.timeScale;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
		}
		else if (Input.GetMouseButtonDown (0)) {

			pausa = false;
			Time.timeScale = 1;
			
		}
		
	}
}

