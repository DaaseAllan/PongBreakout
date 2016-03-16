using UnityEngine;
using System.Collections;

public class Player1Control : MonoBehaviour {

	public KeyCode moveUp = KeyCode.UpArrow;
	public KeyCode moveDown = KeyCode.DownArrow;
	public float speed = 10.0f;

		// Use this for initialization
	void Start () {
	

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

		GetComponent<Rigidbody2D> ().velocity = vel;

	}
}

