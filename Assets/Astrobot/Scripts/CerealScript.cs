using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealScript : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(12, 11);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
