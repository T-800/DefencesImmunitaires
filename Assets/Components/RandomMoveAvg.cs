using UnityEngine;
using System.Collections;

public class RandomMoveAvg : MonoBehaviour {

	public float reloadTime;
	public bool left;
	public float reloadProgress;
	// Use this for initialization
	void Start () {
		reloadTime = Random.Range (2f, 5f);
		left = Random.Range (0, 2) == 0;
		reloadProgress = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void randomrange(){
		reloadTime = Random.Range (1f, 2f);
		left = Random.Range (0, 2) == 0;
		reloadProgress = 0f;
	}
}
