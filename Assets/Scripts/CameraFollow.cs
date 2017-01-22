using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Max/Min points the camera is bounded by
	public float xMax, yMax, xMin, yMin;
	private GameManager gameManager;

	private Transform target;
	[SerializeField] string playerTag;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player").transform;
		gameManager = transform.parent.gameObject.GetComponent<GameManager>();


		xMax = gameManager.width;
		yMax = gameManager.height;
		xMin = 0;
		yMin = 0;

		/*
		gameManager = Instantiate (gameManager).GetComponent<GameManager>(); //, new Vector3 (transform.position.x, transform.position.y, 0f), Quaternion.identity) as GameObject;
		boardManager = GetComponent<BoardManager> ();
		*/
	}

	void Update() {
	}

	// Update is called once per frame
	void LateUpdate () {
		// transforms the position of the camera to the position of the player
		if (GameObject.FindGameObjectWithTag(playerTag)) {
			transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), // Clamps values between max/min
											 Mathf.Clamp(target.position.y, yMin, yMax), 
											 transform.position.z);
		}
	}
}
