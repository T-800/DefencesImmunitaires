using UnityEngine;
using FYFY;

public class GlobulesRougesFactory : FSystem {
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(FactoryG)));

	// Dans ce système on crée en random soit des globules rouges, virus, cellule infectable, bactérie.

	public float reloadProgressV = 0f;
	public float reloadTime = 0.50f;
	public float reloadProgressG = 0f;
	public int nombreMaxSecretionG = 20;
	public float reloadProgressB = 0f;
	public float reloadProgressC = 0f;

	public int cptbact = 0;
	public int cptglobule = 0;
	public int cptcelinf = 0;


	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
		reloadProgressB += Time.deltaTime;
		reloadProgressG += Time.deltaTime;
		reloadProgressV += Time.deltaTime;
		reloadProgressC += Time.deltaTime;
		foreach(GameObject go in _controllableGO){
			//Debug.Log("ici");
			if (go.GetComponent<FactoryG> ().globlat != -1 && go.GetComponent<FactoryG> ().globlat < reloadProgressG && cptglobule < go.GetComponent<FactoryG> ().nb_globlat) { 
				//Debug.Log("globule");
				Vector3 v3Pos = Camera.main.ViewportToWorldPoint (new Vector3 (-0.1f, Random.Range (0.3f, 0.7f), 1.0f));
				Vector3 ElementPosition = v3Pos;
				GameObject Element = GameObjectManager.instantiatePrefab ("Globule");
				Element.transform.position = ElementPosition;
				reloadProgressG = 0;
				cptglobule += 1;
			}
			if (go.GetComponent<FactoryG> ().bactlat != -1 && go.GetComponent<FactoryG> ().bactlat < reloadProgressB && cptbact < go.GetComponent<FactoryG> ().nb_bactlat) { 
				Vector3 v3Pos = Camera.main.ViewportToWorldPoint (new Vector3 (-0.1f, Random.Range (0.3f, 0.7f), 1.0f));
				Vector3 ElementPosition = v3Pos;
				GameObject Element = GameObjectManager.instantiatePrefab ("bacterie");
				Element.transform.position = ElementPosition;
				reloadProgressB = 0;
				cptbact += 1;
				//Debug.Log ("bact");
			}
			if (go.GetComponent<FactoryG> ().virlat != -1 && go.GetComponent<FactoryG> ().virlat < reloadProgressV) { 
				Vector3 v3Pos = Camera.main.ViewportToWorldPoint (new Vector3 (-0.1f, Random.Range (0.3f, 0.7f), 1.0f));
					Vector3 ElementPosition = v3Pos;
					GameObject Element = GameObjectManager.instantiatePrefab ("virus");
					Element.transform.position = ElementPosition;
				reloadProgressV = 0;
			}
			if (go.GetComponent<FactoryG> ().celinlat != -1 && go.GetComponent<FactoryG> ().celinlat < reloadProgressC && cptcelinf < go.GetComponent<FactoryG> ().nb_celinlat) { 
				Vector3 v3Pos = Camera.main.ViewportToWorldPoint (new Vector3 (-0.1f, Random.Range (0.3f, 0.7f), 1.0f));
				Vector3 ElementPosition = v3Pos;
				GameObject Element = GameObjectManager.instantiatePrefab ("CelluleInfectable");
				Element.AddComponent<IsInfecte>();
				/*SpriteRenderer spriteRenderer; 
				spriteRenderer = Element.GetComponent<SpriteRenderer>();
				Sprite s = (Sprite)Resources.Load(spriteRenderer.sprite.name+"_infected", typeof(Sprite));
				spriteRenderer.sprite = s;*/
				Element.transform.position = ElementPosition;
				reloadProgressC = 0;
				cptcelinf += 1;
				Debug.Log ("aze");
			}

		}


	}
}