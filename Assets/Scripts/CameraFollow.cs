using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Max/Min points the camera is bounded by
	[SerializeField] private float xMax, yMax, xMin, yMin;

	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		// transforms the position of the camera to the position of the player
		transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), // Clamps values between max/min
										 Mathf.Clamp(target.position.y, yMin, yMax), 
										 transform.position.z);
	}
}
