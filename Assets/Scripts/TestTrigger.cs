using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour {
	public int AIzone;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			AIzone = 1;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") 
		{
			AIzone = 0;
		}
	}
}
