using UnityEngine;
using FYFY;

public class EnvironnementDroitSystem : FSystem {

	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move),typeof(Transform)));

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
			Transform tr = go.GetComponent<Transform> ();
			float po = Time.time;
			go.GetComponent<Move>().vitesse = 10 + 2*Mathf.Sin(po/4) + Mathf.Sin(po/4 -0.2f);
			tr.position += go.GetComponent<Move>().coefd * go.GetComponent<Move>().coefv * Vector3.right * go.GetComponent<Move>().vitesse  * Time.deltaTime;
		}

	}
}