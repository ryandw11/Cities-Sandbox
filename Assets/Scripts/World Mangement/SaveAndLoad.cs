using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveAndLoad : MonoBehaviour {

    public List<SerObject> obj = new List<SerObject>();
    public float[,] loadHeights;

    private savedata data;

	// Use this for initialization
	void Start () {
        // call Load (); or Save ();
        data = new savedata();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Save(string name)
    {
        if(!Directory.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves")) //Checks if saves folder is there.
        {
            Directory.CreateDirectory(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves"); //if not creates it.
        }

        BinaryFormatter bf = new BinaryFormatter ();

        FileStream file = File.Create (Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + name +".dat"); //Saves File

        obj = gmToObj(World.objects);
        CopySaveData(); //Copies the objects and the terrain.
        bf.Serialize(file, data);//Serializes the file.
        file.Close();//Close the file
    }

    public void CopySaveData()
    {
        data.list1.Clear();
        foreach(SerObject i in obj)
        {
            data.list1.Add(i);
        }
        data.heights = Terrain.activeTerrain.terrainData.GetHeights(0, 0, Terrain.activeTerrain.terrainData.heightmapWidth, Terrain.activeTerrain.terrainData.heightmapHeight);

    }

    public void Load(string name)
    {
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + name+".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saves/"+name+".dat", FileMode.Open);
            data = (savedata) bf.Deserialize(file);

            CopyLoadData();

            file.Close();
        }//
    }

    public void CopyLoadData()
    {
        obj.Clear ();
        foreach(SerObject i in data.list1)
        {
            obj.Add(i);
        }
        loadHeights = data.heights;
    }

    public SerObject makeSerObject(GameObject gm, string s)
    {
        SerObject obj = new SerObject();
        obj.x = gm.transform.position.x;
        obj.y = gm.transform.position.y;
        obj.z = gm.transform.position.z;

        obj.rotX = gm.transform.eulerAngles.x;
        obj.rotY = gm.transform.eulerAngles.y;
        obj.rotZ = gm.transform.eulerAngles.z;

        obj.scalX = gm.transform.localScale.x;
        obj.scalY = gm.transform.localScale.y;
        obj.scalZ = gm.transform.localScale.z;

        SerBuildableStats sbs = new SerBuildableStats();
        sbs.transparency = gm.GetComponent<BuildableStats>().transparency;
        obj.sbs = sbs;

        obj.name = s;
        return obj;
    }

    public List<SerObject> gmToObj(Dictionary<GameObject, string> dc){
        List<SerObject> sbj = new List<SerObject>();
        foreach (KeyValuePair<GameObject, string> pair in dc)
        {
            if (pair.Key != null)
            {
                sbj.Add(makeSerObject(pair.Key, pair.Value));
            }
        }
        return sbj;
    }
}

[System.Serializable]
public class savedata
{
    public List<SerObject> list1 = new List<SerObject>();
    public float[,] heights;
}

[System.Serializable]
public class SerObject
{

    public string name;

    public float x;
    public float y;
    public float z;

    public float rotX;
    public float rotY;
    public float rotZ;

    public float scalX;
    public float scalY;
    public float scalZ;

    public SerBuildableStats sbs;
}

[System.Serializable]
public class SerBuildableStats
{
    public float transparency;
}
