using UnityEngine;
using FYFY;

public class AntibioSystem : FSystem {
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
				GameObjectManager.removeComponent<Antibiotique> (go);
				at.transform.localScale = new Vector3 (1, 1, 1);
			} else {
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