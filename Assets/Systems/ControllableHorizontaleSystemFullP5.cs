
using UnityEngine;  
using FYFY;  
using FYFY_plugins.TriggerManager;  
  
public class ControllableHorizontaleSystemFullP5 : FSystem   {  
  
	private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move)),new AllOfComponents(typeof(P5)),new AllOfComponents(typeof(Controllable)));  
  
	// Use this to update member variables when system pause.   
	// Advice: avoid to update your families inside this function.  
	protected override void onPause(int currentFrame)   {  
	  }  
  
	// Use this to update member variables when system resume.  
	// Advice: avoid to update your families inside this function.  
	protected override void onResume(int currentFrame)  {  
	  }  
  
	// Use to process your families.  
	protected override void onProcess(int familiesUpdateCount)   {  
		foreach (GameObject go in _controllableGO)   {  
			Transform tr = go.GetComponent<Transform> ();  
			Move mv = go.GetComponent<Move> (); 
			Vector3 movement = Vector3.zero;   
			if (Input.GetKey (KeyCode.U) == true)   {  
				movement += Vector3.up;  
			  }  
			if (Input.GetKey (KeyCode.J) == true)   {  
				movement += Vector3.down;  
			  }	  
	  
	  
			tr.position += movement * mv.vitesse * mv.coefd * mv.coefv * Time.deltaTime;  
  
		  }  
  
	  }  
}