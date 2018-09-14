using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	private GameObject ball;
	private Vector3 cameraPos;
	private Vector3 ballPos;
	private float deltaY;
	private float maxDis = 2.8f;

	// Use this for initialization
	void Start () {
		ball = GameObject.Find ("ball");
	}
	
	// Update is called once per frame
	void Update () {
		cameraPos = transform.position;
		ballPos = ball.transform.position;
		deltaY = ballPos.y - cameraPos.y;

		if (deltaY >= maxDis) {
			transform.position = new Vector3 (0,ballPos.y - maxDis,-10);
		}
	}
}
