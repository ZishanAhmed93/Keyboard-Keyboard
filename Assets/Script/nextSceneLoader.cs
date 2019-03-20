using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextSceneLoader : MonoBehaviour {
	GameObject display;
	public Text text;
	private int score;
	// Use this for initialization
	void Start () {
		display = GameObject.FindWithTag ("Panel");
		display.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x <= 1.0f) {
			score = GameController.Instance.getScore ();
			display.SetActive (true);
			PlayerPrefs.SetInt ("score",score );
			text.text = score.ToString();
		}
		
	}


  
}
