using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setVolume : MonoBehaviour {
	// Use this for initialization
	void Start () {
		AudioListener.volume = PlayerPrefs.GetFloat ("music");
	}

}
