using UnityEngine;
using System.Collections;

public class AudioMuffle : MonoBehaviour {

	void Slowmosound (){

			GetComponent<AudioLowPassFilter> ().enabled = true;
}
	}