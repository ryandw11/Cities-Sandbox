using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This class is for loading in the cool kids world. 
 */
public class LoadTheWorld : MonoBehaviour {

    public SaveAndLoad sal;
    Terrain terr;

	// Use this for initialization
	void Start () {
        terr = Terrain.activeTerrain;
        float[,] orgTerrain = terr.terrainData.GetHeights(0, 0, terr.terrainData.heightmapWidth, terr.terrainData.heightmapHeight);
        for (int x = 0; x < terr.terrainData.heightmapWidth; x++) //^^ Gets current terrain data.
            for (int y = 0; y < terr.terrainData.heightmapHeight; y++) //Loops through every value.
                orgTerrain[x, y] = 0; //Sets the height to zero.
        terr.terrainData.SetHeights(0, 0, orgTerrain); //Applies the changes.
        if (!World.newWorld)
        {
            sal.Load(World.name); //Load Objects
            forLoop(sal.obj);//Spawn in objects.
        }
        if (sal.loadHeights != null) //Checks if there is any heightmap stored.
        {
            terr.terrainData.SetHeights(0, 0, sal.loadHeights); //Load heights.
        }
    }

    void forLoop(List<SerObject> ls)
    {
        foreach (SerObject ob in ls)
        {
            GameObject obj = (GameObject) Instantiate(Resources.Load(ob.name), new Vector3(-900, 0, -900), Quaternion.identity);
            obj.transform.position = new Vector3(ob.x, ob.y, ob.z);
            obj.transform.eulerAngles = new Vector3(ob.rotX, ob.rotY, ob.rotZ);
            obj.transform.localScale = new Vector3(ob.scalX, ob.scalY, ob.scalZ);
            obj.layer = 10;
            SerBuildableStats bs = ob.sbs;
            if(bs != null) //TODO remove hard code.
            {
                obj.GetComponent<BuildableStats>().transparency = (int)ob.sbs.transparency; // Loads in the build stats data.
            }
            else
            {
                List<string> s = new List<string>();
                s.Add("Continue");
                s.Add("Exit to Main Menu");
                WindowUI wui = new WindowUI(WindowImage.WARNING, WindowType.YES_NO, s, "Older version.", "It looks like you are loading this world from an older version of the game. The objects have been updated to the new format. Would you like to continue?", false, 4, ExitDefault.CLOSEOPERATION);
            }
            
            World.objects.Add(obj, ob.name);
        }
    }
}
