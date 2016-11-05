using UnityEngine;
using FYFY;

public class SecretionGRAnticorps : FSystem {
	public int ATSecreter = 0;
	public GameObject tox;
	private float reloadTime = 3f;
	private float reloadProgress = 0f;
	private Bounds BactSize;
	public float x;
	public float y;
	public float z;
	private Family _controllGO = FamilyManager.getFamily(new AllOfComponents(typeof(Secreter),typeof(Move),typeof(StreamMove)));
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
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

			if (ATSecreter == 3) {
				Debug.Log ("j'ai fait 3");
				new WaitForSecondsRealtime (100f);
				ATSecreter = 0;
			}
			if (reloadProgress >= reloadTime){
				BactSize = go.GetComponent<Renderer>().bounds;
				if (ATSecreter < 3) {
					


					 x = Random.Range (BactSize.min.x, BactSize.max.x);
					 y = Random.Range (BactSize.min.y, BactSize.max.y);
					 z = 0.0f;

					Vector3 toxPosition = new Vector3 (x, y, z);

					tox = GameObjectManager.instantiatePrefab("Anticorps");
					tox.transform.position = toxPosition;
					ATSecreter = ATSecreter + 1;
				}

				reloadProgress = 0;
			}

		}
	}
	}
