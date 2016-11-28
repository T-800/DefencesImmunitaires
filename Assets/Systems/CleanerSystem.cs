using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class CleanerSystem : FSystem {
	private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D), typeof(Cleaner)));
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
			//Debug.Log (go);
			Triggered2D t2d = go.GetComponent<Triggered2D> ();
			foreach (GameObject target in t2d.Targets) {
				if (target != null && !target.GetComponent<Wall> ()) {
					Debug.Log (target);
					if(target.gameObject.transform.parent)
						GameObjectManager.destroyGameObject (target.gameObject.transform.parent.gameObject);
					else GameObjectManager.destroyGameObject (target);
					//GameObjectManager.destroyGameObject (target);
				}
			}
		}

	}
}