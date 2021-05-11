using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public KeyCode defaultKey;
    public string name;
    private GameObject bttn;
    private bool waitingOnType = false;
    private KeyHandler kh;

	// Use this for initialization
	void Start () {
        bttn = this.gameObject;
        bttn.GetComponentInChildren<Text>().text = defaultKey.ToString();
        kh = Camera.main.gameObject.GetComponent<KeyHandler>();
        kh.setDefaultKey(name, defaultKey);
        bttn.GetComponentInChildren<Text>().text = kh.getKey(name).ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (waitingOnType)
        {
            if(!Input.GetKeyDown(KeyCode.None))
            {
                foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(vKey))
                    {
                        bttn.GetComponentInChildren<Text>().text = vKey.ToString();
                        waitingOnType = false;
                        kh.setKey(name, vKey);
                    }
                }
                
            }
        }
	}

    public void onClick()
    {
        waitingOnType = true;
        bttn.GetComponentInChildren<Text>().text = "Press a key...";
    }
}
