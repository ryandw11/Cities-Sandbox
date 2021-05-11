using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is put on the items with LightProperties so that the lights can be enabled or disabled in the day or night
/// depending on the settings.
/// </summary>
public class TimeControlLighting : MonoBehaviour
{
    private Light light;
    private LightProperties lightProp;
    private WorldData worldData;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
        lightProp = GetComponent<LightProperties>();
        worldData = Camera.main.GetComponent<WorldData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightProp.nightOnly)
        {
            if (worldData.day)
                light.enabled = false;
            else
                light.enabled = true;
        }
    }

    public void UpdateLightingCondition()
    {
        if (!lightProp.nightOnly)
        {
            light.enabled = true;
        }
    }
}
