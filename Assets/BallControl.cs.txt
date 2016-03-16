using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		StartCoroutine (hi (2.0f));

	} 

	IEnumerator hi(float secs) {
		yield return new WaitForSeconds (secs);
		GoBall ();
	}

	public void GoBall(){
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
		var vel = GetComponent<Rigidbody2D>().velocity;
		vel.y = 0;
		vel.x = 0;
		GetComponent<Rigidbody2D>().velocity = vel;

		gameObject.transform.position = new Vector2 (0, 0);

		StartCoroutine (hi (2.0f));hi (0.5f);

	}

	void OnCollisionEnter2D (Collision2D coll) {

		print (coll.collider.name);

		if (coll.collider.CompareTag("Player")) 
		{
			var velY = GetComponent<Rigidbody2D>().velocity.y;
			velY = (velY / 2.0f)+(coll.collider.GetComponent<Rigidbody2D>().velocity.y / 3.0f);
			GetComponent<Rigidbody2D>().velocity += velY*Vector2.up;

			print ("fuck");

		}
	}
}


	// Update is called once per frame