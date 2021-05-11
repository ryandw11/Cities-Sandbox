using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_Blocks : MonoBehaviour {

	public GameObject panel;
	public GameObject road;
	public GameObject buildings;
	public GameObject blocks;
    public GameObject signs;
    public GameObject terrain;
    public GameObject nature;

    public SpawnObject spawnOBJ;

	//TODO add feature where you can scroll through the list of objects in the selection.

	// Use this for initialization
	void Start () {
		panel.SetActive (false);
		road.SetActive (false);
		buildings.SetActive (false);
		blocks.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick(){
		if (!blocks.activeSelf || !panel.activeSelf) {
			panel.SetActive (true);
			blocks.SetActive (true);
			road.SetActive (false);
			buildings.SetActive (false);
            signs.SetActive(false);
            terrain.SetActive(false);
            nature.SetActive(false);
		} else {
			panel.SetActive (false);
			blocks.SetActive (false);
		}
	}

	public void WhiteCube(){
		spawnOBJ.resource = "WhiteCube";
		spawnOBJ.Place ();
		spawnOBJ.awaitingClick = true;
	}
	public void RedCube(){
		spawnOBJ.resource = "RedCube";
		spawnOBJ.Place ();
		spawnOBJ.awaitingClick = true;
	}
	public void BlueCube(){
		spawnOBJ.resource = "BlueCube";
		spawnOBJ.Place ();
		spawnOBJ.awaitingClick = true;
	}
	public void GreenCube(){
		spawnOBJ.resource = "GreenCube";
		spawnOBJ.Place ();
		spawnOBJ.awaitingClick = true;
	}
	public void PurpleCube(){
		spawnOBJ.resource = "PurpleCube";
		spawnOBJ.Place ();
		spawnOBJ.awaitingClick = true;
	}

	public void BlackCube(){
		spawnOBJ.resource = "BlackCube";
		spawnOBJ.Place ();
		spawnOBJ.awaitingClick = true;
	}
	public void OrangeCube(){
		spawnOBJ.resource = "OrangeCube";
		spawnOBJ.Place ();
		spawnOBJ.awaitingClick = true;
	}
}
