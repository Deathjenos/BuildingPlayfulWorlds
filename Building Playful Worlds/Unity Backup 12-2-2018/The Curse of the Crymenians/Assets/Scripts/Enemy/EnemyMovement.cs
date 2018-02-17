using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed = 0.01f;
	public float loveScore = 10f;

	private float X = 0f;
	private float Z = 0f;

	private GameObject player;
	private PlayerStats playerStats;

	void Awake(){
		player = GameObject.Find("Player");
		playerStats = player.GetComponent<PlayerStats> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		Vector3 Position = Vector3.MoveTowards (transform.position, player.transform.position, speed);
		Position.y = transform.position.y;

		transform.position = Position;

	}

	void OnTriggerEnter(Collider target){
		if (target.gameObject.tag == "AttackObject") {
			if (playerStats.currentLove < playerStats.Love) {
				playerStats.currentLove += loveScore;
			}
			Destroy (gameObject);
		}
	}
}
