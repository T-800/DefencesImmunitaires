using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour {

	public float reloadTimeLeft;
	public bool left;
	public float reloadProgressLeft;

	public float reloadTimeUp;
	public bool up;
	public float reloadProgressUp;

	// Use this for initialization
	void Start () {
		reloadTimeLeft = Random.Range (0.1f, 0.3f);
		left = Random.Range (0, 2) == 0;
		reloadProgressLeft = 0f;

		reloadTimeUp = Random.Range (0.1f, 0.3f);
		up = Random.Range (0, 2) == 0;
		reloadProgressUp = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void randomRangeLeft(){
		reloadTimeLeft = Random.Range (0.1f, 0.3f);
		left = Random.Range (0, 2) == 0;
		reloadProgressLeft = 0f;
	}

	public void randomRangeUp(){
		reloadTimeUp = Random.Range (0.1f, 0.3f);
		up = Random.Range (0, 2) == 0;
		reloadProgressUp = 0f;
	}
}
