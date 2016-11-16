using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class InfecterSystem : FSystem {

	private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D), typeof(Infecteur)), new NoneOfComponents(typeof(Agglutinué)));



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
			Triggered2D t2d = go.GetComponent<Triggered2D> ();

			foreach (GameObject target in t2d.Targets) {

				Leucocyte leucocyte = target.GetComponent<Leucocyte> ();
				IsInfectable isInfectable = target.GetComponent<IsInfectable> ();
				IsInfecte infecte = target.GetComponent<IsInfecte> ();
				if ((isInfectable != null || leucocyte != null) && infecte == null) {
					target.AddComponent<IsInfecte>();

					SpriteRenderer spriteRenderer; 
					spriteRenderer = target.GetComponent<SpriteRenderer>();
					Sprite s = (Sprite)Resources.Load("macro_infected", typeof(Sprite));
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