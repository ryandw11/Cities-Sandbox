using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

    /*
     * Updated Class. This is used for when the content buttons are hit.
     * (ALL except Terrain use this. Terrain has a special system.)
     */

    public GameObject panel;
    public GameObject road;
    public GameObject buildings;
    public GameObject objects;
    public GameObject signs;
    public GameObject terrain;
    public GameObject nature;

    public SpawnObject spawnOBJ;

    void Start () {
        panel.SetActive(false);
        road.SetActive(false);
        buildings.SetActive(false);
        objects.SetActive(false);
        signs.SetActive(false);
        terrain.SetActive(false);
        nature.SetActive(false);
	}

    public void onChangeMenu(string menu)
    {
        switch (menu)
        {
            case "road":
                if (!road.activeSelf || !panel.activeSelf)
                {
                    panel.SetActive(true);
                    buildings.SetActive(false);
                    nature.SetActive(false);
                    objects.SetActive(false);
                    signs.SetActive(false);
                    terrain.SetActive(false);
                    road.SetActive(true);
                }
                else
                {
                    panel.SetActive(false);
                    road.SetActive(false);
                }
                break;
            case "buildings":
                if (!buildings.activeSelf || !panel.activeSelf)
                {
                    panel.SetActive(true);
                    buildings.SetActive(true);
                    nature.SetActive(false);
                    objects.SetActive(false);
                    signs.SetActive(false);
                    terrain.SetActive(false);
                    road.SetActive(false);
                }
                else
                {
                    panel.SetActive(false);
                    buildings.SetActive(false);
                }
                break;
            case "objects":
                if (!objects.activeSelf || !panel.activeSelf)
                {
                    panel.SetActive(true);
                    buildings.SetActive(false);
                    nature.SetActive(false);
                    objects.SetActive(true);
                    signs.SetActive(false);
                    terrain.SetActive(false);
                    road.SetActive(false);
                }
                else
                {
                    panel.SetActive(false);
                    objects.SetActive(false);
                }
                break;
            case "signs":
                if (!signs.activeSelf || !panel.activeSelf)
                {
                    panel.SetActive(true);
                    buildings.SetActive(false);
                    nature.SetActive(false);
                    objects.SetActive(false);
                    signs.SetActive(true);
                    terrain.SetActive(false);
                    road.SetActive(false);
                }
                else
                {
                    panel.SetActive(false);
                    signs.SetActive(false);
                }
                break;
            case "nature":
                if (!nature.activeSelf || !panel.activeSelf)
                {
                    panel.SetActive(true);
                    buildings.SetActive(false);
                    nature.SetActive(true);
                    objects.SetActive(false);
                    signs.SetActive(false);
                    terrain.SetActive(false);
                    road.SetActive(false);
                }
                else
                {
                    panel.SetActive(false);
                    nature.SetActive(false);
                }
                break;
        }
    }

    //Spawn the object by inputing the resource
    public void spawnObject(string resource)
    {
        spawnOBJ.resource = resource;
        spawnOBJ.Place();
        spawnOBJ.awaitingClick = true;
    }
}
