using UnityEngine;
using System.Collections;

public class CamShakeSimple : MonoBehaviour 
{

	Vector3 originalCameraPosition;

	float shakeAmt = 0;

	public Camera mainCamera;


	void Start()
	{
		originalCameraPosition = mainCamera.transform.position;
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{

		shakeAmt = coll.relativeVelocity.magnitude * 0.0025f;
		InvokeRepeating("CameraShake", 0, .01f);
		Invoke("StopShaking", 0.2f);

	}

	void CameraShake()
	{
		if(shakeAmt>0) 
		{
			float quakeAmt = Random.value*shakeAmt*2 - shakeAmt;
			Vector3 pp = mainCamera.transform.position;
			pp.y+= quakeAmt; // can also add to x and/or z
			quakeAmt = Random.value*shakeAmt*2 - shakeAmt;
			pp.x+= quakeAmt;
			mainCamera.transform.position = pp;
		}
	}

	void StopShaking()
	{
		CancelInvoke("CameraShake");
		mainCamera.transform.position = originalCameraPosition;
	}

}