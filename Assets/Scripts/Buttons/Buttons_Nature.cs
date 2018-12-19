using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_Nature : MonoBehaviour {

    public GameObject panel;
    public GameObject road;
    public GameObject buildings;
    public GameObject blocks;
    public GameObject signs;
    public GameObject terrain;
    public GameObject nature;

    public SpawnObject spawnOBJ;

    // Use this for initialization
    void Start()
    {
        panel.SetActive(false);
        road.SetActive(false);
        nature.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (!buildings.activeSelf || !panel.activeSelf)
        {
            panel.SetActive(true);
            buildings.SetActive(false);
            road.SetActive(false);
            blocks.SetActive(false);
            signs.SetActive(false);
            terrain.SetActive(false);
            nature.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
            nature.SetActive(false);
        }
    }


    public void OnTreeClick()
    {
        spawnOBJ.resource = "Broadleaf_Desktop";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }

    public void OnSpruceClick()
    {
        spawnOBJ.resource = "Conifer_Desktop";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }

    public void OnPalmClick()
    {
        spawnOBJ.resource = "Palm_Desktop";
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
}
