using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorBase : MonoBehaviour {

    private Rigidbody rb;
    private Steering[] steerings;
        
    public float maxAcceleration = 10f;
    public float maxAngularAcceleration = 3f;
    public float drag = 1f;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        steerings = GetComponents<Steering>();
        rb.drag = drag;
    }
	
	void FixedUpdate ()
    {
        Vector3 accelaration = Vector3.zero;
        float rotation = 0f;
        foreach (Steering behavior in steerings)
        {
            SteeringData steering = behavior.GetSteering(this);
            accelaration += steering.linear * behavior.GetWeight();
            rotation += steering.angular * behavior.GetWeight();
        }

        if (accelaration.magnitude > maxAcceleration)
        {
            accelaration.Normalize();
            accelaration *= maxAcceleration;
        }

        rb.AddForce(accelaration);
        if (rotation != 0)
        {
            rb.rotation = Quaternion.Euler(0, rotation, 0);
        }

        /*if (transform.position.x > 10)
            transform.SetPositionAndRotation(new Vector3(-10, transform.position.y, transform.position.z), transform.rotation);
        if (transform.position.x < -10)
            transform.SetPositionAndRotation(new Vector3(10, transform.position.y, transform.position.z), transform.rotation);

        if (transform.position.z > 10)
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, -10), transform.rotation);
        if (transform.position.z < -10)
            transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, 10), transform.rotation);*/
    }
}
