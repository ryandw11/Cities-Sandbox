using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectUtils {

    private SpawnObject so;

	public SpawnObjectUtils()
    {
        so = Camera.main.GetComponent<SpawnObject>();
    }

    public void useObject(GameObject g)
    {
        so.awaitingClick = true;
        so.obj = g;
    }
}
