using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBoundScript : MonoBehaviour {

	public GameObject gameoverView;

	private float boundPower = 11f;
	private GameObject drawPhysicsLine;

	// Use this for initialization
	void Start () {
		drawPhysicsLine = GameObject.Find ("drawPhysicsLine");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Trampoline") {
			Bound (col);
		}

		if (col.gameObject.tag == "Spike") {
			GameOver ();
		}
	}

	void GameOver(){
		//Lineを書けないように
		drawPhysicsLine.GetComponent<drawPhysicsLine>().gamefinish = true;

		//Ballをこてっ
		gameObject.transform.localEulerAngles = new Vector3 (0,0,-45);
		GetComponent<Rigidbody2D>().velocity = transform.up * boundPower / 2;

		//UIをだす 
		Invoke("DisplayGameoverView",0.5f);

	}

	void DisplayGameoverView(){
		gameoverView.SetActive(true);
		iTween.MoveFrom (gameoverView, iTween.Hash ("x", -5));
	}

	void Bound(Collision2D col){
		Vector3 colAngle = col.transform.localEulerAngles;
		colAngle.z = TransformAngle(colAngle.z);

		gameObject.transform.localEulerAngles = colAngle;
		GetComponent<Rigidbody2D>().velocity = transform.up * boundPower;

		Destroy (col.gameObject);
	}

	float TransformAngle(float angle){
		if (angle >= -90 && angle <= 90) {
			return angle;
		} else if (angle > 90) {
			return TransformAngle(angle - 180);
		} else {
			return TransformAngle(angle + 180);
		}
	}
}
