using UnityEngine;
using System.Collections;

public class RemoteActivate1 : MonoBehaviour {

    public SwitchActivation toggle;
    public float speed;
    public Vector3 movement;

    private Vector3 originalPos;

    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    void Update()
    {
        if (toggle.IsActivated() && transform.position.x <= (originalPos + movement).x)
        {
            transform.position += movement * speed * Time.deltaTime;
            if (transform.position.x >= (originalPos + movement).x) { transform.position = originalPos + movement; }
        }
        if (!(toggle.IsActivated()) && transform.position.x >= originalPos.x)
        {
            transform.position -= movement * speed * Time.deltaTime;
            if (transform.position.x < originalPos.x) { transform.position = originalPos; }
        }
    }
}
