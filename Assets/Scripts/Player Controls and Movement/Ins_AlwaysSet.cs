using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ins_AlwaysSet : MonoBehaviour {
	public Inspector ins;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ins.info && ins.selectedItem != null) {
			ins.x.text = Convert.ToString (ins.selectedItem.transform.root.position.x);
			ins.y.text = Convert.ToString (ins.selectedItem.transform.root.position.y);
			ins.z.text = Convert.ToString (ins.selectedItem.transform.root.position.z);
			ins.xRot.text = Convert.ToString (ins.selectedItem.transform.root.rotation.eulerAngles.x);
			ins.yRot.text = Convert.ToString (ins.selectedItem.transform.root.rotation.eulerAngles.y);
			ins.zRot.text = Convert.ToString (ins.selectedItem.transform.root.rotation.eulerAngles.z);
		}
	}
}
