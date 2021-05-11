using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Runtime.Serialization;

/// <summary>
/// This class handles the saving and loading of a world.
/// </summary>
public class SaveAndLoad : MonoBehaviour {

    /// <summary>
    /// The list of Serialized Objects.
    /// </summary>
    public List<SerObject> obj = new List<SerObject>();
    /// <summary>
    /// The 2D float array containg the terrain heights.
    /// </summary>
    public float[,] loadHeights;

    /// <summary>
    /// If the loaded file is one made before Alpha 1.6.
    /// </summary>
    public bool isOldFile { get; private set; } = false;

    private SerializedSaveData data;

	// Use this for initialization
	void Start () {
        // call Load (); or Save ();
        data = new SerializedSaveData();
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
        data.objectList.Clear();
        foreach(SerObject i in obj)
        {
            data.objectList.Add(i);
        }
        data.terrianHeights = Terrain.activeTerrain.terrainData.GetHeights(0, 0, Terrain.activeTerrain.terrainData.heightmapResolution, Terrain.activeTerrain.terrainData.heightmapResolution);

    }

    public void Load(string name)
    {
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + name+".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saves/"+name+".dat", FileMode.Open);
            try
            {
                try
                {
                    data = (SerializedSaveData)bf.Deserialize(file);
                }
                catch (InvalidCastException ex)
                {
                    savedata oldData = null;

                    // If this is an old save file, convert it.
                    oldData = (savedata)bf.Deserialize(file);
                    data = ConvertFromOldData(oldData);
                    isOldFile = true;

                }
            }
            catch (SerializationException exs)
            {
                List<string> s = new List<string>();
                s.Add("Back to Main Menu");
                WindowUI wui = new WindowUI(WindowImage.ERROR, WindowType.OK, s, "Unable to Load World", "It looks like the world could not be loaded. This could be due to a corruption or old version.", false, 22, ExitDefault.NONE);
                wui.SetBackgroundActive(true);
                wui.Display();
            }

            CopyLoadData();

            file.Close();
        }//
    }

    public void CopyLoadData()
    {
        obj.Clear ();
        foreach(SerObject i in data.objectList)
        {
            obj.Add(i);
        }
        loadHeights = data.terrianHeights;
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

        // Serialize the object properties is it has one.
        if(gm.GetComponent<ObjectProperties>() != null)
            obj.objProperties = gm.GetComponent<ObjectProperties>().GetSerializedData();

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

    public SerializedSaveData ConvertFromOldData(savedata oldData)
    {
        SerializedSaveData newData = new SerializedSaveData();
        newData.objectList = oldData.list1;
        newData.terrianHeights = oldData.heights;
        return newData;
    }
}

/// <summary>
/// This class is the serialized class that stores the overall data for the world.
/// </summary>
[System.Serializable]
public class SerializedSaveData
{
    public List<SerObject> objectList = new List<SerObject>();
    public float[,] terrianHeights;
}

/// <summary>
/// This is the old version of save data. This exists for backwords compatibility.
/// <para>THIS WILL BE REMOVED IN A NEWER VERSION.</para>
/// </summary>
[System.Serializable]
[System.Obsolete]
public class savedata
{
    public List<SerObject> list1 = new List<SerObject>();
    public float[,] heights;
}

/// <summary>
/// This serializable class represents a general object.
/// </summary>
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

    /// <summary>
    /// This is the individual serialized object data for each class.
    /// (Not all of them have it.)
    /// </summary>
    public SerObjectProperties objProperties;
}

/// <summary>
/// This Represents the general data <b>all</b> objects can store.
/// </summary>
[System.Serializable]
public class SerBuildableStats
{
    public float transparency;
}
