using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager {

	public void saveSettings(string name, string s)
    {
        PlayerPrefs.SetString(name, s);
    }

    public void saveSettings(string name, int s)
    {
        PlayerPrefs.SetInt(name, s);
    }

    public void saveSettings(string name, float s)
    {
        PlayerPrefs.SetFloat(name, s);
    }

    public string getSettingString(string name)
    {
        return PlayerPrefs.GetString(name);
    }

    public int getSettingInt(string name)
    {
        return PlayerPrefs.GetInt(name);
    }

    public float getSettingFloat(string name)
    {
        return PlayerPrefs.GetFloat(name);
    }

    public void saveBool(string name, bool t)
    {
        if (t)
            PlayerPrefs.SetString(name, "true");
        else
            PlayerPrefs.SetString(name, "false");
    }

    public bool getBool(string name)
    {
        string s = PlayerPrefs.GetString(name);
        if (s == "true")
            return true;
        else
            return false;
    }
}
