using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour {
	GameObject display;
	// Use this for initialization
	void Start () {
		display = GameObject.FindWithTag ("Panel");
		display.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x <= -20.0f) {
			display.SetActive (true);
		}
			
	}

	public void Return(string scene){
		SceneManager.LoadScene (scene);
		display.SetActive(false);
	}
}

