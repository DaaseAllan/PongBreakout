using UnityEngine;
using System.Collections;


public class Spawnmanager : MonoBehaviour {
	private GameObject Spawnpowerup;
	private float Counter;
	private bool Isrunning;
	public GameObject Powerup;

	public GameObject[] Spawnpoints; 
	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		if (Isrunning == true) 
		{

			// tæl op og så spawn
			Counter += Time.deltaTime;
			if (Counter > 3) {

				Isrunning = false;
				Counter = 0;

				spawnpowerup ();
			}
		} else
		{
			// vente på at powerup bliver taget 
		
		}
	}

	void spawnpowerup()
	{
		Spawnpowerup = Instantiate (Powerup) as GameObject;

		Spawnpowerup.transform.position = Spawnpoints [Random.Range (0, Spawnpoints.Length)].transform.position;


	}

	public void RunAgain()
	{
		Isrunning = true;
		Counter = 0;
	}

	public void ResetManager()
	{

		Isrunning = false;


	}
}
