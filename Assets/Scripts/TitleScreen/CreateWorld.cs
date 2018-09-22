using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class CreateWorld : MonoBehaviour {

    public InputField input;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void create()
    {
        if(input.text != "")
        {
            if(File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + input.text + ".dat"))
            {
                List<string> s = new List<string>();
                s.Add("ok");
                WindowUI wui = new WindowUI(WindowImage.WARNING, WindowType.OK, s, "World Creation Error", "The world name already exists.", true, 11, ExitDefault.CLOSEOPERATION);
            }
            else
            {
                World.name = input.text;
                World.newWorld = true;
                SceneManager.LoadScene("Project");
            }
        }
        else
        {
            List<string> s = new List<string>();
            s.Add("ok");
            WindowUI wui = new WindowUI(WindowImage.WARNING, WindowType.OK, s, "World Creation Error", "The world name cannot be nothing!", true, 1, ExitDefault.CLOSEOPERATION);
        }
    }
}
