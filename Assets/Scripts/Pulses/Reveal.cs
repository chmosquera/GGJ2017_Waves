using UnityEngine;
using System.Collections;

public class Reveal : MonoBehaviour {
    public float visRate; //affects how long you can see the object
    public float visTime;
    public string revealTag;
    
    private SpriteRenderer sprRnd;
    private float timeFactor;

    // Use this for initialization
    void Awake () {

        sprRnd = gameObject.GetComponent<SpriteRenderer>();
        sprRnd.enabled = false;
        timeFactor = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (timeFactor > 0)
        {
            timeFactor -= visRate * Time.deltaTime;
            if (timeFactor <= 0)
            {
                sprRnd.enabled = false;
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(revealTag))
        {
            sprRnd.enabled = true;
            timeFactor = visTime;
        }
    }

}
