using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereProperties : MonoBehaviour, ObjectProperties
{
    public int color;
    public GameObject ui;


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
        g.transform.GetChild(1).GetComponent<Dropdown>().value = color;
        g.transform.GetChild(1).GetComponent<Dropdown>().onValueChanged.AddListener(delegate
        {
            SphereUI cui = FindObjectOfType(typeof(SphereUI)) as SphereUI;
            System.Reflection.MethodInfo mi = cui.GetType().GetMethod("onChange");
            mi.Invoke(cui, new object[] { g.transform.GetChild(1).GetComponent<Dropdown>() });
        });
        // Set the position of the rectangle.
        g.GetComponent<RectTransform>().localPosition = new Vector3(120, -60, 0);
    }

    /// <inheritdoc/>
    public SerObjectProperties GetSerializedData()
    {
        SerSphereProperties ser = new SerSphereProperties();
        ser.color = this.color;
        return ser;
    }

    /// <inheritdoc/>
    public bool SetupSerialziedData(SerObjectProperties serData)
    {
        SerSphereProperties serCubeProperties = (SerSphereProperties)serData;
        this.color = serCubeProperties.color;

        SphereUI cui = FindObjectOfType(typeof(SphereUI)) as SphereUI;
        cui.Setup(gameObject, this.color);

        return true;
    }

    /// <inheritdoc/>
    public void Duplicate(ObjectProperties objectProperties)
    {
        SphereProperties cubeProperties = (SphereProperties)objectProperties;
        this.color = cubeProperties.color;

        SphereUI cui = FindObjectOfType(typeof(SphereUI)) as SphereUI;
        cui.Setup(gameObject, this.color);
    }

    /// <summary>
    /// The Serializable Properties Object for this class.
    /// </summary>
    [System.Serializable]
    private class SerSphereProperties : SerObjectProperties
    {
        public int color;
    }
}
