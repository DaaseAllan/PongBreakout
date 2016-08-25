using UnityEngine;
using System.Collections;

public class AudioMuffle : MonoBehaviour {

	void update (){
	
		if (Time.timeScale < 1) {
			Debug.Break ();
			GetComponent<AudioLowPassFilter> ().enabled = true;
}
	}
}