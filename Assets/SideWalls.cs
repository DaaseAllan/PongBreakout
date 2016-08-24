using UnityEngine;
using System.Collections;

public class SideWalls : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.name == "Ball") {
			string wallName = transform.name;
			GameManager.Score (wallName);
			if ((GameManager.PlayerScore1 == 2 || GameManager.PlayerScore2 == 2)) {

				print ("vi gør ikke noget hilsen walls");
			} 
			else {
				hitInfo.gameObject.GetComponent<BallControl> ().resetBall ();
			}
	
			Debug.Log("halløj");
		
		}
	
	}
}
	
