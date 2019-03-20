using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public SpriteRenderer rend;

	public KeyCode key;
	public bool keyDown;
	public bool keyUp;

	public bool active = false;

	public GameObject noteObject;
	public AudioSource noteAudio;

	public float timeNoteEnter;
	public float timeNoteExit;
	public float timeNoteCollided;

	public float timeKeyDown;
	public float timeKeyUp;
	public float timeKeyHeld;

	public int scoreToAdd;

	// Use this for initialization
	void Start () {

		//if (key == "" || key == null) setKey ();
		if (rend == null) rend = GetComponent<SpriteRenderer>();
		if(noteAudio == null) noteAudio = GetComponent<AudioSource>();
	
		rend.enabled = false;
	}
		
	// Update is called once per frame
	void Update () {

		keyDown = Input.GetKeyDown (key);
		keyUp = Input.GetKeyUp (key);

		if (keyDown){
			if (!noteAudio.isPlaying)
				noteAudio.Play ();
			rend.enabled = true;
			timeKeyDown = Time.time;
		}
		if (keyUp) {
			noteAudio.Stop ();
			rend.enabled = false;

			//causing scoring malfunction
			//Destroy (noteObject);

			timeKeyUp = Time.time;
			timeKeyHeld = timeKeyUp - timeKeyDown;
			calculateScore ();
		}
	}

	void FixedUpdate () {
	
	}
		
	//track collision time to determine score	
	void OnTriggerEnter2D (Collider2D col) {
		active = true;
		if (col.gameObject.tag == "Note") {
			timeNoteEnter = Time.time;
			noteObject = col.gameObject;
		}
	}
	void OnTriggerExit2D(Collider2D col) {
		active = false;

		timeNoteExit = Time.time;
		timeNoteCollided = timeNoteExit - timeNoteEnter;
		calculateScore ();
	}
	void calculateScore() {
//		if (timeKeyHeld > 0.0F && timeNoteCollided == 0.0F) {
//			//player pressed key with no note
//		}
		//else 
		if(timeNoteCollided != 0 && timeKeyHeld !=0){

			float keyDownAccuracy = (1.0F - (Mathf.Abs(timeKeyDown - timeNoteEnter)) );
			if (keyDownAccuracy > 1.0F)
				keyDownAccuracy = 0.0F;

			float keyUpAccuracy = (1.0F - (Mathf.Abs(timeKeyUp - timeNoteExit)) );
			if (keyUpAccuracy > 1.0F)
				keyUpAccuracy = 0.0F;
			
			//returns a number between 1.0 and 0.0, 1.0 max
			float durationAccuracy = (1.0F - (Mathf.Abs( (timeKeyHeld/timeNoteCollided) - 1 ) ) );

			//calculates the score, weighs durartion accuracy as half the score, key down and up accuracy as a quarter each
			scoreToAdd = Mathf.RoundToInt((10.0F * ( (durationAccuracy * 0.5F) + (keyDownAccuracy * 0.25F) + (keyUpAccuracy * 0.25F))));

			if(scoreToAdd < 0) scoreToAdd = 0;

//			Debug.Log ("timekeyheld " + timeKeyHeld);
//			Debug.Log ("timenoteCollided " + timeNoteCollided);
//			Debug.Log ("KeyHeld/NoteCollided is " + timeKeyHeld / timeNoteCollided);
//			Debug.Log ("abs keyheld/notecollided is " + (Mathf.Abs(timeKeyHeld/timeNoteCollided)) );
//			Debug.Log ("abs keyheld/notecollided - 1 is " + (Mathf.Abs(timeKeyHeld/timeNoteCollided) - 1.0F) );
//			Debug.Log ("abs 1 - keyheld/notecollided - 1 is " + (1.0F - (Mathf.Abs(timeKeyHeld/timeNoteCollided) - 1.0F) ) );						
//			Debug.Log ("durationaccuracy " + durationAccuracy);

			Debug.Log ("scoretoadd " + scoreToAdd);
			//send scoreToAdd to global score;	

			GameController.Instance.increaseScore (scoreToAdd);


			timeKeyHeld = 0.0F;
			timeNoteCollided = 0.0F;



		}
	}

	/*
	void setKey() {

		if (transform.position.y == 0.00F) key = "j";
		else if (transform.position.y < 0.00F) {

			if (transform.position.y == -2.25F) key = "f";
			else if (transform.position.y < -2.25F) {

				if (transform.position.y == -4.5F) key = "a";
				else if (transform.position.y == -3.75F) key = "s";
				else if (transform.position.y == -3.00F) key = "d";

				else Debug.Log ("Unknown y position, key not set");

			} else {

				if (transform.position.y == -1.5F) key = "g";
				else if (transform.position.y == -0.75F) key = "h";

				else Debug.Log ("Unknown y position, key not set");
			}
		}
		else if (transform.position.y > 0.00F) {

			if (transform.position.y == 0.75F) key = "k";
			else if (transform.position.y == 1.5F) key = "l";
			else if (transform.position.y == 2.25F) key = ";";
			else if (transform.position.y == 3.00F) key = "'";

			else Debug.Log ("Unknown y position, key not set");

		}

		else Debug.Log ("Unknown y position, key not set");
	}
	*/
}