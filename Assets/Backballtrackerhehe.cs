using UnityEngine;
using System.Collections;

public class Backballtrackerhehe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerStay2D (Collider2D BackCollider) {
	
		if (BackCollider.tag == "Ball") {
			BackCollider.GetComponent<BallControl> ().BallBackChecker (true);
		}
	}

	void OnTriggerExit2D (Collider2D BackCollider) {

		if (BackCollider.tag == "Ball") {
			BackCollider.GetComponent<BallControl> ().BallBackChecker (false);
	}
	}
}
