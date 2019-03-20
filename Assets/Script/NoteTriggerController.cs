using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTriggerController : MonoBehaviour {

	public GameObject player;

	public float timeNoteEnter;
	public float timeNoteExit;

	public float timeKeyDown;
	public float timeKeyUp;

	// Use this for initialization
	void Start ()
	{
		//if (audio == null) audio = GetComponent<AudioSource> ();
	}

	//called at a fixed rate. Best for physics (e.g. movement)
	void FixedUpdate ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		//track collision time to determine score	
		if (col.gameObject.tag == "Player") {
		 

	
		}
	}

}
