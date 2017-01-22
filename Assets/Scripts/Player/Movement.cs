using UnityEngine;
using System.Collections;
/*
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}
*/

public class Movement : MonoBehaviour
{
	[SerializeField] public float speed;
	private Rigidbody2D rb;
	//private Vector3 movement;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		HandleMovement (moveHorizontal, moveVertical);
		//transform.up = rb.velocity;

		//rb.rotation = (float)Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	private void HandleMovement(float horizontal, float vertical) {

		//movement.Set (horizontal, vertical, 0.0f);
		//movement = movement.normalized * speed * Time.deltaTime;
		//rb.MovePosition = transform.position + movement;

		rb.velocity = new Vector2 (horizontal * speed, vertical * speed);
	}

}