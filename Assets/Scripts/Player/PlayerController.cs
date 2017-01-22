using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour
{
	[SerializeField] public float speed;
	private Rigidbody2D rb;
    public Text keyFragText;
	private GameManager gameManager;
    //private Vector3 movement;

	private Animator animator;
	private SpriteRenderer spr;


    void Awake()
    {
        keyFragText.text = "";
    }
	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		spr = GetComponent<SpriteRenderer> ();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();

	}

    void Update()
    {
        if (gameManager.keyFragments > 0)
        {
            keyFragText.text = "Key Fragments: " + gameManager.keyFragments;
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

		//Debug.Log ("speed = " + rb.velocity);

		float angle = Vector2.Angle (rb.velocity, Vector2.right);

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

    void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log ("ontrigger");
        if (other.gameObject.CompareTag("Collectible"))
        {
			Debug.Log ("Found a key!");
			//if (Input.GetKeyDown (KeyCode.CapsLock)) {	
				Debug.Log ("Destroy key");
				Destroy (other.gameObject);
				if (gameManager.keyFragments < 3) {
					gameManager.keyFragments += 1;
				}
			//}
        }
		if (other.gameObject.CompareTag ("Finish")) {
			if (gameManager.doorUnlocked && Input.GetKeyDown (KeyCode.E)) {
				gameManager.GameWon();
			}
		}
    }

	public void Explode() {
		// Play explosion animation
		animator.SetBool("explode", true);

		// destroy player
		gameManager.gameOver = true;
		Destroy(gameObject, 50 * Time.fixedDeltaTime);
	}


}