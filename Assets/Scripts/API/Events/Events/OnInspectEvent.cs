using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInspectEvent
{
    private GameObject obj;

    public OnInspectEvent(GameObject obj)
    {
        this.obj = obj;
    }

    public GameObject getGameObject()
    {
        return obj;
    }
}
