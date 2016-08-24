using UnityEngine;
using System.Collections;

public class Resetwall : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.name == "Ball") {
			if ((GameManager.PlayerScore1 == 2 || GameManager.PlayerScore2 == 2)) {

				print ("vi gør ikke noget hilsen walls");
			} 
			else {
				hitInfo.gameObject.GetComponent<BallControl> ().resetBall ();
			}

			Debug.Log("RESEEEEEEEET!!!!");
		}

	}
}