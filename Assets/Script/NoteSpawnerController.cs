using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteSpawnerController : MonoBehaviour {

	Dictionary<string, float> posOfNote = new Dictionary<string, float>();
	private CountingController cc;
	public GameObject quarterNote;
	public GameObject halfNote;
	public GameObject wholeNote;
  	public GameObject nextSceneLoader;
	public string[] notesOfTwinkle = {"c4","c4","g4","g4","a4","a4","g4","f4","f4","e4","e4","d4","d4","c4","g4","g4","f4","f4","e4","e4","d4","g4","g4","f4","f4","e4","e4","d4","c4","c4","g4","g4","a4","a4","g4","f4","f4","e4","e4","d4","d4","c4"};
	public float[] yPosForNotes;
	public string[] durationOfNotes;
  	public float noteSpeed;
	public bool situation;

	// Use this for initialization
	void Start () {
		cc = GameObject.Find ("GameManager").GetComponent<CountingController> ();
		situation = false;
    //quarterNote.GetComponent<NoteSpriteController>().setSpeed(4.0F);
    //noteSpeed = quarterNote.GetComponent<NoteSpriteController>().getSpeed();
    //Debug.Log("speed is: " + noteSpeed);

		durationOfNotes = new string[]{"quarter", "quarter", "quarter", "quarter", "quarter", "quarter", "half", "quarter", "quarter", "quarter", "quarter", "quarter", "quarter", "half", "quarter", "quarter", "quarter", "quarter", "quarter", "quarter", "half", "quarter", "quarter", "quarter", "quarter", "quarter", "quarter", "half", "quarter", "quarter", "quarter", "quarter", "quarter", "quarter", "half", "quarter", "quarter", "quarter", "quarter", "quarter", "quarter", "half"};

		yPosForNotes = new float[notesOfTwinkle.Length];

		posOfNote.Add ("c4", -2.50F);
		posOfNote.Add ("d4", -1.75F);
		posOfNote.Add ("e4", -1.00F);
		posOfNote.Add ("f4", -0.25F);
		posOfNote.Add ("g4", 0.50F);
		posOfNote.Add ("a4", 1.25F);
		posOfNote.Add ("b4", 2.00F);
		posOfNote.Add ("c5", 2.75F);
		posOfNote.Add ("d5", 3.50F);
		posOfNote.Add ("e5", 4.25F);
		posOfNote.Add ("f5", 5.00F);

		for (int i = 0; i < notesOfTwinkle.Length; i++) {
			yPosForNotes[i] = posOfNote[notesOfTwinkle[i]];
		}


	}
	void Update(){
		while (situation == false && cc.counterDownDone == true){
			if(notesOfTwinkle.Length != durationOfNotes.Length){
				Debug.Log("Error incompatible number of notes and durations");
				Debug.Log("#ofNotes: " + notesOfTwinkle.Length);
				Debug.Log("#ofDurations: " + durationOfNotes.Length);
			}
			else if(notesOfTwinkle.Length != yPosForNotes.Length){
				Debug.Log("Error incompatible number of notes and positions");
				Debug.Log("#ofNotes: " + notesOfTwinkle.Length);
				Debug.Log("#ofNotes: " + yPosForNotes.Length);
			}
			else if(durationOfNotes.Length != yPosForNotes.Length){
				Debug.Log("Error incompatible number of durations and positions");
				Debug.Log("#ofDurations: " + durationOfNotes.Length);
				Debug.Log("#ofNotes: " + yPosForNotes.Length);
			}	
			else spawnNotes();
			situation = true;
		}
	}


	void spawnNotes () {
		
		int start = 0;
		int end = 0;

		if (SceneManager.GetActiveScene ().name == "Twinkle 0-3") {
			start = 0;
			end = 14;
		} else if (SceneManager.GetActiveScene ().name == "Twinkle 1-3") {
			start = 15;
			end = 28;
		} else if (SceneManager.GetActiveScene ().name == "Twinkle 2-3") {
			start = 29;
			end = notesOfTwinkle.Length;
		} else if (SceneManager.GetActiveScene ().name == "Twinkle Twinkle Little Star" || SceneManager.GetActiveScene ().name == "Twinkle Twinkle Little Star Money" || SceneManager.GetActiveScene ().name == "Twinkle Twinkle Little Star Object") {
			start = 0;
			end = notesOfTwinkle.Length;
		} else
			Debug.Log ("unknown scene");


		float j = 0;
		for (int i = start; i < end + 1; i++) {
			if (i == end) {
				Vector2 position = new Vector2 (((20.0F + j) + ((i - start) * 4.0F)), posOfNote ["g4"]);
				Instantiate (nextSceneLoader, position, Quaternion.identity);
			} else {
				Vector2 position = new Vector2 (((10.0F + j) + ((i - start) * 4.0F)), yPosForNotes [i]);

				if (durationOfNotes [i] == "quarter")
					Instantiate (quarterNote, position, Quaternion.identity);
				else if (durationOfNotes [i] == "half") {
					Instantiate (halfNote, position, Quaternion.identity);
					j += (2.5F);
				} else if (durationOfNotes [i] == "whole") {
					Instantiate (wholeNote, position, Quaternion.identity);
					j = (3 * (2.5F)); 
				}
			}
		}
	}

}