using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class ApoptoseSystem : FSystem {
	//Récuperer les éléments qui peuvent apoptoser
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
			//on récupére les élements qui rentrent en collision 
			foreach (GameObject target in t2d.Targets) {
				Debug.Log ("target : " +  target);

				//Si l'élement qui rentre en collision avec est infecté
				IsInfecte isInfecte = target.GetComponent<IsInfecte> ();
				if (isInfecte != null) {
					Debug.Log (target + " : IsApoptose !");
					//On lui rajoute un component isApoptose
					target.AddComponent<IsApoptose>();
				}

			}

		}


	}
}