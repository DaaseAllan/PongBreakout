using UnityEngine;
using System.Collections;

public class Slowmo : MonoBehaviour {



	// Use this for initialization
	IEnumerator Start () {

		while (true)
		{
			GetComponent<Camera> ().backgroundColor = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
			yield return WaitForSeconds (0.1f);

		}
	
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
