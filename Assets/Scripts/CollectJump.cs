using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectJump : MonoBehaviour {

	public int cjump =0;
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
			cjump = 1;
			collected.Play ();
			Destroy (gameObject);
		}
	}
}
