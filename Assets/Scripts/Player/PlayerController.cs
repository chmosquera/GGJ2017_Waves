using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/*
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}
*/

public class PlayerController : MonoBehaviour
{
	[SerializeField] public float speed;
	private Rigidbody2D rb;
    public Text keyFragText;
    //private Vector3 movement;

    private int keyFragments;
    
    void Awake()
    {
        keyFragText.text = "";
    }
	void Start() {
		rb = GetComponent<Rigidbody2D> ();
        keyFragments = 0;
	}

    void Update()
    {
        if (keyFragments > 0)
        {
            keyFragText.text = "Key Fragments: " + keyFragments;
        }
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            if (keyFragments < 3)
            {
                keyFragments += 1;
            }
        }
    }

}