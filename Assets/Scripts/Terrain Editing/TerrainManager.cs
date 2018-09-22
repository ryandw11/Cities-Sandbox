using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour {
    public TerrainEditor terr;
    public GameObject terrainMenu;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(terr.terrainType != TerrainEditMode.Mode.None)
        {
            if (!terrainMenu.activeSelf)
            {
                terr.terrainType = TerrainEditMode.Mode.None;
            }
        }
	}
}
