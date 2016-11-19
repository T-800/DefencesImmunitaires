using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;
public class SpecialisationB : FSystem {
	public GameObject bac;
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family _controllGO = FamilyManager.getFamily(new AllOfComponents(typeof(TempsContact), typeof(Triggered2D)));

	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		foreach (GameObject go in _controllGO) {
			Triggered2D t2d = go.GetComponent<Triggered2D> ();
			TempsContact tc = go.GetComponent<TempsContact> ();
			foreach(GameObject target in t2d.Targets){

			
				// Trouver une solution plus efficace que les tags.
				// il faut aussi rajouter les virus infectées et les bactéries.
				//or target.gameObject.Equals("Virus") !! Faut voir si annelisse a fait virus.

				if (target.gameObject.GetComponent<Secreter>() != null && target.gameObject.GetComponent<Secreter>().type.Equals ("Toxines")) {
					if (tc.temp == 0) {
						GameObjectManager.removeComponent<TempsContact>(go);
						GameObjectManager.addComponent (go, typeof(Specialisation), new { type = "Bacterie"});
						GameObjectManager.addComponent (go, typeof(Secreter), new { type = "Anticorps"});
						SpriteRenderer sprit;
						sprit = go.GetComponent<SpriteRenderer> ();
						Sprite s = (Sprite)Resources.Load("LymPhoBBacterie", typeof(Sprite));
						sprit.sprite = s;
					} else {						
						tc.temp--;					
					}
				}


				if (target.gameObject.GetComponent<Infecteur> ()) {
					if (tc.temp == 0) {
						GameObjectManager.removeComponent<TempsContact>(go);
						GameObjectManager.addComponent (go, typeof(Specialisation), new { type = "Virus"});
						GameObjectManager.addComponent (go, typeof(Secreter), new { type = "Anticorps"});
						SpriteRenderer sprit;
						sprit = go.GetComponent<SpriteRenderer> ();
						Sprite s = (Sprite)Resources.Load("LymPhoBVirale", typeof(Sprite));
						sprit.sprite = s;
					} else {						
						tc.temp--;					
					}
				}
			}
		}
	}


}