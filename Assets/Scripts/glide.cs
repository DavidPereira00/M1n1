using UnityEngine;
using System.Collections;

public class glide: MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;
	public float amplitude;

	private Vector3 tempPosition;

	void Start () 
	{
		tempPosition = transform.position;
	}

	void FixedUpdate () 
	{
		tempPosition.x += horizontalSpeed;
		tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed)* amplitude;
		transform.position = tempPosition;
	}
}
