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
						Specialisation spe = go.gameObject.transform.parent.gameObject.GetComponent<Specialisation> ();
						spe.type = "Bacterie";
						//GameObjectManager.addComponent (go.gameObject.transform.parent.gameObject, typeof(Specialisation), new { type = "Bacterie"});
						//GameObjectManager.addComponent (go.gameObject.transform.parent.gameObject, typeof(Secreter), new { type = "Anticorps"});
						// TODO: reduire le temps de reload  de secreter!!!!
						GameObjectManager.addComponent (go.gameObject.transform.parent.gameObject, typeof(Secreter), new { type = "Anticorps", reloadTime = 0.4f});
						SpriteRenderer sprit;
						sprit = go.gameObject.transform.parent.GetComponent<SpriteRenderer> ();
						Sprite s = (Sprite)Resources.Load("lymphocyteBBacterie", typeof(Sprite));
						sprit.sprite = s;
					} else {						
						tc.temp--;					
					}
				}


				if (target.gameObject.GetComponent<Infecteur> ()) {
					Debug.Log ("virus spé");
					if (tc.temp == 0) {
						GameObjectManager.removeComponent<TempsContact>(go);
						Specialisation spe = go.gameObject.transform.parent.gameObject.GetComponent<Specialisation> ();
						spe.type = "Virus";

						//GameObjectManager.addComponent (go.gameObject.transform.parent.gameObject, typeof(Specialisation), new { type = "Virus"});
						GameObjectManager.addComponent (go.gameObject.transform.parent.gameObject, typeof(Secreter), new { type = "Anticorps", reloadTime = 0.4f});
						//Secreter secr =go.gameObject.transform.parent.gameObject.GetComponent<Secreter> ();
						// TODO: reduire le temps de reload de secreter !!!!


						SpriteRenderer sprit;
						sprit = go.gameObject.transform.parent.GetComponent<SpriteRenderer> ();
						Sprite s = (Sprite)Resources.Load("lymphocyteBVirale", typeof(Sprite));
						sprit.sprite = s;
					} else {						
						tc.temp--;					
					}
				}
			}
		}
	}


}