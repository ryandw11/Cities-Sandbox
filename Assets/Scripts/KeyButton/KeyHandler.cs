using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Put this script on the MainCamera.
 */

public class KeyHandler : MonoBehaviour {

    public KeyCode getKey(string name)
    {
       string k = PlayerPrefs.GetString(name);
       return (KeyCode)System.Enum.Parse(typeof(KeyCode), k);
    }

    public void setKey(string name, KeyCode key)
    {
        PlayerPrefs.SetString(name, key.ToString());
    }

    public void setDefaultKey(string name, KeyCode key)
    {
        if (!PlayerPrefs.HasKey(name))
        {
            PlayerPrefs.SetString(name, key.ToString());
        }
    }
}
