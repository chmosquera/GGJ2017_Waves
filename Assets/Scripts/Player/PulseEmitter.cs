using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PulseEmitter : MonoBehaviour {

    public Slider chargeSlider;
    public float chargeSpeed;
    public Image chargeFill;
    public Color chargeColor = Color.black;
    public GameObject[] waveTypes;

    private GameObject currentWave;
    private int waveNum;
    private Color chargeColorFull;

    void Awake()
    {
        currentWave = waveTypes[0];
        chargeSlider.value = 0;
        waveNum = 0; 
        chargeColorFull = chargeColorFull = currentWave.gameObject.GetComponent<SpriteRenderer>().color;
    }

	// Update is called once per frame
	void Update () {
        CheckWaveType();

        chargeSlider.value += chargeSpeed * Time.deltaTime;

	    if (Input.GetKeyDown(KeyCode.Space) && chargeSlider.value == 100)
        {
            GameObject.Instantiate(currentWave, transform.position, Quaternion.identity);
            chargeSlider.value = 0;
        }

        chargeFill.color = Color.Lerp(chargeColor, chargeColorFull, chargeSlider.value / chargeSlider.maxValue);
	}

    void CheckWaveType()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            waveNum += 1;
        }
        if(Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            waveNum -= 1;
        }

        if (waveNum >= waveTypes.Length) { waveNum = 0; }
        if (waveNum < 0) { waveNum = waveTypes.Length - 1; }

        currentWave = waveTypes[waveNum];
        chargeColorFull = currentWave.gameObject.GetComponent<SpriteRenderer>().color;

    }
}
