using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnUnInspectEvent
{

    private GameObject obj;

    public OnUnInspectEvent(GameObject obj)
    {
        this.obj = obj;
    }

    public GameObject getGameObject()
    {
        return obj;
    }
}
