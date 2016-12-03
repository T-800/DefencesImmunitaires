using UnityEngine;
using FYFY;

public class AntibioSystem : FSystem {
	//nous avons le component antibiotique
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Antibiotique)));

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
		foreach (GameObject go in _controllableGO) {
			Antibiotique at = go.GetComponent<Antibiotique> ();
			if (at.tempseffet == 0) {
				// si l'effet est fini on eneleve le component
				GameObjectManager.removeComponent<Antibiotique> (go);
				//Augmenter la taille de l'élement pour montrer l"effet de l'antibiotique
				at.transform.localScale = new Vector3 (1, 1, 1);
			} else {
				//Sur cette partie on rétrecie la taille de l'élement
				if (at.tempseffet < 30) {

					at.transform.localScale += new Vector3 (-0.2f, -0.2f, 0f);
				} else {
					at.transform.localScale += new Vector3 (0.1f, 0.1f, 0f);
				}
				at.tempseffet--;
			}

		}
	}
}