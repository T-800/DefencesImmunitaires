
using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class ControllableHorizontaleSystemFullP1 : FSystem {
	//on recupére l'élement du joueur 
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move),typeof(P1),typeof(Controllable)));

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
			//P1 p = go.GetComponent<P1>();
			Vector3 movement = Vector3.zero;
			//Ici permet de ralentir
			if (Input.GetKey (KeyCode.LeftArrow) == true) {
				mv.coefv =0.9f;


			}
			//Ici permet d accélerer
			if (Input.GetKey (KeyCode.RightArrow) == true) {
				mv.coefv =1.1f;

			}
			//bouger en haut
			if (Input.GetKey (KeyCode.UpArrow) == true) {
				movement += Vector3.up;
			}
			//Bouger en bas
			if (Input.GetKey (KeyCode.DownArrow) == true) {
				movement += Vector3.down;
			}	
	
	
			tr.position += movement * mv.vitesse * mv.coefd * mv.coefv * Time.deltaTime;

		}

	}

}