﻿using UnityEngine;
using System.Collections;

public class SideWalls : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D hitInfo) {
		if (hitInfo.name == "Ball") {
			string wallName = transform.name;
			hitInfo.gameObject.SendMessage ("resetBall", 0.05, SendMessageOptions.RequireReceiver);
			Debug.Log("RESEEEEEEEET!!!!");
		}

	}
}