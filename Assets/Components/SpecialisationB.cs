using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;
public class SpecialisationB : FSystem {
	public GameObject bac;
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family _controllGO = FamilyManager.getFamily(new AllOfComponents(typeof(Specialisation)));
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _controllGO) {
			Triggered2D t2d = go.GetComponent<Triggered2D> ();
			Debug.Log (t2d);
			if (t2d.Targets != null) {
				GameObject target = t2d.Targets[0];
					// Trouver une solution plus efficace que les tags.
					// il faut aussi rajouter les virus infectées et les bactéries.
					//or target.gameObject.Equals("Virus") !! Faut voir si annelisse a fait virus.
					if (target.gameObject.CompareTag ("Bactery")) {
						Debug.Log ("je suis la");
						GameObjectManager.destroyGameObject (go);
						bac = GameObjectManager.instantiatePrefab ("bCell_infected");

					}
				}
			}
		}

}