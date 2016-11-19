using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class ApoptoseSystem : FSystem {

	private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D), typeof(Apoptose)));

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

		foreach (GameObject go in _triggeredGO) {
			Triggered2D t2d = go.GetComponent<Triggered2D> ();
			Debug.Log ("go : " +  go);

			foreach (GameObject target in t2d.Targets) {
				Debug.Log ("target : " +  target);


				IsInfecte isInfecte = target.GetComponent<IsInfecte> ();
				if (isInfecte != null) {
					Debug.Log (target + " : IsApoptose !");
					target.AddComponent<IsApoptose>();
				}

			}

		}


	}
}