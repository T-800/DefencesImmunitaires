using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByIndex (int scenetext){

		SceneManager.LoadScene (scenetext);
	}
		public void QuitterJeu (){
		#if UNITY_EDITOR 
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif




	
	}}