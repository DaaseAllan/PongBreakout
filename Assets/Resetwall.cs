using UnityEngine;
using System.Collections;

public class Resetwall : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.name == "Ball") {
			hitInfo.gameObject.SendMessage ("resetBall", 0.05, SendMessageOptions.RequireReceiver);
			Debug.Log("RESEEEEEEEET!!!!");
		}

	}
}