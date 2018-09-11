using UnityEngine;
using System.Collections;

public class drawPhysicsLine : MonoBehaviour
{

	public GameObject line;
	public GameObject linePrefab;
	public float lineLength = 0.2f;
	public float lineWidth = 0.1f;

	private Vector3 touchPos;
	private int count = 0;
	private bool canDraw = false;

	void Start(){

	}

	void Update (){
		drawLine ();
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

				canDraw = true;
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			count++;
			canDraw = false;
		}
	}
}