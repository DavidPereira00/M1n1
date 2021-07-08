using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour 
{
	[SerializeField] private GameObject pausePanel;
	public CameraController cm;
	void Start()
	{
		pausePanel.SetActive(false);
	}
	void Update()
	{
		if(Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (!pausePanel.activeInHierarchy) 
			{
				PauseGame();
			}
			if (pausePanel.activeInHierarchy) 
			{
				ContinueGame();   
			}
		} 
	}
	private void PauseGame()
	{
		Time.timeScale = 0;
		pausePanel.SetActive(true);
		Cursor.visible = true;
		cm.enabled = false;
		//Disable scripts that still work while timescale is set to 0
	} 
	private void ContinueGame()
	{
		Time.timeScale = 1;
		pausePanel.SetActive(false);
		cm.enabled = true;

		//enable the scripts again
	}
}