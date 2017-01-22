using UnityEngine;
using System.Collections;
using System;

public class Pulse : MonoBehaviour {

    public float pulseSpeed = .01f;
    private float pulseSize= 0;
    private Transform trans; //transofrm of the light ring
    public int pulseMax = 40;

    // Use this for initialization
    void Start() {
        trans = GetComponent<Transform>();
        pulseSize = 0;
        trans.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void EmitPulse() {
        pulseSize += pulseSpeed * Time.deltaTime;
        trans.localScale = new Vector3(pulseSize, pulseSize, 0);
    }
    void Update()
    {
       EmitPulse();
       if (pulseSize > pulseMax)
        {
            Destroy(gameObject);
        }
    }
}
