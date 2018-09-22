using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SetTextToSpeed : MonoBehaviour {

	public Text maxspeedText;
	public Slider slider;
	public WASDCam cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		maxspeedText.text = Convert.ToString(slider.value);
		cam.moveSpeed = Convert.ToInt16(slider.value);
	}
}
