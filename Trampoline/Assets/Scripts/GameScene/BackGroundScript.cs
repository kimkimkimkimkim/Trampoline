using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScript : MonoBehaviour {

	private Vector3 firstPos;
	private float speed = 0.05f;

	// Use this for initialization
	void Start () {
		firstPos = gameObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		float x = gameObject.transform.localPosition.x;
		transform.localPosition = new Vector3 (x - speed,firstPos.y,firstPos.z);

		if (transform.localPosition.x <= -9.0f) {
			transform.localPosition = new Vector3 (9,firstPos.y,firstPos.z);
		}
	}
}
