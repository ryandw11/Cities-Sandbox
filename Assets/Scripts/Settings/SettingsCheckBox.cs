using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsCheckBox: MonoBehaviour {
    public string name;

    public bool CheckDefault = true;

    private Toggle checkbox;

    private SettingsManager sm;

    void Start()
    {
        sm = new SettingsManager();
        checkbox = gameObject.GetComponent<Toggle>();
        if (!PlayerPrefs.HasKey(name))
        {
            sm.saveBool(name, CheckDefault);
        }

        checkbox.isOn = sm.getBool(name);
        
    }

    public void onCheck()
    {
        sm.saveBool(name, checkbox.isOn);
    }
}
