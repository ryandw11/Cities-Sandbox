using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableStats : MonoBehaviour {

    public int transparency = 100;
    private int currentTransparency = 100;

    void Update()
    {
        if (transparency != currentTransparency)
        {
            foreach(Renderer m in gameObject.GetComponentsInChildren<Renderer>()) {
                if (m == gameObject.GetComponent<Renderer>())
                    continue;
                Color c = m.material.color;
                c.a = (float)transparency / 100;
                //c.a = 0.3f;
                m.material.color = c;
                if (transparency != 100 && m.material.GetFloat("_Mode") == 0)
                {
                    m.material.SetFloat("_Mode", 2);
                    m.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                    m.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    m.material.SetInt("_ZWrite", 0);
                    m.material.DisableKeyword("_ALPHATEST_ON");
                    m.material.EnableKeyword("_ALPHABLEND_ON");
                    m.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    m.material.renderQueue = 3000;
                }else if (transparency == 100 && m.material.GetFloat("_Mode") == 2)
                {
                    m.material.SetFloat("_Mode", 0);
                    m.material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.SrcAlpha);
                    m.material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    m.material.SetInt("_ZWrite", 0);
                    m.material.DisableKeyword("_ALPHATEST_ON");
                    m.material.EnableKeyword("_ALPHABLEND_ON");
                    m.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                    m.material.renderQueue = 3000;
                }
            }
            currentTransparency = transparency;
        }
    }
}
