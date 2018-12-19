using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    // This class contains information regarding the world itself.

    public static new string name;

    public static bool newWorld;

    public static Dictionary<GameObject, string> objects = new Dictionary<GameObject, string>();

    public static bool day;
}
