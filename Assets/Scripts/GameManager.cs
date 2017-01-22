using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//public static GameManager instance = null;
	private BoardManager board;
	public int width, height;
	public bool gameOver =  false;
	public int keyFragments;
	public int totalKeys;
	public string keyTag = "Collectible";
	public bool doorUnlocked = false;

	// Use this for initialization
	void Awake () {

		// May  need this for future levels
		/*
		// This makes sure that there is only one game manager
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		*/

		board = GetComponent<BoardManager> ();
		keyFragments = 0;
		totalKeys = GameObject.FindGameObjectsWithTag (keyTag).Length;
		InitGame ();

	}

	void InitGame() {
		width = board.cols;
		height = board.rows;
        board.SetupScene();
    }

	// Update is called once per frame
	void FixedUpdate () {

		// checks if enough keys to unlock door
		if (keyFragments == totalKeys) {
			doorUnlocked = true;
			Debug.Log ("Door has been unlocked");
		}

		// able to unlock door

	}

	public void GameWon() {
			
	}
}
