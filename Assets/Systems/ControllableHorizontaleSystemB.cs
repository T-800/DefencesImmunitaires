using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class ControllableHorizontaleSystemB : FSystem {
	//On récupére les élements qui peuvent bouger et qu'on controlle
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
			//Ici on accelere
			if (Input.GetKey (KeyCode.RightArrow) == true) {
				mv.coefv =1.1f;
			}
			//ici on diminue
			if (Input.GetKey (KeyCode.LeftArrow) == true) {
				mv.coefv =0.9f;
			}	
			if (Input.GetKey (KeyCode.D) == true) {
				mv.coefv =1.1f;
			}
			//ici on diminue
			if (Input.GetKey (KeyCode.Q) == true) {
				mv.coefv =0.9f;
			}	
			tr.position += movement * mv.vitesse * Time.deltaTime;
		}

	}
}