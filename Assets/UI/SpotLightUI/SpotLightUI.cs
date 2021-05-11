using HSVPicker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightUI : MonoBehaviour, IEventHandler
{

    public GameObject content;

    void Start()
    {
        APIHandler.evt.registerHandler(this);
    }

    

    public void onLightChange(Color color)
    {
        GameObject obj = Camera.main.GetComponent<Inspector>().selectedItem;

        obj.transform.GetChild(0).GetComponent<Light>().color = color;

        SpotLightProperties cp = obj.GetComponent<SpotLightProperties>();
        cp.lightColor = color;
    }

    public void onObjectLightChange(Color color)
    {
        GameObject obj = Camera.main.GetComponent<Inspector>().selectedItem;

        obj.transform.GetChild(0).GetComponent<Renderer>().material.color = color;

        SpotLightProperties cp = obj.GetComponent<SpotLightProperties>();
        cp.objectColor = color;
    }

    /// <summary>
    /// This method is called when the game first starts and the save data is loaded in or when the object is duplicated.
    /// <para>This method is called by <see cref="ColorChangingProperties.SetupSerialziedData(SerObjectProperties)"/> or <see cref="ColorChangingProperties.Duplicate(ObjectProperties)"/>.</para>
    /// </summary>
    /// <param name="obj">The gameobject to change the color for.</param>
    /// <param name="color">The color value.</param>
    public void Setup(GameObject obj, Color lightColor, Color objectColor)
    {
        obj.transform.GetChild(0).GetComponent<Light>().color = lightColor;
        obj.transform.GetChild(0).GetComponent<Renderer>().material.color = objectColor;
    }

    [EventHandler]
    public void onIns(OnInspectEvent e)
    {
        if (e.getGameObject().GetComponent<SpotLightProperties>() != null)
        {
            e.getGameObject().GetComponent<SpotLightProperties>().Display(content);
        }
    }

    [EventHandler]
    public void onUnIns(OnUnInspectEvent e)
    {
        int childs = content.transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }
    }
}
