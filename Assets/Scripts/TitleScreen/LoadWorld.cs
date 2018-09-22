using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadWorld : MonoBehaviour {

    public Dropdown input;
    public GameObject loadProgressPnl;
    public Slider progressBar;
    public Text txt;

	// Use this for initialization
	void Start () {
        loadProgressPnl.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadWorld()
    {
        if (input.options[input.value].text.Equals("None"))
        {
            List<string> s = new List<string>();
            s.Add("Ok");
            WindowUI wui = new WindowUI(WindowImage.INFO, WindowType.OK, s, "World Creation", "You must create a world first!", false, 5, ExitDefault.CLOSEOPERATION);
            return;
        }
          if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "saves" + Path.DirectorySeparatorChar + input.options[input.value].text +".dat"))
          {
                World.name = input.options[input.value].text;
                World.newWorld = false;
            //SceneManager.LoadScene("Project");
            loadProgressPnl.SetActive(true);
            StartCoroutine(LoadAsynchronously("Project"));
          }
    }

    IEnumerator LoadAsynchronously (string world)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(world);
        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / 0.9f);
            progressBar.value = progress;
            txt.text = Mathf.Round((progress * 100)) + "%";
            yield return null;
        }
    }
}
