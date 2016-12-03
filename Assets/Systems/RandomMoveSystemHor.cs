using UnityEngine;
using FYFY;

public class RandomMoveSystemHor : FSystem {
	//Pour les éléments qui peuvent bouger et randomly
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move),typeof(RandomMove)));



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
		//Faire des randoms move 
		foreach (GameObject go in _controllableGO) {

			RandomMove randomMoveAvg = go.GetComponent<RandomMove> ();



			float time;
			float reloadProgress;
			bool up;

			time = randomMoveAvg.reloadTimeUp;
			randomMoveAvg.reloadProgressUp += Time.deltaTime;
			reloadProgress = randomMoveAvg.reloadProgressUp;
			up = randomMoveAvg.up;


			if (reloadProgress >= time){
				if (randomMoveAvg != null) {
					randomMoveAvg.randomRangeUp ();
				}

			}
			Transform tr = go.GetComponent<Transform> ();
			Move mv = go.GetComponent<Move> ();

			Vector3 movement = Vector3.zero;

			if (up) {
				movement += Vector3.up * 0.2f;
			}
			else {
				movement += Vector3.down * 0.2f;
			}
			tr.position += movement * mv.vitesse * mv.coefd * mv.coefv * Time.deltaTime;

		}
	}
}