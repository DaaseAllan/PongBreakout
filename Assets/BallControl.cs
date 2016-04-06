using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {
	public GameObject Orange;
	public GameObject Blue;
	public GameObject BoomOrange;
	public GameObject BoomBlue;
	public GameObject Electric;
	public GameObject LeftBlocks;
	public GameObject RightBlocks;

	Transform[] LB;
	Transform[] RB;


	// Use this for initialization
	void Start () {
		StartCoroutine (hi (2.0f));

		LB = LeftBlocks.GetComponentsInChildren<Transform> ();

		RB = RightBlocks.GetComponentsInChildren<Transform> ();
	} 

	IEnumerator hi(float secs) {
		yield return new WaitForSeconds (secs);
		GoBall ();
	}

	void Update()
	{
		print (GetComponent<Rigidbody2D> ().velocity.magnitude);
	}

	public void GoBall(){

		Orange.SetActive(true);
		Blue.SetActive(true);

		float rand = Random.Range (0.0f, 100.0f);
		if (rand < 50.0f) {
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (20.0f, Random.Range(-15.0f,15.0f)));
		} else {
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (-20.0f, Random.Range(-15.0f,15.0f)));
		}
	}

	void hasWon(){


		var vel = GetComponent<Rigidbody2D>().velocity;
			vel.y = 0;
			vel.x = 0;
		GetComponent<Rigidbody2D>().velocity = vel;

		gameObject.transform.position = new Vector2 (0,0);
	}

	public void resetBall(){
		//HVID STREG MAND!
		Orange.SetActive(false);
		Blue.SetActive(false);

		var vel = GetComponent<Rigidbody2D>().velocity;
		vel.y = 0;
		vel.x = 0;
		GetComponent<Rigidbody2D>().velocity = vel;

		gameObject.transform.position = new Vector2 (0, 0);

		GameObject exp2 = Instantiate (Electric) as GameObject;

		exp2.transform.position = transform.position;


		StartCoroutine (hi (2.0f));hi (0.5f);

		//Reset Blockzzz
		foreach (Transform g in LB) {
			print (g.name);

			g.gameObject.SetActive (true);
			if (g.GetComponent<Renderer> ()) {
				g.GetComponent<Renderer> ().enabled = true;
			}
		}

		foreach (Transform g in RB) {
			print (g.name);
			g.gameObject.SetActive (true);
			if (g.GetComponent<Renderer> ()) {
			g.GetComponent<Renderer> ().enabled = true;
			}
		}


	}

	void OnCollisionEnter2D (Collision2D coll) {

		print (coll.collider.name);

		if (coll.collider.CompareTag ("Player")) {
			var velY = GetComponent<Rigidbody2D> ().velocity.y;
			velY = (velY / 2.0f) + (coll.collider.GetComponent<Rigidbody2D> ().velocity.y / 3.0f);
			GetComponent<Rigidbody2D> ().velocity += velY * Vector2.up;

			print ("fuck");



			if (coll.collider.name == ("Player1")) {
				Orange.SetActive (true);
				Blue.SetActive (false);

				GameObject exp = Instantiate (BoomOrange) as GameObject;

				exp.transform.position = transform.position;
			}
		
			if (coll.collider.name == ("Player2")) {
				Orange.SetActive (false);
				Blue.SetActive (true);

				GameObject exp2 = Instantiate (BoomBlue) as GameObject;

				exp2.transform.position = transform.position;
			}

		}


			
		//BLOCKS
		if (coll.collider.CompareTag ("Block")) {

			// kører blockhack 
			StartCoroutine (BlockHack (coll.collider.gameObject));
		

		}

	}

	IEnumerator BlockHack(GameObject GO)
	{

	
		// bliv usynlig
		GO.GetComponent<Renderer> ().enabled = false;
		// vent 0.5f seks
		yield return new WaitForSeconds(0.1f);
		GO.SetActive (false);
	}


}

	// Update is called once per frame