using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour {

	public int posNum = 0;

	private GameObject camera;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find("Main Camera");
	}

	// Update is called once per frame
	void Update () {

	}

	void OnDestroy(){
		camera.GetComponent<GameManager>().goalposCheck[posNum] = 0;
	}
}
