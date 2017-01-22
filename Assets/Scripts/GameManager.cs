using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//public static GameManager instance = null;
	private BoardManager board;
	public int width, height;

	// Use this for initialization
	void Awake () {

		/*
		// This makes sure that there is only one game manager
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		*/

		board = GetComponent<BoardManager> ();

		InitGame ();

	}

	void InitGame() {
		board.SetupScene();
		width = board.cols;
		height = board.rows;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
