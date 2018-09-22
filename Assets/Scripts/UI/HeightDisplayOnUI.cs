using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightDisplayOnUI : MonoBehaviour {
    public Slider heightSlider;
    Text heightText;
	// Use this for initialization
	void Start () {
        heightText = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        heightText.text = Mathf.Round((heightSlider.value * 100)) + "";
	}
}
