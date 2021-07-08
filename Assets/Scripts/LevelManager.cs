using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	private PlayerController player;
	private Projectile pr;
	private Health health;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		pr = FindObjectOfType<Projectile> ();
		health = FindObjectOfType<Health> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void RespawnPlayer()
	{
		health.health = 3;
		//health.health = 3;
		Debug.Log ("Player Respawn");
		//		BHM.remove = 0;
		player.transform.position = currentCheckpoint.transform.position;
	}
}
