using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The properties for the Cube object.
/// </summary>
public class CubeProperties : MonoBehaviour, ObjectProperties
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
            CubeUI cui = FindObjectOfType(typeof(CubeUI)) as CubeUI;
            System.Reflection.MethodInfo mi = cui.GetType().GetMethod("onChange");
            mi.Invoke(cui, new object[] { g.transform.GetChild(1).GetComponent<Dropdown>() });
        });
        // Set the position of the rectangle.
        g.GetComponent<RectTransform>().localPosition = new Vector3(120, -60, 0);
    }

    /// <inheritdoc/>
    public SerObjectProperties GetSerializedData()
    {
        SerCubeProperties ser = new SerCubeProperties();
        ser.color = this.color;
        return ser;
    }

    /// <inheritdoc/>
    public bool SetupSerialziedData(SerObjectProperties serData)
    {
        SerCubeProperties serCubeProperties = (SerCubeProperties)serData;
        this.color = serCubeProperties.color;

        CubeUI cui = FindObjectOfType(typeof(CubeUI)) as CubeUI;
        cui.Setup(gameObject, this.color);

        return true;
    }

    /// <inheritdoc/>
    public void Duplicate(ObjectProperties objectProperties)
    {
        CubeProperties cubeProperties = (CubeProperties)objectProperties;
        this.color = cubeProperties.color;

        CubeUI cui = FindObjectOfType(typeof(CubeUI)) as CubeUI;
        cui.Setup(gameObject, this.color);
    }

    /// <summary>
    /// The Serializable Properties Object for this class.
    /// </summary>
    [System.Serializable]
    private class SerCubeProperties : SerObjectProperties
    {
        public int color;
    }
}
