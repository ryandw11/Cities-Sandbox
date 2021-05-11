using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayandNight : MonoBehaviour {

    /*
     * Controls the day and night cycle
     */

    public SettingsManager sm;
    public GameObject sun;
    public GameObject moon;
    public GameObject defSun;

	// Use this for initialization
	void Start () {
        sm = new SettingsManager();
        World.day = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (sm.getBool("dayandnight"))
        {
            if (!sun.activeSelf)
                sun.SetActive(true);
            if (!moon.activeSelf)
                moon.SetActive(true);
            if (defSun.activeSelf)
                defSun.SetActive(false);
            sun.transform.RotateAround(Vector3.zero, Vector3.right, 2f * Time.deltaTime);
            sun.transform.LookAt(Vector3.zero);
            moon.transform.RotateAround(Vector3.zero, Vector3.right, 2f * Time.deltaTime);
            moon.transform.LookAt(Vector3.zero);
            float angle = sun.transform.eulerAngles.x;
            angle = (angle > 180) ? angle - 360 : angle;
            if (angle < 8)
            {
              Camera.main.GetComponent<WorldData>().day = false;
               // print(World.day);
            }
            else
            {
                Camera.main.GetComponent<WorldData>().day = true;
                
            }
        }
        else
        {
            if (sun.activeSelf)
                sun.SetActive(false);
            if (moon.activeSelf)
                moon.SetActive(false);
            if (!defSun.activeSelf)
                defSun.SetActive(true);
        }
	}
}
