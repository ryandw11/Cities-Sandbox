using HSVPicker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightProperties : MonoBehaviour, ObjectProperties
{
    public GameObject ui;

    public float intensity;
    public int range;
    public Color lightColor;
    public Color objectColor;

    public void Display(GameObject content)
    {
        int childs = content.transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }

        // Intensity
        GameObject g = Instantiate(ui);
        g.transform.SetParent(content.transform);
        g.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = intensity;
        g.transform.GetChild(0).GetChild(0).GetComponent<Slider>().onValueChanged.AddListener(delegate
        {
            intensity = g.transform.GetChild(1).GetChild(0).GetComponent<Slider>().value;
            gameObject.GetComponentInChildren<Light>().intensity = intensity;
        });
        // Range
        g.transform.GetChild(1).GetChild(0).GetComponent<Slider>().value = range;
        g.transform.GetChild(1).GetChild(0).GetComponent<Slider>().onValueChanged.AddListener(delegate
        {
            range = (int) g.transform.GetChild(1).GetChild(0).GetComponent<Slider>().value;
            gameObject.GetComponentInChildren<Light>().range = range;
        });
        // Light Color
        g.transform.GetChild(2).GetComponent<ColorPicker>().CurrentColor = lightColor;
        g.transform.GetChild(2).GetComponent<ColorPicker>().onValueChanged.AddListener(newColor =>
        {
            lightColor = newColor;
            gameObject.GetComponentInChildren<Light>().color = lightColor;
        });
        // Object Color
        g.transform.GetChild(4).GetComponent<ColorPicker>().CurrentColor = objectColor;
        g.transform.GetChild(4).GetComponent<ColorPicker>().onValueChanged.AddListener(newColor =>
        {
            objectColor = newColor;
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = objectColor;
        });
        content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 450);
        // Set the position of the rectangle.
        g.GetComponent<RectTransform>().localPosition = new Vector3(94, -243, 0);
        g.GetComponent<RectTransform>().localScale = new Vector3(0.6f, 0.6f, 1);
        // Set the scroll bar to go to the top.
        content.transform.parent.parent.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 1);
        // Inform the canvas that it must update.
        Canvas.ForceUpdateCanvases();
    }

    public void Duplicate(ObjectProperties objectProperties)
    {
        LightProperties prop = (LightProperties)objectProperties;
        this.intensity = prop.intensity;
        this.range = prop.range;
        this.lightColor = prop.lightColor;
        this.objectColor = prop.objectColor;

        GetComponentInChildren<Light>().intensity = intensity;
        GetComponentInChildren<Light>().range = range;
        GetComponentInChildren<Light>().color = lightColor;
        transform.GetChild(0).GetComponent<Renderer>().material.color = objectColor;
    }

    public SerObjectProperties GetSerializedData()
    {
        SerLightProperties prop = new SerLightProperties();
        prop.intensity = intensity;
        prop.range = range;
        prop.lightColorR = lightColor.r;
        prop.lightColorG = lightColor.g;
        prop.lightColorB = lightColor.b;
        prop.lightColorA = lightColor.a;
        prop.objectColorR = objectColor.r;
        prop.objectColorG = objectColor.g;
        prop.objectColorB = objectColor.b;
        prop.objectColorA = objectColor.a;
        return prop;
    }

    public bool SetupSerialziedData(SerObjectProperties serData)
    {
        SerLightProperties prop = (SerLightProperties)serData;

        intensity = prop.intensity;
        range = prop.range;
        lightColor = new Color(prop.lightColorR, prop.lightColorG, prop.lightColorB, prop.lightColorA);
        objectColor = new Color(prop.objectColorR, prop.objectColorG, prop.objectColorB, prop.objectColorA);

        GetComponentInChildren<Light>().intensity = intensity;
        GetComponentInChildren<Light>().range = range;
        GetComponentInChildren<Light>().color = lightColor;
        transform.GetChild(0).GetComponent<Renderer>().material.color = objectColor;

        return true;
    }

    [System.Serializable]
    private class SerLightProperties : SerObjectProperties
    {
        public float intensity;
        public int range;
        // Light Color;
        public float lightColorR;
        public float lightColorG;
        public float lightColorB;
        public float lightColorA;
        // Object Color
        public float objectColorR;
        public float objectColorB;
        public float objectColorG;
        public float objectColorA;
    }
}
