using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSettingsClick : MonoBehaviour {

	public SpawnObject sObj;

	// Use this for initialization
	void Start () {
        sObj.place = new SettingsManager().getBool("BuildOnOthers");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeMode(){ //TODO Setup this feature
		if (sObj.place) {
			sObj.place = false;
		} else {
			sObj.place = true;
		}
	}
}
