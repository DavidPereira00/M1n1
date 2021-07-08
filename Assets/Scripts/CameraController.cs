using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;

	public Vector3 offset;

	public bool useOffsetValues;

	public float rotateSpeed;

	public Transform pivot;

	public float maxViewAngle;
	public float minViewAngle;
	public int locked;
	public bool invertY;
	public int hit;
	public float minDistance = 2;              
	public float maxDistance = 2;
	public float smooth = 4.0f;
	private float rotateAround = 0f;
	private float distanceAway;
	private float cameraHeight = 55f;
	private float cameraPan = 0f;
	private float camRotateSpeed = 180f; 
	public int scp;

	//private const float Y_ANGLE_MIN = 0.0f; 
	//private const float Y_ANGLE_MAX = 50.0f; 

	// Use this for initialization
	void Start () {
		if (!useOffsetValues) {
			offset = target.position - transform.position;
		}
		pivot.transform.position = target.transform.position;
		pivot.transform.parent = target.transform;

		Cursor.visible = false;
	}

	void Update(){
		
	}
		
	
	// Update is called once per frame
	void LateUpdate () {

		CheckWallCollision();
		//rotateAround += Input.GetAxis("Horizontal") * camRotateSpeed * Time.deltaTime;
		//distanceAway = Mathf.Clamp(distanceAway + Input.GetAxis("Vertical"), minDistance, maxDistance);
		//Get the X position of the mouse and rotate the target
		float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
		target.Rotate (0, horizontal, 0);


		//Get the Y position of the mouse and rotate the pivot
		float vertical = Input.GetAxis ("Mouse Y") * rotateSpeed;
		//pivot.Rotate (vertical, 0, 0);
		if (invertY) {
			pivot.Rotate (vertical, 0, 0);
		} else {
			pivot.Rotate (-vertical, 0, 0);
		}

		//Limit the up/down camera rotation
		if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f) {
			pivot.rotation = Quaternion.Euler (maxViewAngle, 0, 0);
		}

		if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle) {
			pivot.rotation = Quaternion.Euler (360f + minViewAngle, 0, 0);
		}



		//Move the camera based on the current roatio of the target and the original offset
		float desiredYangle = target.eulerAngles.y;
		float desiredXangle = pivot.eulerAngles.x;
		Quaternion rotation = Quaternion.Euler (desiredXangle, desiredYangle, 0);
		transform.position = target.position - (rotation * offset);
		
		
		//transform.position = target.position - (rotation * offset);
		//vertical = Mathf.Clamp(vertical, Y_ANGLE_MIN, Y_ANGLE_MAX);

		//transform.position = target.position - offset;

		if (transform.position.y < target.position.y) 
		{
			transform.position = new Vector3 (transform.position.x, target.position.y, transform.position.z);
		}

		rotateAround += horizontal * camRotateSpeed * Time.deltaTime;
		distanceAway = Mathf.Clamp(distanceAway + vertical, minDistance, maxDistance);

		transform.LookAt (target.position + (Vector3.up * 1.5f));
	}

	void CheckWallCollision()
	{
		Vector3 targetOffset = new Vector3(target.position.x, (target.position.y), target.position.z);
		Quaternion rotation = Quaternion.Euler(cameraHeight, rotateAround, cameraPan);
		Vector3 rotateVector = rotation * Vector3.one;
		Vector3 camPosition = targetOffset - rotateVector * distanceAway;
		Vector3 camMask = targetOffset - rotateVector * distanceAway;
		RaycastHit wallHit = new RaycastHit();
		Debug.DrawLine(targetOffset, camMask, Color.green);
		if (Physics.Linecast(targetOffset, camMask, out wallHit))
		{
			camPosition = new Vector3(wallHit.point.x + wallHit.normal.x * 0.5f, camPosition.y, wallHit.point.z + wallHit.normal.z * 0.5f);
		}
		if (wallHit.collider != null) {
			hit = 1;
		} else {
			hit = 0;
		}
		transform.position = Vector3.Lerp(transform.position, camPosition, Time.deltaTime * smooth);
	}
	//se a camera estiver a ir para a direita e ou via colisao para a direita entao nao pode mover, vice-versa para a esquerda
}
