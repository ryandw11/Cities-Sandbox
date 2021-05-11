using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashing_Red_Light : MonoBehaviour {

    //Get if night to enable and disable.

    private Light li;

	// Use this for initialization
	void Start () {
        li = gameObject.GetComponent<Light>();
        InvokeRepeating("turnlightonandoff", 2.0f, 1.0f);

    }
	
	void turnlightonandoff()
    {
        if (li.enabled)
        {
            li.enabled = false;
        }
        else
        {
            li.enabled = true;
        }
    }
}
