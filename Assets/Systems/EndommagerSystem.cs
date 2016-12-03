using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class EndommagerSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	//On récupére les éléments qui peuvent endommager
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
			//Récupérer les élements qui peuvent être en collision
			Triggered2D t2d = go.GetComponent<Triggered2D> ();

			foreach (GameObject target in t2d.Targets) {
				Leucocyte leucocyte = go.GetComponent<Leucocyte> ();
				HP hp1 =  target.GetComponent<HP>();
				Absorbeur absorbe = target.GetComponent<Absorbeur> ();
				//Si l'élément n'est pas mort et que c'est un leucocyte et qu'il n'est pas un absorbeur
				if (hp1 != null && leucocyte != null && absorbe == null) {
					//on lui rajoute endommager
					Endommage endommage = go.GetComponent<Endommage> ();
					Debug.Log (hp1.hp);
					hp1.hp -= endommage.hpLost;
					/*if (hp1.hp <= 0)
						GameObjectManager.destroyGameObject (target);
					*/
					
				}

			}

		}

	}
}