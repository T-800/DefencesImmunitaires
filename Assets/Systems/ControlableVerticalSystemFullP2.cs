﻿using UnityEngine;
using FYFY;

public class ControlableVerticalSystemFullP2 : FSystem {
	//Récuperer le joueur 2
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move),typeof(P2),typeof(Controllable)));

	// Use this to update member variables when system pause. \
	// Advice: avoid to update your families inside this function.\
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.\
	// Advice: avoid to update your families inside this function.\
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.\
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _controllableGO) {
			Transform tr = go.GetComponent<Transform> ();
			Move mv = go.GetComponent<Move> ();
			//P2 p = go.GetComponent<P2>();
			Vector3 movement = Vector3.zero;
			//Ralentir

			//Monter en haut
			if (Input.GetKey (KeyCode.Q) == true) {
				movement += Vector3.left;
			}
			//Descendre
			if (Input.GetKey (KeyCode.D) == true) {
				movement += Vector3.right;
			}

			tr.position += movement * mv.vitesse * mv.coefd * mv.coefv * Time.deltaTime;

		}

	}

}