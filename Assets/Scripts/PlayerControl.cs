using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed = 80f;
    public float rotationSpeed = 40f;
    private CharacterController ch;

    void Start () {
        ch = GetComponent<CharacterController>();
	}
	
	void Update () {
        float movement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        ch.SimpleMove(transform.forward * movement);
        transform.Rotate(transform.up * rotation);
    }
}
