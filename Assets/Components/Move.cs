using UnityEngine;

public class Move : MonoBehaviour {
	public float vitesse = 7f;
	public float coefv = 1f;
	// Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
	public void setcoefv(float i){
		coefv = i;
	}

}