using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SettingSlider: MonoBehaviour {
    public string name;

    public float DefaultValue = 0;

    private Slider slider;

    private SettingsManager sm;

    void Start()
    {
        sm = new SettingsManager();
        slider = gameObject.GetComponent<Slider>();
        if (!PlayerPrefs.HasKey(name))
        {
            sm.saveSettings(name, DefaultValue);
        }

        slider.value = sm.getSettingFloat(name);
        
    }

    public void onChange()
    {
        sm.saveSettings(name, slider.value);
    }
}
