using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PulseEmitter : MonoBehaviour {

    public GameObject lightPulse; //the type of light being pulsed
    public Slider chargeSlider;
    public float chargeSpeed;
    public Image chargeFill;
    public Color chargeColorFull = Color.yellow;
    public Color chargeColor = Color.white;
  
    void Awake()
    {
        chargeSlider.value = 0; 
    }

	// Update is called once per frame
	void Update () {
        
        chargeSlider.value += chargeSpeed * Time.deltaTime;
        
	    if (Input.GetKeyDown(KeyCode.Space) && chargeSlider.value == 100)
        {
			Object.Instantiate(lightPulse, transform.position, Quaternion.identity);
            chargeSlider.value = 0;
        }

        chargeFill.color = Color.Lerp(chargeColor, chargeColorFull, chargeSlider.value / chargeSlider.maxValue);
	}
}
