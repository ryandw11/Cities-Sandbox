using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorUtils {

    public Inspector ins;

    public InspectorUtils(){
        ins = Camera.main.GetComponent<Inspector>();
    }

    /*
     * Removes an item from being inspected.
     */
    public void clear()
    {
        ins.selectedItem.GetComponent<MeshRenderer>().enabled = false;
        ins.selectedItem = null;
        ins.pnl.SetActive(false);
        ins.del.tg.target = null;
        ins.info = false;
    }

    /*
     * Inspects an item.
     */
    public void setTarget(GameObject g)
    {
        ins.selectedItem = g;
        ins.selectedItem.GetComponent<MeshRenderer>().enabled = true;
        ins.pnl.SetActive(true);
        ins.del.tg.target = g.transform;
        ins.info = true;
        ins.del.tg.selectedAxis = RuntimeGizmos.Axis.None;
    }

    public void changePanel(string s)
    {
        if (s == "properties")
        {
            ins.transformPanel.SetActive(false);
            ins.propertiesPanel.SetActive(true);
            ColorBlock cb = ins.propertiesButton.colors;
            cb.normalColor = Color.gray;
            ins.propertiesButton.gameObject.GetComponent<Image>().color = Color.white;
            ins.transformButton.gameObject.GetComponent<Image>().color = new Color32(141, 141, 142, 100);
        }
        else if(s == "transform")
        {
            ins.transformPanel.SetActive(true);
            ins.propertiesPanel.SetActive(false);
            ins.propertiesButton.gameObject.GetComponent<Image>().color = new Color32(141, 141, 142, 100);
            ins.transformButton.gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    public bool isPropertiesActive()
    {
        if (ins.propertiesPanel.activeSelf)
            return true;
        return false;
    }

    public bool isTransformActive()
    {
        if (ins.transformPanel.activeSelf)
            return true;
        return false;
    }

}
