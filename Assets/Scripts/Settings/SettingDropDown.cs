using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class SettingDropDown: MonoBehaviour {
    public string name;

    public int DefaultValue = 0;

    private Dropdown dropdown;

    private SettingsManager sm;

    void Start()
    {
        sm = new SettingsManager();
        dropdown = gameObject.GetComponent<Dropdown>();
        if (!PlayerPrefs.HasKey(name))
        {
            sm.saveSettings(name, DefaultValue);
        }

        dropdown.value = sm.getSettingInt(name);
        
    }

    public void onChange()
    {
        sm.saveSettings(name, dropdown.value);
    }
}
