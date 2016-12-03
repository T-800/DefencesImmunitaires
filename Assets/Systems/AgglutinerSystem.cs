using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class AgglutinerSystem : FSystem {

	//on récupére les élements qui peuvent agglutiner
	private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D),typeof(Specialisation),typeof(Agglutinant)));

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
			Triggered2D t2D = go.GetComponent<Triggered2D> ();
			//pour chaque élément rentré en collision avec lui
			foreach (GameObject target in t2D.Targets) {
				//Si l'élement est infecté et pas encore agglutiné on lui rajoute un component agglutiné
				if (target.GetComponent<Infecteur>() != null && target.GetComponent<Agglutinué> () == null) {
					target.AddComponent<Agglutinué> ();
				}
			}
		}
	}

}