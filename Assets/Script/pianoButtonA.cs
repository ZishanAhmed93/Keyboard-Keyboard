using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pianoButtonA : MonoBehaviour {

	public Button button;
	public Color color;
	public Color ncolor;
	public KeyCode key;
	void Start(){
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(key)){
			changeColor ();
		}
		if(Input.GetKeyUp(key)){
			changeBack ();
		}
	}


	public void changeColor(){
		ColorBlock cb = button.colors;
		cb.normalColor = color;
		button.colors = cb;

	}

	public void changeBack(){
		ColorBlock cb = button.colors;
		cb.normalColor = ncolor;
		button.colors = cb;
	}
}