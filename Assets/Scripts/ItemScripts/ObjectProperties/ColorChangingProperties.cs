using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A generic color chaning property class.
/// </summary>
public class ColorChangingProperties : MonoBehaviour, ObjectProperties
{
    public int color;
    public GameObject ui;
    public string label;


    /// <inheritdoc/>
    public void Display(GameObject content)
    {
        int childs = content.transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }

        GameObject g = Instantiate(ui);
        g.transform.SetParent(content.transform);
        g.transform.GetChild(0).GetComponent<Text>().text = label;
        g.transform.GetChild(1).GetComponent<Dropdown>().value = color;
        g.transform.GetChild(1).GetComponent<Dropdown>().onValueChanged.AddListener(delegate
        {
            ColorChangingUI cui = FindObjectOfType(typeof(ColorChangingUI)) as ColorChangingUI;
            System.Reflection.MethodInfo mi = cui.GetType().GetMethod("onChange");
            mi.Invoke(cui, new object[] { g.transform.GetChild(1).GetComponent<Dropdown>() });
        });
        // Set the position of the rectangle.
        g.GetComponent<RectTransform>().localPosition = new Vector3(120, -60, 0);
    }

    /// <inheritdoc/>
    public SerObjectProperties GetSerializedData()
    {
        SerColorChangingProperties ser = new SerColorChangingProperties();
        ser.color = this.color;
        return ser;
    }

    /// <inheritdoc/>
    public bool SetupSerialziedData(SerObjectProperties serData)
    {
        SerColorChangingProperties serCubeProperties = (SerColorChangingProperties)serData;
        this.color = serCubeProperties.color;

        ColorChangingUI cui = FindObjectOfType(typeof(ColorChangingUI)) as ColorChangingUI;
        cui.Setup(gameObject, this.color);

        return true;
    }

    /// <inheritdoc/>
    public void Duplicate(ObjectProperties objectProperties)
    {
        ColorChangingProperties cubeProperties = (ColorChangingProperties)objectProperties;
        this.color = cubeProperties.color;

        ColorChangingUI cui = FindObjectOfType(typeof(ColorChangingUI)) as ColorChangingUI;
        cui.Setup(gameObject, this.color);
    }

    /// <summary>
    /// The Serializable Properties Object for this class.
    /// </summary>
    [System.Serializable]
    private class SerColorChangingProperties : SerObjectProperties
    {
        public int color;
    }
}
