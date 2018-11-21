using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_Roads : MonoBehaviour {

	public GameObject panel;
	public GameObject road;
	public GameObject buildings;
	public GameObject blocks;
    public GameObject signs;
    public GameObject terrain;
    public GameObject nature;

    public SpawnObject spawnOBJ;

	//TODO Make it where you can constantly place them without needing to click again. (Like delete)

	// Use this for initialization
	void Start () {
		panel.SetActive (false);
		road.SetActive (false);
		buildings.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick(){
		if (!road.activeSelf || !panel.activeSelf) {
			panel.SetActive (true);
			road.SetActive (true);
			buildings.SetActive (false);
			blocks.SetActive (false);
            signs.SetActive(false);
            terrain.SetActive(false);
            nature.SetActive(false);
		} else {
			panel.SetActive (false);
			road.SetActive (false);
		}
	}

	public void OnFreeWay1Click(){
		spawnOBJ.resource = "FreeWay";
		spawnOBJ.Place ();
		spawnOBJ.awaitingClick = true;
	}

	public void OnRoadClick(){
		spawnOBJ.resource = "Road";
		spawnOBJ.Place ();
		spawnOBJ.awaitingClick = true;
	}

	public void OnRoadWithNoMedianClick(){
		spawnOBJ.resource = "TwoLaneNoMedian";
		spawnOBJ.Place ();
		spawnOBJ.awaitingClick = true;
	}
	public void OnRoadWithMedianClick(){
		spawnOBJ.resource = "RoadWithMedian";
		spawnOBJ.Place ();
		spawnOBJ.awaitingClick = true;
	}

}
