using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/*
 *Placed on main camera 
 */
public class TerrainEditor : MonoBehaviour
{

    public TerrainEditMode.Mode terrainType;
    Terrain terrain;
    public GameObject terr;
    int hmWidth; // heightmap width
    int hmHeight;

    Camera viewCamera;
    public SpawnObject sobj;
    public bool awatingInfoClick = false;
    public bool info = false;
    public LayerMask buildingMask;
    public LayerMask UI;
    public Slider heightSlider;
    public Slider widthSlider;

    // Use this for initialization
    void Start () {
        viewCamera = Camera.main;
        terrain = Terrain.activeTerrain;
        hmWidth = terrain.terrainData.heightmapResolution;
        hmHeight = terrain.terrainData.heightmapResolution;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (terrainType != TerrainEditMode.Mode.None)
        {
            Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayDistance;
                if (Physics.Raycast(ray.origin, ray.direction, out rayDistance, Mathf.Infinity, buildingMask))
                { //Sending out a raycast to find the ground position.
                if (EventSystem.current.IsPointerOverGameObject()) //If Player's mouse is hovering over UI.
                {
                    return;
                }
                    Vector3 point = rayDistance.point;
                    Debug.DrawLine(ray.origin, point, Color.blue); //For Testing

                    switch (terrainType)
                    {
                        case TerrainEditMode.Mode.Up:
                            bool isDown = Input.GetMouseButton(0);
                            StartCoroutine(ToHeight(isDown, point));
                            break;
                        case TerrainEditMode.Mode.Down:
                            break;
                        case TerrainEditMode.Mode.ToHeight:
                            if (Input.GetMouseButton(0)) //Checks if the mouse is down.
                            {
                                float heightWanted = heightSlider.value;
                                Vector3 offsetPoint = point - terrain.gameObject.transform.position;
                                int terrPointX = (int)((offsetPoint.x / terrain.terrainData.size.x) * hmWidth); //Converts the position
                                int TerrPointZ = (int)((offsetPoint.z / terrain.terrainData.size.z) * hmHeight); //of the click to terrain
                                int size = (int)widthSlider.value;    //The width                                //position
                                int offset = size / 2;
                                float[,] terrainHeight = terrain.terrainData.GetHeights(terrPointX - offset, TerrPointZ - offset, size, size);
                                for (int i = 0; i < size; i++)
                                    for (int j = 0; j < size; j++)
                                        terrainHeight[i, j] = heightWanted; //Sets the size to what the player wanted.
                                heightWanted += Time.deltaTime;
                                terrain.terrainData.SetHeights(terrPointX - offset, TerrPointZ - offset, terrainHeight);
                            }
                            break;
                    }

                }

        }
	}//end of update

       IEnumerator ToHeight(bool isDown, Vector3 point)
       {
        while (isDown)
        {
            float heightWanted = 0;
            heightWanted += 0.001f;
            Vector3 offsetPoint = point - terrain.gameObject.transform.position;
            int terrPointX = (int)((offsetPoint.x / terrain.terrainData.size.x) * hmWidth);
            int TerrPointZ = (int)((offsetPoint.z / terrain.terrainData.size.z) * hmHeight);
            int size = (int)widthSlider.value;
            int offset = size / 2;
            float[,] terrainHeight = terrain.terrainData.GetHeights(terrPointX - offset, TerrPointZ - offset, size, size);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    terrainHeight[i, j] = heightWanted;
            heightWanted += Time.deltaTime;
            terrain.terrainData.SetHeights(terrPointX - offset, TerrPointZ - offset, terrainHeight);
        }
          yield return null;
       }




    }
