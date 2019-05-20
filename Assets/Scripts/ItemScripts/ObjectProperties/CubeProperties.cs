using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CubeProperties : MonoBehaviour, ObjectProperties
{

    public int color;
    public GameObject ui;


    public void display(GameObject content)
    {
        int childs = content.transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }

        GameObject g = Instantiate(ui);
        g.transform.parent = content.transform;
        g.GetComponent<RectTransform>().localPosition = new Vector3(0, -150, 0);
        g.transform.GetChild(1).GetComponent<Dropdown>().onValueChanged.AddListener(delegate
        {
            CubeUI cui = FindObjectOfType(typeof(CubeUI)) as CubeUI;
            System.Reflection.MethodInfo mi = cui.GetType().GetMethod("onChange");
            mi.Invoke(cui, new object[] { g.transform.GetChild(1).GetComponent<Dropdown>() });
        });


    }
}
