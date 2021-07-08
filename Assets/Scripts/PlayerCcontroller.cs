using UnityEngine;

public class PlayerCcontroller : MonoBehaviour {
	#region Interaction
	public bool raycastVisible = true;
	public float raycastDistance = 2.5f;
	public Vector3 raycastOffset;
	[HideInInspector]
	public bool interacting = false;
	public RaycastHit hit;
	#endregion

	#region Movement
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float groundDistance = 0.2f;
    public float dashDistance = 5f;
    public LayerMask ground;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private Transform _groundChecker;
	#endregion

    void Start () {
        _body = GetComponent<Rigidbody>();
        _groundChecker = transform.GetChild(0);
    }

    void Update () {
		#region Movement
        _isGrounded = Physics.CheckSphere(_groundChecker.position, groundDistance, ground, QueryTriggerInteraction.Ignore);
        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");

        if (_inputs != Vector3.zero)
            transform.forward = _inputs;

        if (Input.GetButtonDown("Jump") && _isGrounded)
            _body.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
		
        if (Input.GetButtonDown("Dash")) {
            Vector3 dashVelocity = Vector3.Scale(transform.forward, dashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime)));
            _body.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
		#endregion

	/*	#region Interaction
		Vector3 forward = _body.transform.TransformDirection (Vector3.forward) * raycastDistance;

		if (raycastVisible)
			Debug.DrawRay (transform.position + raycastOffset, forward, Color.green, 0, true);

		if (Physics.Raycast (transform.position + raycastOffset, forward, out hit, raycastDistance)) {
			if (Input.GetKeyDown (KeyCode.E)) 
				interacting = true;
			else 
				interacting = false;
		}
		#endregion
    */
    }

    void FixedUpdate () {
		#region Movement
		_body.MovePosition(_body.position + _inputs * speed * Time.fixedDeltaTime);
		#endregion
    }
}