using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Highscore : MonoBehaviour {
	public Text text;
	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Best: " + PlayerPrefs.GetInt ("HighScore");
		if (GameController.Instance.getScore() > PlayerPrefs.GetInt("HighScore")){
			PlayerPrefs.SetInt ("HighScore", GameController.Instance.getScore());
		}
		if (PlayerPrefs.GetInt ("score") > PlayerPrefs.GetInt ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", PlayerPrefs.GetInt ("score"));
		}
	}
}
