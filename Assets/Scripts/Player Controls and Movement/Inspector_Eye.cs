using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Inspector_Eye : MonoBehaviour {

	public Inspector coI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (coI.info) {
		}
		
	}

	public void onEnd(){

		coI.selectedItem.transform.position = new Vector3 (Convert.ToSingle( coI.x.text), Convert.ToSingle( coI.y.text), Convert.ToSingle( coI.z.text));
		coI.selectedItem.transform.eulerAngles = new Vector3 (Convert.ToSingle( coI.xRot.text), Convert.ToSingle( coI.yRot.text), Convert.ToSingle( coI.zRot.text));
	}
}
