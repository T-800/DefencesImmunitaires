using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;
public class AbsorberSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.

	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D),typeof(Absorber)));

	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _controllableGO) {
			Triggered2D t2d = go.GetComponent<Triggered2D> ();
			HP hp1 = go.GetComponent<HP> ();

			foreach (GameObject target in t2d.Targets) {
				// Trouver une solution plus efficace que les tags.
				// il faut aussi rajouter les virus infectées et les bactéries.
				if (target.gameObject.CompareTag ("toxine")) {
					GameObjectManager.destroyGameObject (target);
					hp1.hp = hp1.hp - 1;
				}
			}
		}
	}
}