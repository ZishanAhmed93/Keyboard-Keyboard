using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D : MonoBehaviour {

	public SpriteRenderer rend;
	public GameObject displayB;
	public KeyCode key;
	public AudioSource noteAudio;
	public bool keyDown;
	public bool keyUp;


	void Start(){
		if (rend == null)
			rend = GetComponent<SpriteRenderer> ();
		if (noteAudio == null)
			noteAudio = GetComponent<AudioSource> ();
		rend.enabled = false;
		displayB = GameObject.FindWithTag ("ShowinB");
		displayB.SetActive (false);
	}

	void Update(){
		keyDown = Input.GetKeyDown (key);
		keyUp = Input.GetKeyUp (key);

		if (keyDown && displayB.activeInHierarchy == true){
			if (!noteAudio.isPlaying)
				noteAudio.Play ();
			rend.enabled = true;
			displayB.SetActive (false);
			Time.timeScale = 1.0F;
		}

		if (keyUp) {
			noteAudio.Stop ();
			rend.enabled = false;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		
		if (col.gameObject.tag == "Note") {
			Time.timeScale = 0.0F;
			displayB.SetActive (true);
		}
	}
		
}
