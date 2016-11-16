using UnityEngine;

public class RandomMoveFast : MonoBehaviour {
	// Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).

	public float reloadTime;
	public bool left;
	public float reloadProgress;
	// Use this for initialization
	void Start () {
		reloadTime = Random.Range (2f, 5f);
		left = Random.Range (0, 2) == 0;
		reloadProgress = 0f;
	}

	public void randomrange(){
		reloadTime = Random.Range (1f, 2f);
		left = Random.Range (0, 2) == 0;
		reloadProgress = 0f;
	}
}