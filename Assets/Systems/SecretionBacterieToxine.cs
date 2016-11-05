using UnityEngine;
using FYFY;

public class SecretionBacterieToxine : FSystem {
	//public int Intervalle = 3;
	public int ToxineSecreter = 0;
	public GameObject tox;
	private float reloadTime = 3f;
	private float reloadProgress = 0f;
	private Bounds BactSize;

	private Family _controllGO = FamilyManager.getFamily(new AllOfComponents(typeof(Secreter)));
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
		
		foreach (GameObject go in _controllGO) {
			
			Secreter sr = go.GetComponent<Secreter> ();
			reloadProgress += Time.deltaTime;

			if (ToxineSecreter == 3) {
				Debug.Log ("j'ai fait 3");
				new WaitForSecondsRealtime (100f);
				ToxineSecreter = 0;

			}
			if (reloadProgress >= reloadTime){
				BactSize = go.GetComponent<Renderer>().bounds;
				if (ToxineSecreter < 3) {
					


					float x = Random.Range (BactSize.min.x, BactSize.max.x);
					float y = Random.Range (BactSize.min.y, BactSize.max.y);
					float z = 0.0f;
					Vector3 toxPosition = new Vector3 (x, y, z);
					Debug.Log (toxPosition);
					tox = GameObjectManager.instantiatePrefab("Toxines");
					tox.transform.position = toxPosition;
					ToxineSecreter = ToxineSecreter + 1;
				}
				reloadProgress = 0;
			}

		}
	}
}