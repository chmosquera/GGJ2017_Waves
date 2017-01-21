using UnityEngine;
using System.Collections;
using System;

public class LightPulse : MonoBehaviour {

    public float pulseSpeed = .01f;
    private float pulseSize= 0;
    private Transform lightTrans; //transofrm of the light ring
    private int pulseMax = 40;

    // Use this for initialization
    void Start() {
        lightTrans = GetComponent<Transform>();
        pulseSize = 0;
        lightTrans.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Pulse() {
        pulseSize += pulseSpeed * Time.deltaTime;
        lightTrans.localScale = new Vector3(pulseSize, pulseSize, 0);
    }
    void Update()
    {
       Pulse();
       if (pulseSize > pulseMax)
        {
            Destroy(gameObject);
        }
    }
}
