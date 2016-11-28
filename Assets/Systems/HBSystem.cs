using UnityEngine;
using FYFY;

public class HBSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents( typeof(HP)));

	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _controllableGO) {
			float hp = go.GetComponent<HP> ().hp;
			float hpMAX = go.GetComponent<HP> ().hpMAX;
			Vector3 spx = go.transform.localScale;
			float xi = hp / hpMAX;

			go.transform.localScale = new Vector3(xi, spx.y, spx.z);
		}
	
	}
}