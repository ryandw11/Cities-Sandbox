using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoveBack : MonoBehaviour {

	public int moveSpeed = 10;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
	}
}
