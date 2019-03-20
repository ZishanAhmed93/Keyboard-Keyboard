using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int score;
	public static GameController Instance;

	public void Awake()
	{
		if (Instance == null){
			DontDestroyOnLoad (gameObject);
			Instance = this;
		}

		else Destroy (gameObject);
	}

	// Use this for initialization
	void Start ()
	{

	}

	public void setScore(int s){
		score = s;
	}

	public int getScore(){
		return score;
	}

	public void increaseScore(int s){
		score += s;
	}

	public void increaseScore(){
		increaseScore(1);
	}
	/*
	a c4 -4.5
	s d4 -3.75
	d e4 -3
	f f4 -2.25
	g g4 -1.5
	h a4 -.75
	j b4 0
	j c5 .75
	k d5 1.5
	l e5 2.25
	; f5 3
	*/
	/*
	public string[] keys = {'a', 's', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', ';'}

		public float xPos = -3.5F;
	public float yPos;
	public float key;

	for(i=0; i<11; i++){
		yPos =(-4.5F + (i * 0.75F) );
		key = keys[i];

		//construct player with xPos, yPos, and key

	}

	//track collision time to determine score	
	if (col.gameObject.tag == "Player") {

		timeEnter = Time.time;

	}

	*/
}
