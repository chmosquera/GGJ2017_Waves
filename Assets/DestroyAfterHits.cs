using UnityEngine;
using System.Collections;

public class DestroyAfterHits : MonoBehaviour {

    public string revealTag;
    public GameObject drop;

    private int hitCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(revealTag))
        {
            Debug.Log("Hit");
            hitCount++;
            if (hitCount == 3)
            {
                Object.Instantiate(drop, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
