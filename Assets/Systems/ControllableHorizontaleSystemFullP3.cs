
using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;

public class ControllableHorizontaleSystemFullP3 : FSystem  { 
	//Récuperer le joueur 3
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move)),new AllOfComponents(typeof(P3)),new AllOfComponents(typeof(Controllable))); 
 
	// Use this to update member variables when system pause.  
	// Advice: avoid to update your families inside this function. 
	protected override void onPause(int currentFrame)  { 
	 } 
 
	// Use this to update member variables when system resume. 
	// Advice: avoid to update your families inside this function. 
	protected override void onResume(int currentFrame) { 
	 } 
 
	// Use to process your families. 
	protected override void onProcess(int familiesUpdateCount)  { 
		foreach (GameObject go in _controllableGO)  { 
			Transform tr = go.GetComponent<Transform> (); 
			Move mv = go.GetComponent<Move> (); 
			int dir = go.GetComponent<P3>().dir; 
			Vector3 movement = Vector3.zero; 
 	//Ralentir
			if (dir != 0 && Input.GetKey (KeyCode.F) == true)  { 
				mv.coefv =0.9f; 
 
 
			 } 
			//Accelerer
			if (dir != 0 && Input.GetKey (KeyCode.H) == true)  { 
				mv.coefv =1.1f; 
 
			 } 
			//Monter en haut
			if (Input.GetKey (KeyCode.T) == true)  { 
				movement += Vector3.up; 
			 } 
			//Descendre
			if (Input.GetKey (KeyCode.G) == true)  { 
				movement += Vector3.down; 
			 }	 
	 
	 
			tr.position += movement * mv.vitesse * mv.coefd * mv.coefv * Time.deltaTime; 
 
		 } 
 
	 } 
}