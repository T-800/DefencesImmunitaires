using UnityEngine;
using FYFY;

public class RandomMoveSystemVert : FSystem {

	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move)),new AnyOfComponents(typeof(RandomMoveAvg), typeof(RandomMoveFast)));



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
		foreach (GameObject go in _controllableGO) {

			RandomMoveAvg randomMoveAvg = go.GetComponent<RandomMoveAvg> ();
			RandomMoveFast randomMoveFast = go.GetComponent<RandomMoveFast> ();



			float time;
			float reloadProgress;
			bool left;


			if (randomMoveAvg != null) {
				time = randomMoveAvg.reloadTime;
				randomMoveAvg.reloadProgress += Time.deltaTime;
				reloadProgress = randomMoveAvg.reloadProgress;
				left = randomMoveAvg.left;
			} else {
				time = randomMoveFast.reloadTime;
				randomMoveFast.reloadProgress += Time.deltaTime;
				reloadProgress = randomMoveFast.reloadProgress;
				left = randomMoveFast.left;
			}


			if (reloadProgress >= time){
				if (randomMoveAvg != null) {
					randomMoveAvg.randomrange ();
				} else if (randomMoveFast != null) {
					randomMoveFast.randomrange ();
				}

			}
			Transform tr = go.GetComponent<Transform> ();
			Move mv = go.GetComponent<Move> ();

			Vector3 movement = Vector3.zero;

			if (left) {
				movement += Vector3.left;
			}
			else {
				movement += Vector3.right;
			}
			tr.position += movement * mv.vitesse * Time.deltaTime;

		}
	}
}