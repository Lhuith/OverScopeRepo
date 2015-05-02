using UnityEngine;
using System.Collections;

public class Idea_Script : MonoBehaviour {
	public SmoothFollowCamScript CamchangeBack;
	// Use this for initialization
	void Start () {
		CamchangeBack = Camera.main.GetComponent<SmoothFollowCamScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		//CamchangeBack.ChangeTargetBack ();

		//Destroy (this.gameObject);
	}

}
