using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public SpriteRenderer rend;
	public AudioSource noteAudio;

	void Start(){
		if (rend == null)
			rend = GetComponent<SpriteRenderer> ();
		if (noteAudio == null)
			noteAudio = GetComponent<AudioSource> ();
		rend.enabled = false;
	}
}
