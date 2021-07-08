using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int currentParts;
	public Text partsText;
	public int totalParts;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currentParts == totalParts) {
			SceneManager.LoadScene ("MainMenu");
		}
		if (Input.GetKey (KeyCode.L)) {
			currentParts = 15;
		}
	}
	public void AddParts(int partsToAdd)
	{
		currentParts += partsToAdd;
		partsText.text = "Parts: " + currentParts + "/" + totalParts;
	}

}
