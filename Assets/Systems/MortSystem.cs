﻿using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;


public class MortSystem : FSystem {

	//On récupére tous les éléments qui peuvent bouger
	private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move)));
	private Bounds bound;
	public GameObject vir;

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
			bool tokill = false;
			//On vérifie tous les cas ou on peut mourrir, soit un infection par un virus etc...
			Infecteur virusC = go.GetComponent<Infecteur> ();
			HP hp1 = go.gameObject.GetComponentInChildren<HP> ();
			IsApoptose isApoptose =  go.GetComponent<IsApoptose>();
			IsAbsorbe isAbsorbe = go.GetComponent<IsAbsorbe> ();
			IsInfecte infecte = go.GetComponent<IsInfecte> ();
			Leucocyte leucocyte = go.GetComponent<Leucocyte> ();
			Secreter secreter = go.GetComponent<Secreter> ();
			if (virusC != null && virusC.hasInfect) { // mort des virus une fois qu'ils ont infecté qlqu'un
				Debug.Log ("MORT : virus a infecté " + go);
				tokill = true;
				//GameObjectManager.destroyGameObject (go);
			}
			if (hp1 != null && hp1.hp <= 0) { // mort de toute entitées quand elle a plus d'HP
				Debug.Log ("MORT : plus d'hp " + go);
				tokill = true;
				//GameObjectManager.destroyGameObject (go);
			}
			if (isApoptose != null) { // MORT APOPTOSE
				Debug.Log ("MORT : apoptose " + go);
				tokill = true;
				//GameObjectManager.destroyGameObject (go);
			}
			if (isAbsorbe != null) { // MORT absorbé
				Debug.Log ("MORT : absorbé " + go);
				tokill = true;
				//GameObjectManager.destroyGameObject (go);
			}
			if (leucocyte != null && tokill) {
				bound = go.GetComponent<Renderer>().bounds;
				for (int i = 0; i < 3; i++) {
					float x = Random.Range (bound.min.x - 0.5f, bound.max.x + 0.5f);
					float y = Random.Range (bound.min.y - 0.5f, bound.max.y + 0.5f);
					float z = 0.0f;

					Vector3 toxPosition = new Vector3 (x, y, z);

					vir = GameObjectManager.instantiatePrefab("Dechet");
					vir.transform.position = toxPosition;
				}
			}
			if (secreter != null && tokill) {
				bound = go.GetComponent<Renderer>().bounds;
				float x = Random.Range (bound.max.x, bound.max.x + 0.5f);
				float y = Random.Range (bound.max.y, bound.max.y + 0.5f);
				float z = 0.0f;

				Vector3 toxPosition = new Vector3 (x, y, z);

				vir = GameObjectManager.instantiatePrefab("Dechet");
				//vir.transform.position = toxPosition;
			}

			if (infecte != null && isAbsorbe == null && isApoptose == null && tokill) {
				Debug.Log ("dlibere VIrus : absorbé " + go);
				bound = go.GetComponent<Renderer>().bounds;
				for (int i = 0; i < 5; i++) {
					float x = Random.Range (bound.min.x, bound.max.x);
					float y = Random.Range (bound.min.y, bound.max.y);
					float z = 0.0f;

					Vector3 toxPosition = new Vector3 (x, y, z);

					vir = GameObjectManager.instantiatePrefab("Virus");
					vir.transform.position = toxPosition;
				}

			}
			if (tokill) {
				//if(go.gameObject.transform.parent.gameObject)
				//	GameObjectManager.destroyGameObject (go.gameObject.transform.parent.gameObject);
				//else 
					GameObjectManager.destroyGameObject (go);
			}



		}


	}
}