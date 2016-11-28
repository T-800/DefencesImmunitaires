using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;
public class AbsorberSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.

	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D),typeof(Absorbeur), typeof(HP)));

	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _controllableGO) {
			Triggered2D t2d = go.GetComponent<Triggered2D> ();
			HP hp1 = go.GetComponent<HP> ();

			foreach (GameObject target in t2d.Targets) {
				IsAbsorbe isAbsorbe = target.GetComponent<IsAbsorbe> ();
				Absorbeur absorbeur = go.GetComponent<Absorbeur> ();

				if (isAbsorbe != null)
					continue;
				if (target.gameObject.CompareTag ("toxine")) {
					target.AddComponent<IsAbsorbe>();
					Debug.Log ("Absorbe : toxine " + go);
					hp1.hp -= absorbeur.hpLost;
				}
				else if (target.gameObject.CompareTag ("dechet")) {
					Debug.Log ("Absorbe : dechet " + go);
					target.AddComponent<IsAbsorbe>();
					hp1.hp -= absorbeur.hpLost;
				}
				else if (target.gameObject.CompareTag ("bacterie")) {
					Debug.Log ("Absorbe");
					target.AddComponent<IsAbsorbe>();
					target.gameObject.transform.GetChild(0).gameObject.AddComponent<IsAbsorbe>();
					hp1.hp -= absorbeur.hpLost;
				}
				else if (target.gameObject.CompareTag ("virus") && target.GetComponent<Agglutinué>() != null) {
					Debug.Log ("Absorbe");
					target.AddComponent<IsAbsorbe>();
					target.gameObject.transform.GetChild(0).gameObject.AddComponent<IsAbsorbe>();
					hp1.hp -= absorbeur.hpLost;
				}
			}
		}
	}
}