using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;

	private Transform player;
	private Vector3 target;
	private Health h;

	// Use this for initialization
	void Start () {
		h = FindObjectOfType<Health> ();
		player = GameObject.FindGameObjectWithTag ("Helmet").transform;

		target = new Vector3 (player.position.x, player.position.y, player.position.z);
	}

	void OnTriggerEnter(Collider other){
		//if (other.CompareTag ("Player")) {
			//DestroyProjectile ();
		//}
		if (other.tag == ("Player")) {
			h.health = h.health-2;
			DestroyProjectile ();
			//}
		}
		DestroyProjectile ();
	}


	void DestroyProjectile(){
		Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
		
		transform.position = Vector3.MoveTowards (transform.position,target,speed * Time.deltaTime);
		if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z) {
			DestroyProjectile ();
		}
	}
}
