using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_Terrain : MonoBehaviour {

    public GameObject panel;
    public GameObject road;
    public GameObject buildings;
    public GameObject blocks;
    public GameObject signs;
    public GameObject terrain;

    public TerrainEditor terr;

    // Use this for initialization
    void Start()
    {
        panel.SetActive(false);
        road.SetActive(false);
        buildings.SetActive(false);
        signs.SetActive(false);
        terrain.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (!terrain.activeSelf || !panel.activeSelf)
        {
            panel.SetActive(true);
            buildings.SetActive(false);
            road.SetActive(false);
            blocks.SetActive(false);
            signs.SetActive(false);
            terrain.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
            terrain.SetActive(false);
        }
    }


    public void OnToHeight()
    {
        if (terr.terrainType == TerrainEditMode.Mode.ToHeight)
        {
            terr.terrainType = TerrainEditMode.Mode.None;
        }
        else
        {
            terr.terrainType = TerrainEditMode.Mode.ToHeight;
        }
    }

    public void OnUp()
    {
        if (terr.terrainType == TerrainEditMode.Mode.Up)
        {
            terr.terrainType = TerrainEditMode.Mode.None;
        }
        else
        {
            terr.terrainType = TerrainEditMode.Mode.Up;
        }
    }

}
