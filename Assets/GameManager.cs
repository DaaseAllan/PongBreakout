using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static int PlayerScore1 = 0;
	public static int PlayerScore2 = 0;

	public GUISkin layout;

	Transform theBall;

	// Use this for initialization
	void Start () {
		theBall = GameObject.FindGameObjectWithTag ("Ball").transform;
	
	}
	
	public static void Score (string wallID) {
		if (wallID == "rightWall") {
			print ("player1" + wallID);
			PlayerScore1++;

		} else {
			print("player2" + wallID);
			PlayerScore2++;
		}
	}




	void OnGUI(){
		GUI.skin = layout;
		Rect r1 = new Rect (Screen.width / 2 - 150 - 12, 20, 100, 100);
		string s1 = "" + PlayerScore1;
		GUI.Label (r1,s1);
		GUI.Label (new Rect (Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

		if (GUI.Button (new Rect (Screen.width / 2 - 60, 35, 120, 53), "Reset")) {
			PlayerScore1 = 0;

			PlayerScore2 = 0;
			theBall.gameObject.SendMessage ("resetBall", .5f, SendMessageOptions.RequireReceiver);
		}

		if (PlayerScore1 == 2) {
			GUI.Label (new Rect (Screen.width /	2 - 150, 200, 2000, 1000), "PLAYER 1 WINS");
			theBall.gameObject.SendMessage ("hasWon", null, SendMessageOptions.RequireReceiver);
		} else if (PlayerScore2 == 2) {
			GUI.Label (new Rect (Screen.width /	2 - 150, 200, 2000, 1000), "PLAYER 2 WINS");
			theBall.gameObject.SendMessage ("hasWon", null, SendMessageOptions.RequireReceiver);



	
		}
	}
}