using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;
public class AbsorberSystem : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	// On recupere les élements qui absorbent;
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D),typeof(Absorbeur)));

	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		//pour chaque élément absorbeur détecté 
		foreach (GameObject go in _controllableGO) {
			Triggered2D t2d = go.GetComponent<Triggered2D> ();
			// Comme absorber diminue le HP on le récupére dans le fils de l'élément
			HP hp1 = go.gameObject.GetComponentInChildren<HP> ();
			//On récupére tous les élements en collision
			foreach (GameObject target in t2d.Targets) {
				//on vérifie que l'élément a côté n'a pas été déja absorbé
				IsAbsorbe isAbsorbe = target.GetComponent<IsAbsorbe> ();
				Absorbeur absorbeur = go.GetComponent<Absorbeur> ();
				// s'il est en train d'être absorbé
				if (isAbsorbe != null)
					continue;
				  // si l'élement n'est pas encore été absorbé, si c'est une toxine

				if (target.gameObject.CompareTag ("toxine")) {
					//on lui rajoute le compononent "isAbsorbe"
					target.AddComponent<IsAbsorbe>();
					Debug.Log ("Absorbe : toxine " + go);
					//on diminue le hp 
					hp1.hp -= absorbeur.hpLost;
				}
				// si l'élement n'est pas encore été absorbé, si c'est une dechet
				else if (target.gameObject.CompareTag ("dechet")) {
					Debug.Log ("Absorbe : dechet " + go);
					target.AddComponent<IsAbsorbe>();
					hp1.hp -= absorbeur.hpLost;
				}
				// si l'élement n'est pas encore été absorbé, si c'est une bacterie
				else if (target.gameObject.CompareTag ("bacterie")) {
					Debug.Log ("Absorbe");
					target.AddComponent<IsAbsorbe>();
					//target.gameObject.transform.GetChild(0).gameObject.AddComponent<IsAbsorbe>();
					hp1.hp -= absorbeur.hpLost;
				}
				// si l'élement n'est pas encore été absorbé, si c'est un virus et qu'il n'est pas agglutiné
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