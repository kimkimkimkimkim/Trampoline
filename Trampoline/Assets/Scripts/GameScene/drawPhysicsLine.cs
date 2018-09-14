using UnityEngine;
using System.Collections;

public class drawPhysicsLine : MonoBehaviour
{

	public GameObject line;
	public GameObject linePrefab;
	public float lineLength = 0.2f;
	public float lineWidth = 0.1f;
	public bool gamefinish = false;

	private Vector3 touchPos;
	private int count = 0;
	private bool canDraw = false;
	private bool isCreated = false;

	void Start(){

	}

	void Update (){
		if(!gamefinish)drawLine ();
	}

	void drawLine(){

		if(Input.GetMouseButtonDown(0))
		{
			touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			touchPos.z=0;
		}

		if(Input.GetMouseButton(0))
		{

			Vector3 startPos = touchPos;
			Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			endPos.z=0;

			if((endPos-startPos).magnitude > lineLength){
				
				if(canDraw)Destroy (line.transform.Find ("Line" + count.ToString ()).gameObject);
				GameObject obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
				obj.name = "Line" + count.ToString();
				obj.transform.position = (startPos+endPos)/2;
				obj.transform.right = (endPos-startPos).normalized;
				obj.transform.localScale = new Vector3( (endPos-startPos).magnitude, lineWidth , lineWidth );
				obj.transform.parent = line.transform;

				isCreated = true;
				canDraw = true;
			}
		}

		if (Input.GetMouseButtonUp (0) && isCreated) {
			GameObject obj = line.transform.Find ("Line" + count.ToString ()).gameObject;
			BoxCollider2D[] bCol = obj.GetComponents<BoxCollider2D> ();
			for (int i = 0; i < bCol.Length; i++) {
				bCol[i].enabled = true;
			}
			count++;
			canDraw = false;
			isCreated = false;
		}
	}

}