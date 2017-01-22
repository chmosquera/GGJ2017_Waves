using UnityEngine;
using System.Collections;

public class DestroyAfterHits : MonoBehaviour {

    public string revealTag;
    public GameObject drop;

    private int hitCount = 0;

    void OnTriggerEnter(Collider2D other)
    {
        if (other.gameObject.CompareTag(revealTag))
        {
            hitCount++;
            if (hitCount == 3)
            {
                Instantiate(drop, transform);
                Destroy(gameObject);
            }
        }
    }
}
