using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayUI : MonoBehaviour {

    public GameObject playButton;
    public GameObject controlButton;
    public GameObject mainBackButton;
    public GameObject main;
    public GameObject backgroundPnl;
    public GameObject newWorldPanel;
    public GameObject loadWorldPanel;
    public GameObject controlPanel;
    public GameObject manageWorldPanel;

    private CreateWorld cw;
    private LoadWorld lw;

    public Dropdown manage;

    public AllWorlds dropdownManager;

	// Use this for initialization
	void Start () {
        playButton.SetActive(true);
        main.SetActive(false);
        mainBackButton.SetActive(false);
        backgroundPnl.SetActive(false);
        newWorldPanel.SetActive(false);
        loadWorldPanel.SetActive(false);
        manageWorldPanel.SetActive(false);
        cw = GetComponent<CreateWorld>();
        lw = GetComponent<LoadWorld>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void play()
    {
        playButton.SetActive(false);
        controlButton.SetActive(false);
        mainBackButton.SetActive(true);
        main.SetActive(true);
        backgroundPnl.SetActive(true);
    }

    public void settings()
    {
        List<string> s = new List<string>();
        s.Add("Ok");
        WindowUI wui = new WindowUI(WindowImage.INFO, WindowType.OK, s, "Coming Soon", "This feature is coming soon!", true, 7, ExitDefault.CLOSEOPERATION);
    }

    public void openInFolder()
    {

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + manage.options[manage.value].text + ".dat"))
                p.StartInfo = new System.Diagnostics.ProcessStartInfo("explorer.exe", "/select," + (Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + manage.options[manage.value].text + ".dat").Replace(@"/", @"\"));
            else
                p.StartInfo = new System.Diagnostics.ProcessStartInfo("explorer.exe", "/select," + Application.persistentDataPath + Path.DirectorySeparatorChar + "saves");
            p.Start();
        }
        else if(Application.platform == RuntimePlatform.OSXPlayer)
        {
            bool openInsidesOfFolder;
            string macPath;
            if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + manage.options[manage.value].text + ".dat"))
            {
                openInsidesOfFolder = false;
                macPath = Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + manage.options[manage.value].text + ".dat";
            }
            else
            {
                openInsidesOfFolder = true;
                macPath = Application.persistentDataPath + Path.DirectorySeparatorChar + "saves";
            }
                
            string arguments = (openInsidesOfFolder ? "" : "-R ") + macPath;
            System.Diagnostics.Process.Start("open", arguments);
        }
        else
        {
            List<string> s = new List<string>();
            s.Add("Ok");
            WindowUI wui = new WindowUI(WindowImage.ERROR, WindowType.OK, s, "File Browser", "This game does not support your operating system!", false, 6, ExitDefault.CLOSEOPERATION);
        }
    }

    public void renameWorld()
    {
        List<string> s = new List<string>();
        s.Add("Ok");
        s.Add("World Name");
        WindowUI wui = new WindowUI(WindowImage.INFO, WindowType.INPUTFIELD, s, "Rename World", "Please enter in the new name:", false, 8, ExitDefault.CLOSEOPERATION);
    }

    public void rWorld(string s)
    {
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + s + ".dat"))
        {
            List<string> st = new List<string>();
            st.Add("ok");
            WindowUI wui = new WindowUI(WindowImage.WARNING, WindowType.OK, st, "World Rename Error", "The world name already exists.", true, 12, ExitDefault.CLOSEOPERATION);
            return;
        }
        if (manage.options[manage.value].text == s)
        {
            List<string> st = new List<string>();
            st.Add("Ok");
            WindowUI wui = new WindowUI(WindowImage.ERROR, WindowType.OK, st, "World Rename", "You must rename to world to something else!", false, 9, ExitDefault.CLOSEOPERATION);
        }
        else
         File.Move(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + manage.options[manage.value].text + ".dat", Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + s + ".dat");
        dropdownManager.mangeWrolds();
    }

    public void newWorld()
    {
        main.SetActive(false);
        newWorldPanel.SetActive(true);
    }
    public void loadWorld()
    {
        main.SetActive(false);
        loadWorldPanel.SetActive(true);
        dropdownManager.loadWorlds();
    }

    public void manageWorld()
    {
        main.SetActive(false);
        manageWorldPanel.SetActive(true);
        dropdownManager.mangeWrolds();
    }

    public void createWorld()
    {
        cw.create();
    }
    public void playLoadWorld()
    {
        lw.loadWorld();
    }
    public void loadBack()
    {
        loadWorldPanel.SetActive(false);
        main.SetActive(true);
    }
    public void manageBack()
    {
        manageWorldPanel.SetActive(false);
        main.SetActive(true);
    }
    public void newBack()
    {
        newWorldPanel.SetActive(false);
        main.SetActive(true);
    }
    public void close()
    {
        backgroundPnl.SetActive(false);
    }
    public void exitGame()
    {
        Application.Quit();
    }
    
    public void controls()
    {
        controlPanel.SetActive(true);
        main.SetActive(false);
        playButton.SetActive(false);
        controlButton.SetActive(false);
    }

    public void backFromControls()
    {
        controlPanel.SetActive(false);
        main.SetActive(true);
        playButton.SetActive(true);
        controlButton.SetActive(true);
    }

    public void backToMainMenu()
    {
        main.SetActive(true);
        playButton.SetActive(true);
        controlButton.SetActive(true);
        backgroundPnl.SetActive(false);
        newWorldPanel.SetActive(false);
        loadWorldPanel.SetActive(false);
        mainBackButton.SetActive(false);
    }
}
