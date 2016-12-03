using UnityEngine;
using FYFY;

public class StreamMoveSystem : FSystem {

	//Prendre les éléments qui peuvent faire du StreamMove
	private Family _bloodStreamMovableGO = FamilyManager.getFamily (new AllOfComponents (typeof(Move), typeof(StreamMove)));

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
		//On fait bouger les éléments
		foreach (GameObject go in _bloodStreamMovableGO) {
			Transform tr = go.GetComponent<Transform> ();
			StreamMove mv = go.GetComponent<StreamMove> ();
			Vector3 movement = Vector3.zero;
			//Debug.LogError (go);
			movement += Vector3.right;
			tr.position += movement * mv.vitesse * Time.deltaTime;
		}
	}
}