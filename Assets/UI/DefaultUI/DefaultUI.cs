using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script for the default UI.
/// </summary>
public class DefaultUI : MonoBehaviour, IEventHandler
{

    public GameObject content;

    void Start()
    {
        APIHandler.evt.registerHandler(this);
    }

    [EventHandler]
    public void onIns(OnInspectEvent e)
    {
        if (e.getGameObject().GetComponent<DefaultProperties>() != null)
        {
            e.getGameObject().GetComponent<DefaultProperties>().Display(content);
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
