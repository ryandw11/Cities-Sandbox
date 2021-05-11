using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class SettingsInGame : MonoBehaviour {

    public GameObject settingsPanel;
    public GameObject controlsPanel;
    public GameObject audioPanel;
    public GameObject gameplayPanel;

    public GameObject menuPanel;

    public Button controlButton;
    public Button audioButton;
    public Button gameplayButton;

    public Dropdown screenRes;
    public Toggle fullScreen;



    // Use this for initialization
    void Start () {
        controlsPanel.SetActive(true);
        audioPanel.SetActive(false);
        gameplayPanel.SetActive(false);

        controlButton.gameObject.GetComponent<Image>().color = new Color32(141, 141, 142, 100);
        audioButton.gameObject.GetComponent<Image>().color = Color.white;
        gameplayButton.gameObject.GetComponent<Image>().color = Color.white;

        if (screenRes.options[screenRes.value].text != "Auto")
        {
            string[] s = new SettingsManager().getSettingString("ScreenRes").Split('x');
            Screen.SetResolution(Int32.Parse(s[0]), Int32.Parse(s[1]), fullScreen.isOn);
        }

    }
	
	// Update is called once per frame
	void Update () {
	}

    public void back()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void settings()
    {
        settingsPanel.SetActive(true);
    }

    public void onScreenResChange()
    {
        if(screenRes.options[screenRes.value].text == "Auto")
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, fullScreen.isOn);
        }
        else
        {
            string[] s = screenRes.options[screenRes.value].text.Split('x');
            Screen.SetResolution(Int32.Parse(s[0]), Int32.Parse(s[1]), fullScreen.isOn);
        }
    }

    public void onFullScreen()
    {
        if (screenRes.options[screenRes.value].text == "Auto")
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, fullScreen.isOn);
        }
        else
        {
            string[] s = screenRes.options[screenRes.value].text.Split('x');
            Screen.SetResolution(Int32.Parse(s[0]), Int32.Parse(s[1]), fullScreen.isOn);
        }
    }

    public void audio()
    {
        switchPanel("audio");
    }

    public void gameplay()
    {
        switchPanel("gameplay");
    }

    public void controls()
    {
        switchPanel("controls");
    }

    public void switchPanel(string name)
    {
        if(name == "controls")
        {
            controlsPanel.SetActive(true);
            audioPanel.SetActive(false);
            gameplayPanel.SetActive(false);

            controlButton.gameObject.GetComponent<Image>().color = new Color32(141, 141, 142, 100);
            audioButton.gameObject.GetComponent<Image>().color = Color.white;
            gameplayButton.gameObject.GetComponent<Image>().color = Color.white;
        }
        else if (name == "audio")
        {
            controlsPanel.SetActive(false);
            audioPanel.SetActive(true);
            gameplayPanel.SetActive(false);

            controlButton.gameObject.GetComponent<Image>().color = Color.white;
            audioButton.gameObject.GetComponent<Image>().color = new Color32(141, 141, 142, 100);
            gameplayButton.gameObject.GetComponent<Image>().color = Color.white;
        }
        else if (name == "gameplay")
        {
            controlsPanel.SetActive(false);
            audioPanel.SetActive(false);
            gameplayPanel.SetActive(true);

            controlButton.gameObject.GetComponent<Image>().color = Color.white;
            audioButton.gameObject.GetComponent<Image>().color = Color.white;
            gameplayButton.gameObject.GetComponent<Image>().color = new Color32(141, 141, 142, 100);
        }

    }
}
