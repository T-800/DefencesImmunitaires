using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class InfecterSystem : FSystem {

	private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D), typeof(Virus)));



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


				IsInfectable isInfectable = target.GetComponent<IsInfectable> ();
				Infecte infecte = target.GetComponent<Infecte> ();
				if (isInfectable != null && infecte == null) {
					target.AddComponent<Infecte>();

					SpriteRenderer spriteRenderer; 
					spriteRenderer = target.GetComponent<SpriteRenderer>();
					Sprite s = (Sprite)Resources.Load("macro_infected", typeof(Sprite));
					Debug.Log (s);
					spriteRenderer.sprite = s;
					Virus virus =  go.GetComponent<Virus>();
					virus.infect = true;

					Debug.Log (target + " : est infecté !");

				}

			}

		}
	}
}