using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_Selector : MonoBehaviour {

	public GameObject obj;
	public Inspector ins;

	BoxCollider selObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ins.info) {
			obj.SetActive (true);
			selObj = ins.selectedItem.transform.root.gameObject.GetComponent<BoxCollider>();
			obj.transform.position = new Vector3 (selObj.transform.position.x, selObj.transform.position.y + (selObj.transform.position.y / 2), selObj.transform.position.z);
			//obj.transform.position = selObj.transform.position + (selObj.transform.position / 2);
			obj.transform.localScale = selObj.transform.root.GetComponent<BoxCollider> ().size;
		} else {
			obj.SetActive (false);
		}
	}
		
}
