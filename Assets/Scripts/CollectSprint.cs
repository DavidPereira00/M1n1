using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSprint : MonoBehaviour {


	public int sprint =0;
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
			sprint = 1;
			collected.Play ();
			Destroy (gameObject);
		}
	}
}
