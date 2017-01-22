using UnityEngine;
using System.Collections;

public class AndActivation : MonoBehaviour {

    public SwitchActivation toggle1;
    public SwitchActivation toggle2;
    public float speed;
    public Vector3 movement;

    private Vector3 originalPos;

    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    void Update()
    {
        if (toggle1.IsActivated() && toggle2.IsActivated() && transform.position.y <= (originalPos + movement).y)
        {
            transform.position += movement * speed * Time.deltaTime;
            if (transform.position.y >= (originalPos + movement).y) { transform.position = originalPos + movement; }
        }
        if (!(toggle1.IsActivated() || toggle2.IsActivated()) && transform.position.y >= originalPos.y)
        {
            transform.position -= movement * speed * Time.deltaTime;
            if (transform.position.y < originalPos.y) { transform.position = originalPos; }
        }
    }
}
