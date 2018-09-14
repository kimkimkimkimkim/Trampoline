using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject gameoverView;
	public GameObject basketGoal;

	private GameObject drawLine;
	private GameObject textScore;


	// Use this for initialization
	void Start () {
		drawLine = GameObject.Find ("drawPhysicsLine");
		textScore = GameObject.Find ("TextScore");
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

	public void UpdateScore(int point){
		textScore.GetComponent<Text> ().text = point.ToString ();
	}

	public void CreateGoal(){
		Invoke ("Create",1);
	}

	private void Create(){
		bool active = true;
		int childrenCount = basketGoal.transform.childCount;
		int target = 0;

		while(active){
			target = Random.Range (0, childrenCount);
			active = basketGoal.transform.GetChild (target).gameObject.activeSelf;
		}

		basketGoal.transform.GetChild (target).gameObject.SetActive (true);
	}

}
