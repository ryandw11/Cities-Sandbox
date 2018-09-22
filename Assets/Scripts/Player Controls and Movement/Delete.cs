using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Delete : MonoBehaviour {

	Camera viewCamera;
	GameObject test;
	public bool delete = false;
	public GameObject obj;
	public LayerMask buildingMask;
	public RuntimeGizmos.TransformGizmo tg;

	// Use this for initialization
	void Start () {
		viewCamera = Camera.main; //get the camera
	}


	// Update is called once per frame
	void Update () {

		if (delete) {
			Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
			RaycastHit rayDistance;

			if (Physics.Raycast (ray.origin, ray.direction, out rayDistance, Mathf.Infinity, buildingMask)) { //Sending out a raycast to find the ground position.
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                Vector3 point = rayDistance.point;
				Debug.DrawLine (ray.origin, point, Color.red); //For Testing
				if (Input.GetMouseButtonDown (0)) {

					Collider[] objColliders = Physics.OverlapSphere (point, 0.1f);
					int i = 0;

						if (!objColliders [i].gameObject.tag.Equals ("Ground")) {//checks to see if it is not the ground


							if (objColliders [i].gameObject.transform.parent == null) {//check to see if the camera has a parent.
                            tg.ClearTargets();
							//tg.seta = RuntimeGizmos.Axis.None;
								Destroy (objColliders [i].gameObject);
							} else {
                            tg.ClearTargets();
							//tg.selectedAxis = RuntimeGizmos.Axis.None;
								Destroy (objColliders [i].gameObject.transform.root.gameObject);
								
							}
							//removed delete = false;
						}


				}
			}
		}//

	}
}
