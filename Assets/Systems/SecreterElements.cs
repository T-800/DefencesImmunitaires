using UnityEngine;
using FYFY;

public class SecreterElements : FSystem {
	//public int Intervalle = 3;



	private Family _SecreterGO = FamilyManager.getFamily(new AllOfComponents(typeof(Secreter)));
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

		foreach (GameObject go in _SecreterGO) {
			if (go.GetComponent<Secreter>() != null && go.GetComponent<Secreter>().type.Equals("Anticorps")){
				Debug.Log ("Anticorps");
				Secreter sr = go.GetComponent<Secreter> ();
				sr.reloadProgress += Time.deltaTime;
				int NombreMaxSecretionSecreter = sr.NombreMaxSecretion;
				int NombreActuelleSecreter = sr.NombreActuelle; 
				if (NombreActuelleSecreter == NombreMaxSecretionSecreter) {
				new WaitForSecondsRealtime (30f);
					NombreActuelleSecreter = 0;
				}
				Bounds SecreteurSize = go.GetComponent<Renderer>().bounds;
				if (NombreActuelleSecreter < NombreMaxSecretionSecreter && sr.reloadProgress >= sr.reloadTime) {
					float x = Random.Range (SecreteurSize.min.x, SecreteurSize.max.x);
					float y = Random.Range (SecreteurSize.min.y, SecreteurSize.max.y);
					float z = 0.0f;
					Vector3 ElementPosition = new Vector3 (x, y, z);
					if (go.GetComponent<Specialisation> () != null && go.GetComponent<Specialisation> ().type.Equals ("Bacterie")) {
						GameObject Element = GameObjectManager.instantiatePrefab (sr.type);
						Element.transform.position = ElementPosition;
						NombreActuelleSecreter = NombreActuelleSecreter + 1;
						GameObjectManager.addComponent (Element, typeof(Specialisation), new { type = "Bacterie"});
						GameObjectManager.addComponent (Element, typeof(Ralentir));
					}
					if (go.GetComponent<Specialisation> () != null && go.GetComponent<Specialisation> ().type.Equals ("Virus")) {
						GameObject Element = GameObjectManager.instantiatePrefab (sr.type);
						Element.transform.position = ElementPosition;
						NombreActuelleSecreter = NombreActuelleSecreter + 1;
						GameObjectManager.addComponent (Element, typeof(Specialisation), new { type = "Virus"});
						GameObjectManager.addComponent (Element, typeof(Ralentir));
						GameObjectManager.addComponent (Element, typeof(Agglutinué));
					}
					sr.reloadProgress = 0;
				}
			}



			if (go.GetComponent<Secreter>() != null && go.GetComponent<Secreter>().type.Equals("Toxine")){
				
				Secreter sr = go.GetComponent<Secreter> ();
				sr.reloadProgress += Time.deltaTime;
				int NombreMaxSecretionSecreter = sr.NombreMaxSecretion;
				int NombreActuelleSecreter = sr.NombreActuelle; 
				if (NombreActuelleSecreter == NombreMaxSecretionSecreter) {
					new WaitForSecondsRealtime (300f);
					NombreActuelleSecreter = 0;
				}
				Bounds SecreteurSize = go.GetComponent<Renderer>().bounds;
				if (NombreActuelleSecreter < NombreMaxSecretionSecreter && sr.reloadProgress >= sr.reloadTime) {
					float x = Random.Range (SecreteurSize.min.x - 0.5f , SecreteurSize.max.x + 0.5f);
					float y = Random.Range (SecreteurSize.min.y - 0.5f, SecreteurSize.max.y + 0.5f);
					float z = 0.0f;
					Vector3 ElementPosition = new Vector3 (x, y, z);

						GameObject Element = GameObjectManager.instantiatePrefab (sr.type);
						Element.transform.position = ElementPosition;
						NombreActuelleSecreter = NombreActuelleSecreter + 1;
					sr.reloadProgress = 0;
				}
			}
		}
	}
}