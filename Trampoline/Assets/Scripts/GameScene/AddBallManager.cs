using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBallManager : MonoBehaviour {

	private GameObject goalField;
	private GameObject camera;
	private float vel; //ballの速度
	private float boundPower = 9f;
	private float maxBound = 9f;
	private float middleBound = 6f;
	private float minBound = 3f;
	private bool isRising = false;
	private bool isIn = false;

	// Use this for initialization
	void Start () {
		goalField = GameObject.Find("BasketGoal");
		camera = GameObject.Find ("Main Camera");
	}

	// Update is called once per frame
	void Update () {
		JudgeUpDown (); //上昇してるか下降してるか判定
	}


	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Trampoline") {
			isIn = false;
			Bound (col);
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Goal") {
			isIn = true;
		}

		if (col.gameObject.tag == "Out") {
			if(isIn)Point (col);
		}

	}

	void Point(Collider2D col){
		//Debug.Log ("point");
		if(col.transform.parent.parent.gameObject.tag == "MoveGoal"){
			Destroy(col.transform.parent.parent.gameObject);
		}else{
			Destroy(col.transform.parent.gameObject);
		}

		camera.GetComponent<GameManager> ().UpdateScore (1);
		camera.GetComponent<GameManager> ().CreateGoal ();

		Destroy(this.gameObject);
	}

	void JudgeUpDown(){
		vel = GetComponent<Rigidbody2D> ().velocity.y;

		if(vel >= 0)isRising = true;
		if (vel < 0)isRising = false;


		ChangeColliderEnable (!isRising);


	}

	//goalに付いているコライダーのアクティブを変更
	void ChangeColliderEnable(bool b){
		for (int j = 0; j < goalField.transform.childCount; j++) {
			BoxCollider2D[] bCol;
			EdgeCollider2D[] eCol;
			if(goalField.transform.GetChild(j).gameObject.tag == "Goal"){
				bCol = goalField.transform.GetChild(j).gameObject.GetComponents<BoxCollider2D> ();
				eCol = goalField.transform.GetChild(j).gameObject.GetComponents<EdgeCollider2D> ();
			}else{
				//movegoalの時
				bCol = goalField.transform.GetChild(j).GetChild(0).gameObject.GetComponents<BoxCollider2D> ();
				eCol = goalField.transform.GetChild(j).GetChild(0).gameObject.GetComponents<EdgeCollider2D> ();
			}
			for (int i = 0; i < bCol.Length; i++) {
				bCol [i].enabled = b;
			}
			for (int i = 0; i < eCol.Length; i++) {
				eCol [i].enabled = b;
			}
		}
	}

	void GameClear(){
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;

	}


	void Bound(Collision2D col){
		Vector3 colAngle = col.transform.localEulerAngles;
		colAngle.z = TransformAngle(colAngle.z);

		gameObject.transform.localEulerAngles = colAngle;
		GetComponent<Rigidbody2D>().velocity = transform.up * boundPower;

		//トランポリンを削除
		Destroy (col.gameObject);
	}

	float TransformAngle(float angle){
		if (angle >= -90 && angle <= 90) {
			return angle;
		} else if (angle > 90) {
			return TransformAngle(angle - 180);
		} else {
			return TransformAngle(angle + 180);
		}
	}
}
