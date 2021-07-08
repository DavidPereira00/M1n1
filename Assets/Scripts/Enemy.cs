using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float timeBtwShots;
	public float startTimeBtwShots;

	public GameObject projectile;
	public Transform player;
	public TestTrigger tt;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Helmet").transform;
		//tt = FindObjectOfType<TestTrigger> ();
		timeBtwShots = startTimeBtwShots;
		
	}
	void Update(){
		

		if (timeBtwShots <= 0 && tt.AIzone==1) {
				Instantiate (projectile, transform.position, Quaternion.identity);
				timeBtwShots = startTimeBtwShots;
			} else {
				timeBtwShots -= Time.deltaTime;
			}

	}


	/*void OnTriggerStay (Collider other) {
		if (other.CompareTag ("Player")) {
			if (timeBtwShots <= 0) {
				Instantiate (projectile, transform.position, Quaternion.identity);
				timeBtwShots = startTimeBtwShots;
			} else {
				timeBtwShots -= Time.deltaTime;
			}
		}
	}
	*/	
			
}
