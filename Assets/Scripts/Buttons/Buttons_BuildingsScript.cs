using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_BuildingsScript : MonoBehaviour {

	public GameObject panel;
	public GameObject road;
	public GameObject buildings;
	public GameObject blocks;
    public GameObject signs;
    public GameObject terrain;
    public GameObject nature;

    public SpawnObject spawnOBJ;

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
		if (!buildings.activeSelf || !panel.activeSelf) {
			panel.SetActive (true);
			buildings.SetActive (true);
			road.SetActive (false);
			blocks.SetActive (false);
            signs.SetActive(false);
            terrain.SetActive(false);
            nature.SetActive(false);
		} else {
			panel.SetActive (false);
			buildings.SetActive (false);
		}
	}
		

	public void OnSuperSkyScrapperClick(){
		spawnOBJ.resource = "SuperSkyScrapper";
		spawnOBJ.Place ();
		spawnOBJ.awaitingClick = true;
	}

	public void OnSkyScrapperClick(){
		spawnOBJ.resource = "SkyScrapper";
		spawnOBJ.Place ();
		spawnOBJ.awaitingClick = true;
	}
    
    public void OnOfficeBuildingClick()
    {
        spawnOBJ.resource = "OfficeBuilding";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
    public void OnArenaClick()
    {
        spawnOBJ.resource = "Arena";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
}
