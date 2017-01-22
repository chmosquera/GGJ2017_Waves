using UnityEngine;
using System.Collections;

public class Explosives : Reveal {

	[SerializeField] string playerTag = "Player";
	[SerializeField] string defuseTag = "RadioWave";
	private bool isDefused = false;

	protected override void OnTriggerEnter2D (Collider2D other) {
		Debug.Log ("colliding");

		base.OnTriggerEnter2D(other);

		// if a player collides with this object
		if (other.gameObject.CompareTag(playerTag) && !isDefused) {
			PlayerController playerScr = other.gameObject.GetComponent<PlayerController>();
			playerScr.Explode();
		}
		// if a sound wave collides with this object, it will defuse
		else if (other.gameObject.CompareTag (defuseTag)) {
			isDefused = true;

			// Animation showing object has been defused
		}
		
	}
}
