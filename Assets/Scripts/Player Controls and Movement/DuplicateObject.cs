using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateObject : MonoBehaviour {

    private Inspector ins;
    private SpawnObject spawnOBJ;
    private InspectorUtils insu;
    private KeyHandler keyHandler;


    // Use this for initialization
    void Start () {
        ins = Camera.main.GetComponent<Inspector>();
        spawnOBJ = Camera.main.GetComponent<SpawnObject>();
        insu = new InspectorUtils();
        keyHandler = Camera.main.GetComponent<KeyHandler>();
	}

    void Update()
    {
        if (ins.info && Input.GetKeyDown(keyHandler.getKey("DuplicateObject")))
        {
            duplicate();
        }
    }

    // Update is called once per frame
    public void duplicate () {
        BuildableProperties bp = ins.selectedItem.gameObject.GetComponent<BuildableProperties>();
        GameObject duplicated = (GameObject) Instantiate(Resources.Load(bp.resource), ins.selectedItem.transform.position, ins.selectedItem.transform.rotation);
        duplicated.transform.localScale = ins.selectedItem.transform.localScale;
        // Copy over any object properties.
        if (duplicated.GetComponent<ObjectProperties>() != null)
            duplicated.GetComponent<ObjectProperties>().Duplicate(ins.selectedItem.gameObject.GetComponent<ObjectProperties>());

        BuildableStats bs = ins.selectedItem.GetComponent<BuildableStats>();
        if (bs != null) {
            duplicated.GetComponent<BuildableStats>().transparency = bs.transparency; //TODO un-hardcode.
        }

        spawnOBJ.awaitingClick = true;
        spawnOBJ.obj = duplicated;
        World.objects.Add(duplicated, bp.resource);
        insu.clear();



    }
}
