using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour {

	public bool Shaking; 
	private float ShakeDecay;
	public float ShakeIntensity;   
	private Vector3 OriginalPos;
	private Quaternion OriginalRot;
	public Camera MainCamera;
	
	void Start()
	{
		MainCamera = Camera.main;
		Shaking = false;   
	}

	
	void LateUpdate () 
	{
		if(ShakeIntensity > 0)
		{
			transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
			transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity)*.02f,
			                                    OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity)*.02f,
			                                    OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity)*.02f,
			                                    OriginalRot.w + Random.Range(-ShakeIntensity,     ShakeIntensity)*.02f);
			
			ShakeIntensity -= ShakeDecay;
		}
		else if (Shaking)
		{
			Shaking = false;  
		}
		
	}
	
	

	
	public void DoShake()
	{
		OriginalPos = transform.position;
		OriginalRot = transform.rotation;
		
		ShakeIntensity = 0.1f;
		ShakeDecay = 0.02f;
		Shaking = true;
	}   
}
