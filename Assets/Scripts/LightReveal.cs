using UnityEngine;
using System.Collections;

public class LightReveal : MonoBehaviour {
    public float visTime; //affects how long you can see the object
    public float endOfVisTime;
    
    private SpriteRenderer sprRnd;
    private float timeFactor;

    // Use this for initialization
    void Awake () {
        sprRnd = gameObject.GetComponent<SpriteRenderer>();
        timeFactor = 0;
        sprRnd.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
       // if (visible)
        //{
            //timeFactor -= visTime * Time.deltaTime;
            //if (timeFactor <= 0)
            //{
            //    visible = false;
            //    timeFactor = 0;
            //    sprRnd.enabled = false;
            //}
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        sprRnd.enabled = true;
    }

}
