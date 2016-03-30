using UnityEngine;
using System.Collections;

public class Slowmo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.Keypad0)) {

			Time.timeScale = 0.3f;
		} else
		{
			Time.timeScale = 1f;
		}
	
	}
}
