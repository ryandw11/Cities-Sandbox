using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour {

	public GameObject pfCar;
	Transform tf;
	public int ranRange = 500;


	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		SpawnCar ();
	}
	void SpawnCar(){
		int num = Random.Range (1, ranRange);
		if (num == 30) {
			Destroy (Instantiate (pfCar, tf.position, Quaternion.identity), 40);
		}
	}
}
