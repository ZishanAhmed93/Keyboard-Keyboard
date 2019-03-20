using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayController : MonoBehaviour {

	public int score;
	public Text ScoreText;



	// Use this for initialization
	void Start () {
	
		if(ScoreText == null) ScoreText = GetComponent<Text>();

		score = GameController.Instance.getScore ();
		ScoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		score = GameController.Instance.getScore ();
		ScoreText.text = "Score: " + score;
		
	}
}
