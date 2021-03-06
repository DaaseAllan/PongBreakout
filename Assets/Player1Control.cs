﻿using UnityEngine;
using System.Collections;

public class Player1Control : MonoBehaviour {

	public KeyCode moveUp = KeyCode.UpArrow;
	public KeyCode moveDown = KeyCode.DownArrow;
	public float speed = 10.0f;
	public string SavedPowerup;
	public GameObject powerupready;


	private Vector3 Player1startscale;

		// Use this for initialization
	void Start () {
	
		Player1startscale = transform.localScale;
	}

	// Update is called once per frame
	void Update () {


		var vel = Vector2.zero;

		if (Input.GetKey (moveUp))
		{

			vel.y += speed*Time.deltaTime;


		}

		else if (Input.GetKey (moveDown))
		{

			vel.y -= speed*Time.deltaTime;


		}

		if (Input.GetKeyDown (KeyCode.Keypad3)) 
		{
			UsePowerup ();
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
		transform.localScale = Player1startscale;
	}

	void UsePowerup()
	{
		if (SavedPowerup == "PowerupLarge") {

			transform.localScale = Player1startscale + (Vector3.up*2);

			StartCoroutine (PUscale ());

			SavedPowerup = "";
		}
	}





}

