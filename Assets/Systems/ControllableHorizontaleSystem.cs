﻿using UnityEngine;
using FYFY;

public class ControllableHorizontaleSystem : FSystem {
	//On récupére tous les élements qui peuvent bouger et qu'on peut controller
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move)),new AllOfComponents(typeof(Controllable)));

	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _controllableGO) {
			Transform tr = go.GetComponent<Transform> ();
			Move mv = go.GetComponent<Move> ();

			Vector3 movement = Vector3.zero;

			//if (Input.GetKey (KeyCode.LeftArrow) == true) {
			//	movement += Vector3.left;
			//}
			//if (Input.GetKey (KeyCode.RightArrow) == true) {
			//	movement += Vector3.right;
			//}
			//Ils peuvent juste soit monter ou descendre
			if (Input.GetKey (KeyCode.UpArrow) == true) {
				movement += Vector3.up;
			}
			if (Input.GetKey (KeyCode.DownArrow) == true) {
				movement += Vector3.down;
			}	
			if (Input.GetKey (KeyCode.Z) == true) {
				movement += Vector3.up;
			}
			//ici on diminue
			if (Input.GetKey (KeyCode.S) == true) {
				movement += Vector3.down;
			}	

			tr.position += movement * mv.vitesse * mv.coefd * mv.coefv * Time.deltaTime;
		}

	}
}