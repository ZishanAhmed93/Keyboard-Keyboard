using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeinChoice : MonoBehaviour {

	public Slider volumes;
	public AudioSource [] music;
	GameObject display;

	void Start(){
		display = GameObject.FindWithTag ("Panel");
		display.SetActive (false);
		if(!PlayerPrefs.HasKey("Fx")){
			volumes.value = 1.0f;
		}
	}

	void Update(){
		for (int i = 0; i < 14; i++) {
			music [i].volume = PlayerPrefs.GetFloat ("Fx");
		}
		volumes.value = PlayerPrefs.GetFloat ("Fx");
	}


	public void GoToMenu()
	{
		SceneManager.LoadScene ("mainMenu");
	}


	public void FxPrefs(){
		for (int i = 0; i < 14; i++) {
			music[i].volume = volumes.value;
		}
		PlayerPrefs.SetFloat ("Fx", volumes.value);
		PlayerPrefs.Save ();
	}

	public void Setting(){
		display.SetActive (true);
	}

	public void Close(){
		display.SetActive (false);
	}
}

