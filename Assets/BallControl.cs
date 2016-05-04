using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour
{
	public GameObject Orange;
	public GameObject Blue;
	public GameObject White;
	public GameObject BoomOrange;
	public GameObject BoomBlue;
	public GameObject Electric;
	public GameObject LeftBlocks;
	public GameObject RightBlocks;
	public GameObject SparkOrange;
	public GameObject SparkBlue;
	public GameObject Trekantexp;

	private Vector2 KortPause;
	private CircleCollider2D CoolCollider;
	private bool Row1;
	private bool Row2;
	private bool Row3;
	private bool Row4;

	Transform[] LB;
	Transform[] RB;

	bool isResetting = false;


	// Use this for initialization
	void Start (){
		GetComponent<CamShakeSimple> ().enableshake = false;
		CoolCollider = GetComponent<CircleCollider2D>();


		StartCoroutine (hi (2.0f));

		LB = LeftBlocks.GetComponentsInChildren<Transform> ();

		RB = RightBlocks.GetComponentsInChildren<Transform> ();
	}

	IEnumerator hi (float secs)
	{
		yield return new WaitForSeconds (secs);
		GoBall ();
	}

	void Update ()
	{
		
		print (GetComponent<Rigidbody2D> ().velocity.magnitude);
	
	
	}

	public void GoBall ()
	{
		//Disable trails ved start
		Orange.GetComponent<TrailRenderer> ().time = 0;
		Blue.GetComponent<TrailRenderer> ().time = 0;
		White.GetComponent<TrailRenderer> ().time = 0;

		float rand = Random.Range (0.0f, 100.0f);
		if (rand < 50.0f) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (20.0f, Random.Range (-15.0f, 15.0f)));
		} else {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-20.0f, Random.Range (-15.0f, 15.0f)));
		}
	}

	void hasWon ()
	{


		var vel = GetComponent<Rigidbody2D> ().velocity;
		vel.y = 0;
		vel.x = 0;
		GetComponent<Rigidbody2D> ().velocity = vel;

		gameObject.transform.position = new Vector2 (0, 0);
	}

	public void resetBall ()
	{
		GetComponent<CamShakeSimple> ().enableshake = false;
		Row1 = false;
		Row2 = false;
		//væk med trails
		Orange.GetComponent<TrailRenderer> ().time = 0;
		Blue.GetComponent<TrailRenderer> ().time = 0;
		White.GetComponent<TrailRenderer> ().time = 0;

		var vel = GetComponent<Rigidbody2D> ().velocity;
		vel.y = 0;
		vel.x = 0;
		GetComponent<Rigidbody2D> ().velocity = vel;

		gameObject.transform.position = new Vector2 (0, 0);

		GameObject exp2 = Instantiate (Electric) as GameObject;

		exp2.transform.position = transform.position;


		StartCoroutine (hi (2.0f));
		hi (0.5f);

		//Reset Blockzzz
		foreach (Transform g in LB) {
			print (g.name);

			g.gameObject.SetActive (true);
			if (g.GetComponent<Renderer> ()) {
				g.GetComponent<Renderer> ().enabled = true;
			}
		}

		foreach (Transform g in RB) {
			print ("Ramte block: " + g.name);
			g.gameObject.SetActive (true);
			if (g.GetComponent<Renderer> ()) {
				g.GetComponent<Renderer> ().enabled = true;
			}
		}


		print ("BALL HAS BEEN RESET");

	


	}


	IEnumerator HitWithAHammer ()
	{
		yield return new WaitForSeconds (0.5f);
		//Reset Blockzzz
		foreach (Transform g in LB) {
			print (g.name);

			g.gameObject.SetActive (true);
			if (g.GetComponent<Renderer> ()) {
				g.GetComponent<Renderer> ().enabled = true;
			}
		}

		foreach (Transform g in RB) {
			print ("Ramte block: " + g.name);
			g.gameObject.SetActive (true);
			if (g.GetComponent<Renderer> ()) {
				g.GetComponent<Renderer> ().enabled = true;
			}
		}

		yield return new WaitForSeconds (0.3f);
		//Reset Blockzzz
		foreach (Transform g in LB) {
			print (g.name);

			g.gameObject.SetActive (true);
			if (g.GetComponent<Renderer> ()) {
				g.GetComponent<Renderer> ().enabled = true;
			}
		}

		foreach (Transform g in RB) {
			print ("Ramte block: " + g.name);
			g.gameObject.SetActive (true);
			if (g.GetComponent<Renderer> ()) {
				g.GetComponent<Renderer> ().enabled = true;
			}
		}

		yield return new WaitForSeconds (0.5f);
		//Reset Blockzzz
		foreach (Transform g in LB) {
			print (g.name);

			g.gameObject.SetActive (true);
			if (g.GetComponent<Renderer> ()) {
				g.GetComponent<Renderer> ().enabled = true;
			}
		}

		foreach (Transform g in RB) {
			print ("Ramte block: " + g.name);
			g.gameObject.SetActive (true);
			if (g.GetComponent<Renderer> ()) {
				g.GetComponent<Renderer> ().enabled = true;
			}
		}

	}



	void row1thing ()
	{
		if (Row1 == false) {
			Row1 = true;
			Orange.GetComponent<TrailRenderer> ().enabled = true;
			Blue.GetComponent<TrailRenderer> ().enabled = true;
			White.GetComponent<TrailRenderer> ().enabled = true;
			GetComponent<CamShakeSimple> ().enableshake = true;
		
			StartCoroutine (Kunstnerpause1 ());
		
		}
			
	}

	void row2thing ()
	{
		if (Row2 == false) {
			Row2 = true;
			StartCoroutine (Kunstnerpause2 ());
		}
	}




	void OnCollisionEnter2D (Collision2D coll)
	{

		print (coll.collider.name);

		if (coll.collider.CompareTag ("Player")) {
			var velY = GetComponent<Rigidbody2D> ().velocity.y;
			var velX = GetComponent<Rigidbody2D> ().velocity.x;
			velY = (velY / 2.0f) + (coll.collider.GetComponent<Rigidbody2D> ().velocity.y / 3.0f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (velX, velY);

			GetComponent<Rigidbody2D> ().velocity *= 1.1f;

			print ("fuck");



			if (coll.collider.name == ("Player1")) {
				Orange.GetComponent<TrailRenderer> ().time = 1;
				Blue.GetComponent<TrailRenderer> ().time = 0;
				White.GetComponent<TrailRenderer> ().time = 0;
				if (Row2 == true){
					GameObject exp = Instantiate (BoomOrange) as GameObject;
				exp.transform.position = transform.position;
				}
			}
		
			if (coll.collider.name == ("Player2")) {
				Orange.GetComponent<TrailRenderer> ().time = 0;
				Blue.GetComponent<TrailRenderer> ().time = 1;
				White.GetComponent<TrailRenderer> ().time = 0;
				if (Row2 == true) {
					GameObject exp2 = Instantiate (BoomBlue) as GameObject;
					exp2.transform.position = transform.position;
				}

			}

		}


			
		//BLOCKS
		if (coll.collider.CompareTag ("Block")) {

			GameObject trekanter = Instantiate (Trekantexp) as GameObject;
			trekanter.transform.position = coll.contacts [0].point;
			Destroy (trekanter, 2.9f);


			Orange.GetComponent<TrailRenderer> ().time = 0;
			Blue.GetComponent<TrailRenderer> ().time = 0;
			White.GetComponent<TrailRenderer> ().time = 1;



			// kører blockhack 
			StartCoroutine (BlockHack (coll.collider.gameObject));

		}

		if (coll.collider.name == "R_lvl1") {

			GameObject Spark2 = Instantiate (SparkBlue) as GameObject;
			Spark2.transform.position = coll.contacts [0].point;


			if (GetComponent<Rigidbody2D> ().velocity.magnitude > 20) {
				GetComponent<Rigidbody2D> ().velocity *= 0.66f;
			}

			if (GetComponent<Rigidbody2D> ().velocity != Vector2.zero) {
				KortPause = GetComponent<Rigidbody2D> ().velocity;
			}			row1thing ();

			}
				

			


		if (coll.collider.name == "L_lvl1") {

			GameObject Spark1 = Instantiate (SparkOrange) as GameObject;
			Spark1.transform.position = coll.contacts [0].point;

			if (GetComponent<Rigidbody2D> ().velocity.magnitude > 20) {
				GetComponent<Rigidbody2D> ().velocity *= 0.66f;
			}
				 
			if (GetComponent<Rigidbody2D> ().velocity != Vector2.zero) {
				KortPause = GetComponent<Rigidbody2D> ().velocity;
			}			row1thing ();

		}

		if (coll.collider.name == "R_lvl2") {

			GameObject Spark2 = Instantiate (SparkBlue) as GameObject;
			Spark2.transform.position = coll.contacts [0].point;

			if (GetComponent<Rigidbody2D> ().velocity.magnitude > 20) {
				GetComponent<Rigidbody2D> ().velocity *= 0.75f;
			}

			if (GetComponent<Rigidbody2D> ().velocity != Vector2.zero) {
				KortPause = GetComponent<Rigidbody2D> ().velocity;
			}			row2thing ();

		}



		if (coll.collider.name == "L_lvl2") {

			GameObject Spark1 = Instantiate (SparkOrange) as GameObject;
			Spark1.transform.position = coll.contacts [0].point;

			if (GetComponent<Rigidbody2D> ().velocity.magnitude > 20) {
				GetComponent<Rigidbody2D> ().velocity *= 0.75f;
			}

			if (GetComponent<Rigidbody2D> ().velocity != Vector2.zero) {
				KortPause = GetComponent<Rigidbody2D> ().velocity;
			}			row2thing ();

		}

		if (coll.collider.name == "R_lvl3") {

			GameObject Spark2 = Instantiate (SparkBlue) as GameObject;
			Spark2.transform.position = coll.contacts [0].point;

			if (GetComponent<Rigidbody2D> ().velocity.magnitude > 20) {
				GetComponent<Rigidbody2D> ().velocity *= 0.75f;
			}

			if (GetComponent<Rigidbody2D> ().velocity != Vector2.zero) {
				KortPause = GetComponent<Rigidbody2D> ().velocity;
			}			StartCoroutine (Kunstnerpause3 ());

		}



		if (coll.collider.name == "L_lvl3") {

			GameObject Spark1 = Instantiate (SparkOrange) as GameObject;
			Spark1.transform.position = coll.contacts [0].point;

			if (GetComponent<Rigidbody2D> ().velocity.magnitude > 20) {
				GetComponent<Rigidbody2D> ().velocity *= 0.75f;
			}
			if (GetComponent<Rigidbody2D> ().velocity != Vector2.zero) {
				KortPause = GetComponent<Rigidbody2D> ().velocity;
			}
			StartCoroutine (Kunstnerpause3 ());
		}

		if (coll.collider.name == "R_lvl4") {

			GameObject Spark1 = Instantiate (SparkOrange) as GameObject;
			Spark1.transform.position = coll.contacts [0].point;

			if (GetComponent<Rigidbody2D> ().velocity.magnitude > 20) {
				GetComponent<Rigidbody2D> ().velocity *= 0.75f;
			}

			if (GetComponent<Rigidbody2D> ().velocity != Vector2.zero) {
				KortPause = GetComponent<Rigidbody2D> ().velocity;
			}
			StartCoroutine (Kunstnerpause4 ());

		}



		if (coll.collider.name == "L_lvl4") {

			GameObject Spark1 = Instantiate (SparkOrange) as GameObject;
			Spark1.transform.position = coll.contacts [0].point;

			if (GetComponent<Rigidbody2D> ().velocity.magnitude > 20) {
				GetComponent<Rigidbody2D> ().velocity *= 0.75f;
			}

			if (GetComponent<Rigidbody2D> ().velocity != Vector2.zero) {
				KortPause = GetComponent<Rigidbody2D> ().velocity;
			}			StartCoroutine (Kunstnerpause4 ());

		}
		

	}



	//lvl1 pause
	IEnumerator Kunstnerpause1 ()
	{

			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			yield return new WaitForSeconds (0.2f);
			GetComponent<Rigidbody2D> ().velocity = KortPause;


	}

	//lvl2 pause
	IEnumerator Kunstnerpause2 ()
	{

		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		yield return new WaitForSeconds (0.5f);
		GetComponent<Rigidbody2D> ().velocity = KortPause;


	}

	//lvl3 pause
	IEnumerator Kunstnerpause3 ()
	{

		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		yield return new WaitForSeconds (1f);
		GetComponent<Rigidbody2D> ().velocity = KortPause;


	}

	//lvl4 pause
	IEnumerator Kunstnerpause4 ()
	{

		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		yield return new WaitForSeconds (2f);
		GetComponent<Rigidbody2D> ().velocity = KortPause;


	}

	IEnumerator BlockHack (GameObject GO)
	{




	
		float t = 0;

		// bliv usynlig
		GO.GetComponent<Renderer> ().enabled = false;
		// vent 0.5f seks
		while (t < 0.02f && isResetting == false) {

			t += Time.deltaTime;
			yield return null;

		}

		GO.SetActive (false);
	}


}

// Update is called once per frame