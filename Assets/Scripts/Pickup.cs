using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public int value;
	public AudioSource collected;
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
			FindObjectOfType<GameManager> ().AddParts (value);
			collected.Play ();
			Destroy (gameObject);
		}
	}
}
