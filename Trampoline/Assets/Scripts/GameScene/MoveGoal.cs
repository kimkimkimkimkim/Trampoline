using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGoal : MonoBehaviour {

	private float degree = 0;
	private float speed = 2;
	private float abs = 0.33f;
	private float delta = 0.17f;
	private float y;

	// Use this for initialization
	void Start () {
		this.transform.parent.localEulerAngles = new Vector3(0,0,Random.Range(-15.0f,15.0f));
	}

	// Update is called once per frame
	void Update () {
		degree += Time.deltaTime;
		y = abs * Mathf.Sin (degree * speed) - delta;

		this.transform.localPosition = new Vector3 (0,y,0);
	}
}
