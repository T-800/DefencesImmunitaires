﻿using UnityEngine;
using FYFY;

public class ControllableVerticaleSystem: FSystem {
	//Récuperer les éléments qui peuvent bouger et qui sont controlées par le joueur
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
			//On peut aller a gauche
			if (Input.GetKey (KeyCode.LeftArrow) == true) {
				movement += Vector3.left;
			}
			//on peut aller à droite
			if (Input.GetKey (KeyCode.RightArrow) == true) {
				movement += Vector3.right;
			}
			//if (Input.GetKey (KeyCode.UpArrow) == true) {
			//	movement += Vector3.up;
			//}
			//if (Input.GetKey (KeyCode.DownArrow) == true) {
			//	movement += Vector3.down;
			//}	

			tr.position += movement * mv.vitesse * mv.coefd * mv.coefv * Time.deltaTime;
		}

	}
}
