using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class EndommagerSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.

	private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D), typeof(Endommage)));
	private float reloadTime = 10f;
	private float reloadProgress = 0f;

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

			foreach (GameObject target in t2d.Targets) {
				Leucocyte leucocyte = target.GetComponent<Leucocyte> ();
				HP hp1 = target.gameObject.GetComponentInChildren<HP> ();
				Absorbeur absorbe = target.GetComponent<Absorbeur> ();
				if (hp1 != null && leucocyte != null && absorbe == null) {
					Endommage endommage = go.GetComponent<Endommage> ();
					hp1.hp -= endommage.hpLost;
					endommage.hasEndommage = true;
				}

			}

		}

	}
}