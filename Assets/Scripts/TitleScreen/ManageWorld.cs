using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ManageWorld : MonoBehaviour {

    public Dropdown input;
    public Dropdown dp;

    public AllWorlds dropdownManager;

	public void deleteWorld()
    {
        if (input.options[input.value].text.Equals("None"))
        {
            return;
        }
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + input.options[input.value].text + ".dat"))
        {
            File.Delete(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + input.options[input.value].text + ".dat");
            input.options.RemoveAt(input.value); 
            dp.options.RemoveAt(input.value);
            input.value = 0;
            dropdownManager.mangeWrolds();
        }
    }
}
