using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingDown : MonoBehaviour {
	private CountingController cc;

	public void setcount(){
		cc = GameObject.Find ("GameManager").GetComponent<CountingController> ();
		cc.counterDownDone = true;
	}
}
