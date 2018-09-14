using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject gameoverView;

	private GameObject drawLine;

	// Use this for initialization
	void Start () {
		drawLine = GameObject.Find ("drawPhysicsLine");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GameOver(){
		//線を引けなくする
		drawLine.GetComponent<drawPhysicsLine> ().gamefinish = true;

		//GameOverUIを表示
		gameoverView.SetActive(true);
		iTween.MoveFrom(gameoverView,iTween.Hash("x",-2));
	}
}
