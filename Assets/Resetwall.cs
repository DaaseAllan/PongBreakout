using UnityEngine;
using System.Collections;

public class Resetwall : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.name == "Ball") {
			hitInfo.gameObject.GetComponent<BallControl> ().resetBall ();
			Debug.Log("RESEEEEEEEET!!!!");
		}

	}
}