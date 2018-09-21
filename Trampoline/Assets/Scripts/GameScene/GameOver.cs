using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	private GameObject maincamera;
	private int count = 0;

	// Use this for initialization
	void Start () {
		maincamera = GameObject.Find ("Main Camera");
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag == "Ball" && count == 0){
			maincamera.GetComponent<GameManager> ().GameOver ();
			count++;
		}
	}
}
