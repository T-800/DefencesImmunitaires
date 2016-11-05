using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;


public class MortSystem : FSystem {


	private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D)));


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
			Virus virusC = go.GetComponent<Virus> ();
			HP hp1 =  go.GetComponent<HP>();
			IsApoptose isApoptose =  go.GetComponent<IsApoptose>();

			if (virusC != null && virusC.infect) { // mort des virus une fois qu'ils ont infecté qlqu'un
				GameObjectManager.destroyGameObject (go);
			}
			if (hp1 != null && hp1.hp <= 0) { // mort de toute entitées quand elle a plus d'HP
				GameObjectManager.destroyGameObject (go);
			}
			if (isApoptose != null) { // MORT APOPTOSE
				GameObjectManager.destroyGameObject (go);
			}


		}


	}
}