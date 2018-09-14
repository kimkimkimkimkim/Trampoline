using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	private GameObject maincamera;

	// Use this for initialization
	void Start () {
		maincamera = GameObject.Find ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		maincamera.GetComponent<GameManager> ().GameOver ();
	}
}
