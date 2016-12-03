using UnityEngine;
using FYFY;

public class VentriculeSystem : FSystem {
	//On récupére les ventricules
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Ventricule)));

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
			//on fait comme une barriére pour passer
			GameObject c1 = go.GetComponent<Ventricule>().getc1 ();
			GameObject c2 = go.GetComponent<Ventricule>().getc2 ();
			if (Mathf.Sin (Time.time) > 0.6) {
				c1.transform.localScale += new Vector3 (0.0135f, 0f,0f);
				c2.transform.localScale += new Vector3 (0.0135f, 0f,0f);
			}
			if (Mathf.Sin (Time.time) < -0.6) {
				c1.transform.localScale += new Vector3 (-0.0135f, 0f,0f);
				c2.transform.localScale += new Vector3 (-0.0135f, 0f,0f);
			}

		}
	}
}