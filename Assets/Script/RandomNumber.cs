using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomNumber : MonoBehaviour {
	int number;
	void Start () {
		number = Random.Range (7, 10);

	}
	
	public void random(){
		SceneManager.LoadScene(number);
		Debug.Log (number);
	}
}
