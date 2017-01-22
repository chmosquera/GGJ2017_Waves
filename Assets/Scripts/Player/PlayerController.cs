using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour
{
	[SerializeField] public float speed;
	private Rigidbody2D rb;
    public Text keyFragText;
    //private Vector3 movement;

    private int keyFragments;

	private Animator animator;
	private SpriteRenderer spr;
	private bool facingRight;
    
    void Awake()
    {
        keyFragText.text = "";
    }
	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		spr = GetComponent<SpriteRenderer> ();
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

	}

	private void HandleMovement(float horizontal, float vertical) {

		rb.velocity = new Vector2 (horizontal * speed, vertical * speed);
		//Debug.Log ("velocity.x = " + rb.velocity.x);
		Debug.Log ("velocity.y = " + rb.velocity.y);

		// Deals with Animation
		/*
		if (rb.velocity.x < 0 || rb.velocity.y == 0) {
			facingRight = true;
		} else if (rb.velocity.x > 0 || rb.velocity.y == 0) {
			facingRight = false;
		} else if (rb.velocity 
		*/

		float angle = Vector2.Angle (rb.velocity, Vector2.right);
		Debug.Log ("angle = " + angle);


		if (angle >= 45 && angle <= 135 && rb.velocity.y > 0) { 
			animator.SetInteger ("direction", 1); // direction = UP (1)
		} else if (angle < 45) {
			spr.flipX = true;
			animator.SetInteger ("direction", 2); // direction = RIGHT (2)
		} else if (angle >= 45 && angle <= 135 && rb.velocity.y <= 0) {
			animator.SetInteger ("direction", 3); // direction = DOWN (3)
		} else if (angle > 135) {
			spr.flipX = false;
			animator.SetInteger ("direction", 2); // direction = LEFT (2)
		}


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

	public void Flip() {

	}

}