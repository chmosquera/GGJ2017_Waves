using UnityEngine;
using System.Collections;

public class RemoteActivation3 : MonoBehaviour {

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
        if (toggle.IsActivated() && transform.position.y >= (originalPos + movement).y)
        {
            transform.position += movement * speed * Time.deltaTime;
            if (transform.position.y <= (originalPos + movement).y) { transform.position = originalPos + movement; }
        }
        if (!(toggle.IsActivated()) && transform.position.y <= originalPos.y)
        {
            transform.position -= movement * speed * Time.deltaTime;
            if (transform.position.y > originalPos.y) { transform.position = originalPos; }
        }
    }
}
