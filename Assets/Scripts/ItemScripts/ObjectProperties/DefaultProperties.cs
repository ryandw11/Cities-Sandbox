using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The default properties for an object.
/// </summary>
public class DefaultProperties : MonoBehaviour, ObjectProperties
{

    public GameObject ui;
    private GameObject g;

    public void Display(GameObject content)
    {
        int childs = content.transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }

        /*GameObject*/ g = Instantiate(ui);
        g.transform.SetParent(content.transform);
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 220);
        // Set the position of the rectangle.
        Canvas.ForceUpdateCanvases();
        // Set the scroll bar to go to the top.
        content.transform.parent.parent.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 1);
        g.GetComponent<RectTransform>().localPosition = new Vector3(90, -40, 0);
    }

    public void Duplicate(ObjectProperties objectProperties)
    {
        
    }

    public SerObjectProperties GetSerializedData()
    {
        return new SerDefaultProperties();
    }

    public bool SetupSerialziedData(SerObjectProperties serData)
    {
        return true;
    }

    [System.Serializable]
    private class SerDefaultProperties : SerObjectProperties
    {

    }
}
