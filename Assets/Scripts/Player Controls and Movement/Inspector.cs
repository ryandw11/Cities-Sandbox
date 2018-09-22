using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
/**
 * Script placed on Main Camera.
 * This Script is used for controling the inspector.
 */
public class Inspector : MonoBehaviour {

	Camera viewCamera;
	public SpawnObject sobj;
	public bool awatingInfoClick = false;
	public bool info = false;
	public GameObject obj;
	public LayerMask buildingMask;
	public GameObject selectedItem;
	public GameObject pnl;
	public InputField x;
	public InputField y;
	public InputField z;
	public InputField xRot;
	public InputField yRot;
	public InputField zRot;
	public Delete del;
    public GameObject transformPanel;
    public GameObject propertiesPanel;
    public Button transformButton;
    public Button propertiesButton;
    public InputField transparencyField;

    public Dropdown inspectorDrop;

	private MeshRenderer mr;
    private InspectorUtils insu;


	//TODO fix the problem with collison

	// Use this for initialization
	void Start () {
		viewCamera = Camera.main; //get the camera
        insu = new InspectorUtils();
        transformPanel.SetActive(true);
        propertiesPanel.SetActive(false);
        transformButton.gameObject.GetComponent<Image>().color = Color.white;
        propertiesButton.gameObject.GetComponent<Image>().color = new Color32(141, 141, 142, 100);
    }


	// Update is called once per frame
	void Update () {

		if (!sobj.awaitingClick && !del.delete) {
			Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
			RaycastHit rayDistance;

			if (Physics.Raycast (ray.origin, ray.direction, out rayDistance, Mathf.Infinity, buildingMask)) { //Sending out a raycast to find the ground position.
				Vector3 point = rayDistance.point;
				Debug.DrawLine (ray.origin, point, Color.blue); //For Testing
				if (Input.GetMouseButtonDown (inspectorDrop.value)) { //Added a setting so it can be changed.
					Collider[] objColliders = Physics.OverlapSphere (point, 0.1f);

					if (!info || selectedItem != objColliders [0].gameObject.transform.root.gameObject) {
						info = true;

						//TODO fix this area
						if (!objColliders [0].gameObject.tag.Equals ("Ground")) {//checks to see if it is not the ground
							if (selectedItem != null) {
								if (selectedItem.GetComponent<MeshRenderer> ().enabled) {
									selectedItem.GetComponent<MeshRenderer> ().enabled = false;
								}
							}
							selectedItem = objColliders [0].gameObject.transform.root.gameObject;
							pnl.SetActive (true);

							mr = selectedItem.GetComponent<MeshRenderer> ();
							mr.enabled = true;
                            
						}
					} else {
                        #region Unused Code
                        /*info = false;
						pnl.SetActive (false);
						del.tg.target = null;
						del.tg.selectedAxis = RuntimeGizmos.Axis.None;
						mr.enabled = false;*/
                        #endregion
                    }
				}//
				
			} else {
				if (Input.GetMouseButton(inspectorDrop.value) && info == true) {// change back to 1 if problems
					info = false;
					pnl.SetActive (false);
					del.tg.ClearTargets();
					//del.tg.selectedAxis = RuntimeGizmos.Axis.None;
					mr.enabled = false;
                    insu.changePanel("transform");
                }
			}
		}//end of if !sobj.awaitingClick
	}

}
