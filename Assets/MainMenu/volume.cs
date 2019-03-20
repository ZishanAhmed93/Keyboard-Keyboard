using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class volume : MonoBehaviour {

	public Slider [] volumes;
	public AudioSource [] music;
	GameObject display;

	void Start(){
		display = GameObject.FindWithTag ("Panel");
		display.SetActive (false);
		if(!PlayerPrefs.HasKey("music")){
			PlayerPrefs.SetFloat ("music", 1.0f);
		}

		if(!PlayerPrefs.HasKey("Fx")){
			PlayerPrefs.SetFloat ("Fx", 1.0f);
		}
	}

	void Update(){
		music[0].volume = PlayerPrefs.GetFloat ("music");
		volumes[0].value = PlayerPrefs.GetFloat ("music");
		for (int i = 1; i < 15; i++) {
			music [i].volume = PlayerPrefs.GetFloat ("Fx");
		}
		volumes [1].value = PlayerPrefs.GetFloat ("Fx");
	}


	public void GoToMenu()
	{
		SceneManager.LoadScene ("mainMenu");
	}

	public void MusicPrefs(){
		music[0].volume = volumes[0].value;
		PlayerPrefs.SetFloat ("music", volumes[0].value);
		PlayerPrefs.Save ();
	}

	public void FxPrefs(){
		for (int i = 1; i < 15; i++) {
			music[i].volume = volumes[1].value;
		}
		PlayerPrefs.SetFloat ("Fx", volumes[1].value);
		PlayerPrefs.Save ();
	}

	public void Setting(){
		display.SetActive (true);
	}

	public void Close(){
		display.SetActive (false);
	}
}
