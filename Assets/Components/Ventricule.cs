using UnityEngine;

public class Ventricule : MonoBehaviour {
	public GameObject cote1;
	public GameObject cote2;
	// Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).
	public GameObject getc1(){
		return cote1;
	}

	public GameObject getc2(){
		return cote2;
	}

}