using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;
using UnityEngine.SceneManagement;


public class EndLevelSystem : FSystem {
	//Ici on récupére le niveau actuelle
	private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D), typeof(Endlevel)));
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
		
		foreach (GameObject go in _triggeredGO){
			//On récupére les élements qui entrent en collision avec nous
			Triggered2D t2d= go.GetComponent<Triggered2D>();
			foreach (GameObject target in t2d.Targets) {
//Si l'élement est  un élement controlé par un joueur
				if (target.GetComponent<Controllable> () != null) {
					Debug.Log(go.GetComponent<Endlevel> ().currentLevel);
					//Une fois la on incremente le niveau actuelle pour aller au niveau prochain
					go.GetComponent<Endlevel> ().currentLevel += 1;
					//string next = string.Concat("Niveau" + go.GetComponent<Endlevel> ().currentLevel);
					//Debug.Log(go.GetComponent<Endlevel> ().currentLevel);
					if (go.GetComponent<Endlevel> ().currentLevel == -1 ) {
						Application.Quit ();
					}
					SceneManager.LoadScene(go.GetComponent<Endlevel> ().currentLevel);
				}


			}

		}
	}
}