using UnityEngine;
using System.Collections;

public class SwitchActivation : MonoBehaviour {

    private bool activated;
    private string activationTag = "RadioWave";
    private SpriteRenderer sprRend;


    void Start()
    {
        sprRend = gameObject.GetComponent<SpriteRenderer>();
        activated = false;
        sprRend.color = Color.white;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(activationTag))
        {
            activated = !activated;
            if (activated)
            {
                sprRend.color = Color.green;
            }
            else
            {
                sprRend.color = Color.white;
            }
        }
    }

    public bool IsActivated()
    {
        return activated;
    }
}
