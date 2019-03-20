using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseResume : MonoBehaviour {

	public GameObject[] displayWhenPlay;
	public GameObject[] displayWhenPaused;

	// Use this for initialization
	void Start () {

		displayWhenPlay = GameObject.FindGameObjectsWithTag ("showInPlayMode");
		displayWhenPaused = GameObject.FindGameObjectsWithTag ("showInPauseMode");

		//deactivate game objects that should only be displayed when game is paused
		foreach (GameObject g in displayWhenPaused)
			g.SetActive (false);

		//active game objects that should be displayed when game is in play mode
		foreach (GameObject g in displayWhenPlay)
			g.SetActive (true);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pause()

	{
		Time.timeScale = 0.0f;
		//activate paused items, deactivate play items


		foreach (GameObject g in displayWhenPaused)
			g.SetActive (true);

		foreach (GameObject g in displayWhenPlay)
			g.SetActive (false);
	}

	public void Resume()
	{
		Time.timeScale = 1.0f;
		//activate play items, deactivate pause items

		foreach (GameObject g in displayWhenPaused)
			g.SetActive (false);

		//active game objects that should be displayed when game is in play mode
		foreach (GameObject g in displayWhenPlay)
			g.SetActive (true);
	}

	public void GoToMenu()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("MainMenu");
	}

	public void skip(){
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("Choice");
	}
}
