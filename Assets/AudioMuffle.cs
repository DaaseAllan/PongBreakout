using UnityEngine;
using System.Collections;

public class AudioMuffle : MonoBehaviour {

	public void Slowmosound (){

			GetComponent<AudioLowPassFilter> ().enabled = true;
}

	public void Slowmosoundoff (){

		GetComponent<AudioLowPassFilter> ().enabled = false;
	}
	}