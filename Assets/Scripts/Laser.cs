using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	LineRenderer laser;
	public TestTrigger tt;
	public Health h;
	public Distance dist;
	public float hif;
	public float timer;
	public PlayerController player;

	// Use this for initialization
	void Start () {
		laser = GetComponent<LineRenderer> ();
		//player = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (dist.distance > 7) {
			timer = 0;
			laser.enabled = false;
		}
		if (dist.distance <5) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.up * -1f, out hit)) {
				laser.SetPosition (0, transform.position);
				laser.SetPosition (1, hit.point);
				laser.enabled = true;
				Debug.Log (hit.collider);
				timer = timer + Time.deltaTime;
			}
			if (hit.collider.gameObject.tag == "Player") {
				hif = 1;
				h.health = 0;

			}
			if (timer >=2) {
				laser.enabled = false; 
			}
			if(timer >=4){
				timer =0;
			}
		}
		
	}
}
