using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class AllWorlds : MonoBehaviour {

    /*
     * This class gets all of the worlds in the save folder.
     * 
     */


    public Dropdown dp;
    public Dropdown manageWorlds;

	// Use this for initialization
	void Start () {

        loadWorlds();

        mangeWrolds();


    }

    public void loadWorlds()
    {
        List<string> options = new List<string>();

        DirectoryInfo info = new DirectoryInfo(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves");
        if (!info.Exists)
        {
            info.Create();
        }

        FileInfo[] fileInfo = info.GetFiles();
        foreach (FileInfo fi in fileInfo)
        {
            if (fi.Extension.Equals(".dat"))
            {
                options.Add(fi.Name.Replace(".dat", ""));
            }
        }
        dp.ClearOptions();

        if (options.Count == 0)
        {
            dp.AddOptions(new List<string> { "None" });
        }
        else
        {
            dp.AddOptions(options);
        }
    }

    public void mangeWrolds()
    {
        List<string> options = new List<string>();

        DirectoryInfo info = new DirectoryInfo(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves");
        FileInfo[] fileInfo = info.GetFiles();
        foreach (FileInfo fi in fileInfo)
        {
            if (fi.Extension.Equals(".dat"))
            {
                options.Add(fi.Name.Replace(".dat", ""));
            }
        }
        manageWorlds.ClearOptions();

        if (options.Count == 0)
        {
            manageWorlds.AddOptions(new List<string> { "None" });
        }
        else
        {
            manageWorlds.AddOptions(options);
        }
    }
}
