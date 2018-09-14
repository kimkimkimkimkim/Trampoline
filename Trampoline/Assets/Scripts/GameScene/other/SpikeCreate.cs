using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCreate : MonoBehaviour {

	public GameObject spikePrefab;
	public Vector3[] createPos = new Vector3[5];

	// Use this for initialization
	void Start () {
		Invoke ("Create",1.5f);
	}

	void Create(){

		GameObject spike = (GameObject)Instantiate (spikePrefab);
		spike.transform.position = createPos[Random.Range(0, 5)];
		spike.transform.parent = transform;


		Invoke ("Create", 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
