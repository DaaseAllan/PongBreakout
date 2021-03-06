﻿using UnityEngine;
using System.Collections;

public class Player2Control : MonoBehaviour {

	public KeyCode moveUp = KeyCode.W;
	public KeyCode moveDown = KeyCode.S;
	public float speed = 10.0f;
	public string SavedPowerup;
	private Vector3 Player2startscale;
	public GameObject powerupready;

	void Start () {

		Player2startscale = transform.localScale;

	}

	// Update is called once per frame
	void Update () {


		var vel = Vector2.zero;

		if (Input.GetKey (moveUp))
		{

			vel.y += speed*Time.deltaTime;


		}

		if (Input.GetKeyDown (KeyCode.T)) 
		{
			UsePowerup ();
		}


		else if (Input.GetKey (moveDown))
		{

			vel.y -= speed*Time.deltaTime;


		}

		GetComponent<Rigidbody2D> ().velocity = vel;

		if (SavedPowerup == "PowerupLarge") {
			powerupready.SetActive (true);
		} else {
			powerupready.SetActive (false);
		}

	}

	IEnumerator PUscale ()
	{
		yield return new WaitForSeconds (5);
		transform.localScale = Player2startscale;
	}


	void UsePowerup()
	{
		if (SavedPowerup == "PowerupLarge") {

			transform.localScale = Player2startscale + (Vector3.up*2);


			StartCoroutine (PUscale ());

			SavedPowerup = "";
		}
	}


}

