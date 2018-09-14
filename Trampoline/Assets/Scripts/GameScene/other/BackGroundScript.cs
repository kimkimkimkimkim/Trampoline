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
		
		float y = gameObject.transform.localPosition.y;
		transform.localPosition = new Vector3 (firstPos.x,y - speed,firstPos.z);

		if (transform.localPosition.y <= -11.0f) {
			transform.localPosition = new Vector3 (firstPos.x,13.0f,firstPos.z);
		}

	}
}
