using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TittleScreen_Car_Move : MonoBehaviour {

	public int moveSpeed = 10;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
	}
}
