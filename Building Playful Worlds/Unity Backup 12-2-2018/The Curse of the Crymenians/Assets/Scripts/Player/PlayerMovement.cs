using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1f;
	public float rotateSpeed = 120f;
	public float jumpHeight = 5f;
	public bool MayMove = true;

	public float PowerUpSpeed = 2f;
	public float PowerUpSpeedDuration = 1f;
	private bool HasPowerUpSpeed = false;

	public float X;
	public float Z;

	private Rigidbody rb;

	private bool onGround = true;

	// Use this for initialization
	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();

	}

	void Move(){
		if (MayMove) {
			X = Input.GetAxisRaw ("Horizontal") * rotateSpeed * Time.deltaTime;
			Z = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;

			transform.Translate (0, 0, Z);
			transform.Rotate (0, X, 0);

			if (onGround) {
				if (Input.GetKey (KeyCode.Space)) {
					rb.velocity = new Vector3 (0, jumpHeight, 0);

					onGround = false;
				}
			}
		}
	}

	void OnCollisionEnter(Collision target){
		if (target.gameObject.tag == "Ground") {
			onGround = true;
		}
	}

	void OnTriggerEnter(Collider target){
		if (target.gameObject.tag == "PowerUpSpeed") {
			StartCoroutine (SpeedPowerUP ());
			Destroy (target.gameObject);
		}
	}

	IEnumerator SpeedPowerUP(){
		float rememberSpeed = speed;
		speed = PowerUpSpeed;
		yield return new WaitForSeconds (PowerUpSpeedDuration);
		speed = rememberSpeed;
	}

}//CLASS
