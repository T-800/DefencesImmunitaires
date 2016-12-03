using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class RallentirSystem : FSystem {
	//On récupére les éléments qui peuvent se spécialiser et ralentir
	private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D),typeof(Specialisation),typeof(Ralentir)));

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
		foreach(GameObject go in _triggeredGO ){
			Triggered2D t2D = go.GetComponent<Triggered2D>();
			foreach (GameObject target in t2D.Targets) {
				if ( target.GetComponents<Move> () !=null ) {
					//Si l'élement peut secreter et qu'ils secretent Toxines et Bactéries
					if (target.GetComponent<Secreter> () != null && target.GetComponent<Secreter>().type.Equals("Toxines") && go.GetComponent<Specialisation> ().type.Equals ("Bacterie")) {

						target.GetComponent<Move> ().coefv = 0.8f;
					} else {
						//si l'élement secrete un virus alors on ralentie
						if (target.GetComponent<Infecteur> () != null && go.GetComponent<Specialisation>().type.Equals("Virus")) {
							
							target.GetComponent<Move> ().coefv = 0.8f;
						}
					}
				}
			}
		}
	}
}