using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSpeedSlider : MonoBehaviour {

	public Slider movespeed;

	// Use this for initialization
	void Start () {
		movespeed.maxValue = 100;
		movespeed.minValue = 50;
	}
}
