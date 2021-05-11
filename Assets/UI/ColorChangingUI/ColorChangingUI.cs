using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangingUI : MonoBehaviour, IEventHandler
{

    void Start()
    {
        APIHandler.evt.registerHandler(this);
    }

    public Material red;
    public Material blue;
    public Material green;
    public Material purple;
    public Material white;
    public Material black;
    public Material orange;
    public Material yellow;

    public GameObject content;

    public void onChange(Dropdown dp)
    {
        GameObject obj = Camera.main.GetComponent<Inspector>().selectedItem;
        int current = dp.value;

        switch (current)
        {
            case 0:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = red;
                break;
            case 1:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = green;
                break;
            case 2:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = blue;
                break;
            case 3:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = purple;
                break;
            case 4:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = white;
                break;
            case 5:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = black;
                break;
            case 6:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = orange;
                break;
            case 7:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = yellow;
                break;
        }

        ColorChangingProperties cp = obj.GetComponent<ColorChangingProperties>();
        cp.color = current;
    }

    /// <summary>
    /// This method is called when the game first starts and the save data is loaded in or when the object is duplicated.
    /// <para>This method is called by <see cref="ColorChangingProperties.SetupSerialziedData(SerObjectProperties)"/> or <see cref="ColorChangingProperties.Duplicate(ObjectProperties)"/>.</para>
    /// </summary>
    /// <param name="obj">The gameobject to change the color for.</param>
    /// <param name="color">The color value.</param>
    public void Setup(GameObject obj, int color)
    {
        switch (color)
        {
            case 0:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = red;
                break;
            case 1:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = green;
                break;
            case 2:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = blue;
                break;
            case 3:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = purple;
                break;
            case 4:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = white;
                break;
            case 5:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = black;
                break;
            case 6:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = orange;
                break;
            case 7:
                obj.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = yellow;
                break;
        }
    }

    [EventHandler]
    public void onIns(OnInspectEvent e)
    {
        if (e.getGameObject().GetComponent<ColorChangingProperties>() != null)
        {
            e.getGameObject().GetComponent<ColorChangingProperties>().Display(content);
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
