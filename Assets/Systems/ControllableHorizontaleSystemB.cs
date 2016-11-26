﻿using UnityEngine;
using FYFY;

public class ControllableHorizontaleSystemB : FSystem {

	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move)),new AllOfComponents(typeof(Controlable)));

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
			if (Input.GetKey (KeyCode.Right) == true) {
				mv.coefv =1.1;
			}
			if (Input.GetKey (KeyCode.Left) == true) {
				mv.coefv =0.9;
			}	

			tr.position += movement * mv.vitesse * Time.deltaTime;
		}

	}
}