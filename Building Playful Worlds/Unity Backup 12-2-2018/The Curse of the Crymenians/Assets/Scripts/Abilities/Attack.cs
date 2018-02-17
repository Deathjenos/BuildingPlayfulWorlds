using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	public float speed = 0.1f;

	private GameObject camera;
	private CameraRotation cameraRot;
 	private GameObject player;
	private PlayerMovement playerPM;

	private float X;
	private float Y;

	void Awake(){
		camera = GameObject.Find ("Camera");
		player = GameObject.Find ("Player");
		cameraRot = camera.GetComponent<CameraRotation> ();
		playerPM = player.GetComponent<PlayerMovement> ();
		X = camera.transform.localEulerAngles.x;
		Y = player.transform.localEulerAngles.y;

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		transform.localEulerAngles = new Vector3(X, Y, 0);
		transform.Translate (0, 0, speed);
	}
}
