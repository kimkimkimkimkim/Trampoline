using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour {

	public GameObject backgroundPrefab;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 20; i++) {
			GameObject background = (GameObject)Instantiate (backgroundPrefab);
			background.transform.position = new Vector3 (0, 26 * i, 0);
			background.transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
