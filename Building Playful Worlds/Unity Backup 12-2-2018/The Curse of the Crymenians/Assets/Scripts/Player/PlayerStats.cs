using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public float HP = 100f;
	private float currentHP;

	public float Divinity = 100f;
	private float currentDivinity;

	public float Love = 100f;
	public float currentLove = 0f;

	private PlayerMovement PMScript;
	public Bar HPBar;
	public Bar DivinityBar;
	public Bar LoveBar;

	void Awake(){
		PMScript = GetComponent<PlayerMovement> ();
		currentHP = HP;
		currentDivinity = Divinity;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckStats();
	}

	void CheckStats(){
		if (currentHP <= 0f) {
			PMScript.MayMove = false;
		}

		HPBar.currentprocent = (currentHP / HP) * 100f;
		DivinityBar.currentprocent = (currentDivinity / Divinity) * 100f;
		LoveBar.currentprocent = (currentLove / Love) * 100f;

		if (currentLove > Love) {
			currentLove = Love;
		}
	}

	void OnCollisionEnter(Collision target){
		if (target.gameObject.tag == "Enemy") {
			currentHP -= 10f;
		}
	}
}
