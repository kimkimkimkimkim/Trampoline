using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

	public GameObject goal;

	private float vel; //ballの速度
	private bool isRising = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		JudgeUpDown (); //上昇してるか下降してるか判定
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Trampoline") {
			Bound (col);
		}

	}

	void JudgeUpDown(){
		vel = GetComponent<Rigidbody2D> ().velocity.y;
		Debug.Log (vel);

		if(vel >= 0)isRising = true;
		if (vel < 0)isRising = false;

		ChangeColliderEnable (!isRising);


	}

	//goalに付いているコライダーのアクティブを変更
	void ChangeColliderEnable(bool b){
		for (int j = 0; j < goal.transform.childCount; j++) {
			BoxCollider2D[] bCol = goal.transform.GetChild(j).gameObject.GetComponents<BoxCollider2D> ();
			EdgeCollider2D[] eCol = goal.transform.GetChild(j).gameObject.GetComponents<EdgeCollider2D> ();
			for (int i = 0; i < 2; i++) {
				bCol [i].enabled = b;
				eCol [i].enabled = b;
			}
		}
	}


	void Bound(Collision2D col){
		//トランポリンを削除
		Destroy (col.gameObject);
	}
}
