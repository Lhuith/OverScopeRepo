using UnityEngine;
using System.Collections;

public class Character_Turret_Script : MonoBehaviour {

	public float rotateSpeed;
	public Quaternion axis;
	public GameObject idea;
	public CamShake shaker;
	public float motivation;
	public Transform firepoint;
	public SmoothFollowCamScript camChange;
	void Awake () {
		camChange = Camera.main.GetComponent<SmoothFollowCamScript> ();
		shaker = Camera.main.GetComponent<CamShake> ();
		firepoint = GameObject.FindGameObjectWithTag ("FirePoint").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		if (Input.GetKeyDown ("space")) {
			GameObject ideashot = Instantiate (idea, firepoint.position,firepoint.rotation) as GameObject;
			ideashot.GetComponent<Rigidbody2D> ().AddForce(firepoint.right * motivation);
			ideashot.GetComponent<Rigidbody2D> ().AddTorque(200);
			shaker.DoShake ();
			camChange.ChangeTarget(ideashot);
		}
	}
	void Update () {
		GameObject ideaGrab = Resources.Load("Idea_01", typeof(GameObject)) as GameObject;
		idea = ideaGrab;

		axis = transform.rotation;
		transform.Rotate(0,0,20*Time.deltaTime);
		axis.z = Mathf.Clamp (axis.z, 0, 0.6f);
		transform.rotation = axis;


		if(Input.GetKey("w")){
			transform.Rotate(0,0,rotateSpeed*Time.deltaTime);
		}

		if(Input.GetKey("s")){
			transform.Rotate(0,0,-rotateSpeed*Time.deltaTime);
		}
	
	}


	
}
