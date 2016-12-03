using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class InfecterSystem : FSystem {
	//Récupérer les éléments qui peuvent infecter
	private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D), typeof(Infecteur)));



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
			//Récupérer les élements qui rentrent en collision
			Triggered2D t2d = go.GetComponent<Triggered2D> ();
			//Vérifier que le target peut être agglutinés
			if (go.GetComponent<Agglutinué> () != null) {
				Debug.Log (go+" aggl");
				continue;
			}
			foreach (GameObject target in t2d.Targets) {
				//On lui rajoute le leucocyte  IsInfacble et Isinfecte comme component
				Leucocyte leucocyte = target.GetComponent<Leucocyte> ();
				IsInfectable isInfectable = target.GetComponent<IsInfectable> ();
				IsInfecte infecte = target.GetComponent<IsInfecte> ();
				if ((isInfectable != null || leucocyte != null) && infecte == null) {
					target.AddComponent<IsInfecte>();
					//On lui change l'image pour représenter qu'il est infecté
					SpriteRenderer spriteRenderer; 
					spriteRenderer = target.GetComponent<SpriteRenderer>();
					Sprite s = (Sprite)Resources.Load(spriteRenderer.sprite.name+"_infected", typeof(Sprite));
					Debug.Log (s);
					spriteRenderer.sprite = s;
					Infecteur virus =  go.GetComponent<Infecteur>();
					virus.hasInfect = true;

					Debug.Log (target + " : est infecté !");
				}

			}

		}
	}
}