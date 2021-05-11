using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigthingScript : MonoBehaviour {

    private Light li;

	// Use this for initialization
	void Start () {
        li = gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.GetComponent<WorldData>().day)
        {
            li.enabled = false;
        }
        else
        {
            li.enabled = true;
        }
	}
}
