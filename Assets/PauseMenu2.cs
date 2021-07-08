using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu2 : MonoBehaviour {

	public static bool GameIsPause = false;
	public CameraController cm;

	public GameObject pauseMenuUI;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameIsPause) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}
	public void Resume(){
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1;
		GameIsPause = false;
		Cursor.visible = false;
		cm.enabled = true;
	}
	void Pause(){
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0;
		GameIsPause = true;
		Cursor.visible = true;
		cm.enabled = false;

	}
	public void LoadMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}
	public void QuitGame(){
		Application.Quit ();
	}
}
