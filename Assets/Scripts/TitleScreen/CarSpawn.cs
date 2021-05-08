using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour {

	public GameObject pfCar;
	Transform tf;
	public int ranRange = 10;
	public double maxSeconds = 0.4;

	private double secondsLeft;


	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		secondsLeft = maxSeconds;
	}

	// Update is called once per frame
	void Update () {
		secondsLeft -= Time.deltaTime;
		if (secondsLeft > 0) return;
		SpawnCar ();
		secondsLeft = maxSeconds;
	}
	void SpawnCar(){
		int num = Random.Range (1, ranRange);
		if (num == 2) {
			Destroy (Instantiate (pfCar, tf.position, Quaternion.identity), 40);
		}
	}
}
