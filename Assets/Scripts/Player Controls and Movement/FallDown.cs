using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FallDown : MonoBehaviour {

	Ray ray;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if(Physics.Raycast(ray,out hit,Mathf.Infinity,8)){
			transform.position = hit.point;
		}
	}
}
