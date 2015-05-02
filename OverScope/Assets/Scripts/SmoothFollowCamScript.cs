using UnityEngine;
using System.Collections;

public class SmoothFollowCamScript : MonoBehaviour {
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public GameObject target, curTarget;
	//public Vector2 offSet = new Vector2(0,2);
	
	public void Awake(){
		curTarget = GameObject.FindGameObjectWithTag("Player");
	}

	void Update ()
	{
		if (target)
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.transform.position);
			Vector3 delta = target.transform.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.6f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta ;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		}
		
	}
	public void ChangeTarget(GameObject targ){
		target = targ;
	}

	public void ChangeTargetBack(){
		target = curTarget;
	}

}
