using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour {

	public GameObject attackObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Autoattack ();
	}

	void Autoattack(){
		if (Input.GetMouseButtonDown(0)) {
			Instantiate (attackObject, transform.position, Quaternion.identity);
		}
	}
}//CLASS
