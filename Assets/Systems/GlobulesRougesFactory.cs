using UnityEngine;
using FYFY;

public class GlobulesRougesFactory : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.


	public float reloadTime = 0.50f;
	public float reloadProgress = 0f;
	public int NombreMaxSecretion = 10;


	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		reloadProgress += Time.deltaTime;
		if (reloadProgress >= reloadTime) {

			Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, Random.Range (0.1f, 0.9f), 1.0f));

			/*float x = Random.Range (SecreteurSize.min.x, SecreteurSize.max.x);
			float y = Random.Range (SecreteurSize.min.y, SecreteurSize.max.y);
			float z = 0.0f;*/
			Vector3 ElementPosition = v3Pos;
			GameObject Element = GameObjectManager.instantiatePrefab ("globuleRouge");
				Element.transform.position = ElementPosition;
				
			reloadProgress = 0;
		}


	}
}