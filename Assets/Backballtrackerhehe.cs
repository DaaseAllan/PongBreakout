using UnityEngine;
using System.Collections;

public class Backballtrackerhehe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D Back) {
	
		if (Back.tag == "Ball") {
			GetComponent<BallControl> ().BallBackChecker (true);
		}
	}

	void OnTriggerExit2D (Collider2D Back) {

		if (Back.tag == "Ball") {
			GetComponent<BallControl> ().BallBackChecker (false);
		}
	}
}
