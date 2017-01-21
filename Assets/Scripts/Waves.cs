using UnityEngine;
using System.Collections;

public class Waves : MonoBehaviour {

	[SerializeField] LayerMask affectedLayer;
	public bool activate; // is set in the ___ class
	public Collider2D[] colliders; // collider of objects collided with
	private CircleCollider2D myCollider; // collider of this object

	// Use this for initialization
	void Start () {
		myCollider = transform.GetComponent<CircleCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		myCollider.radius *= transform.localScale.x; 
		foreach (Collider2D c in colliders) {
			colliders = Physics2D.OverlapCircleAll(transform.position, myCollider.radius, affectedLayer);
		}
	}

	protected virtual void Activate(Collider2D[] colliders) {
		activate = false;

				
	}
}
