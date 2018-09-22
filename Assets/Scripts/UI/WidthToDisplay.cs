using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WidthToDisplay : MonoBehaviour {
    public Slider widthSlider;
    Text widthText;
	// Use this for initialization
	void Start () {
        widthText = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        widthText.text = widthSlider.value + "";
	}
}
