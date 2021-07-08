using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : MonoBehaviour {

	private Health h;
	public float lastpositionY = 0f;
	public float falldistance = 0f;
	public CharacterController controller;
	public float timer;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		h = FindObjectOfType<Health> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer = timer + Time.deltaTime;
		if (lastpositionY > transform.position.y) {
			falldistance += lastpositionY - transform.position.y;
		} else {
			falldistance = 0;
		}

		lastpositionY = transform.position.y;

		if (falldistance >= 5 && controller.isGrounded && timer >=20) {
			h.health = h.health - 1;
		} 
		
	}
}
