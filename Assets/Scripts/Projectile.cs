using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public int d;
	private LevelManager lm;
	// Use this for initialization
	void Start () {
		d = 0;
		lm = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			d = 1;
			lm.RespawnPlayer ();
		}
	}
}
