using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour {

	public void LoadGame (string game){
		SceneManager.LoadScene (game);
	}

	public void Instructions()
	{
		SceneManager.LoadScene ("Instructions");
	}

	public void exit(){
		Application.Quit ();
	}

	public void reset(){
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.SetFloat ("music", 1.0f);
		PlayerPrefs.SetFloat ("Fx", 1.0f);
	}
		
}
