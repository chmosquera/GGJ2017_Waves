using UnityEngine;
using System.Collections;

public class LightWaves : Waves {

	private Renderer rend;
	private bool visible;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		//rend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected override void Activate(Collider2D[] objects) {
		visible = true;
		for (int i = 0; i < objects.Length; i++) {

		}
		base.Activate (objects);

	}


}
