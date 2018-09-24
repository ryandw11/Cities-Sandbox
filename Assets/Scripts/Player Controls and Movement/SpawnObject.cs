using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class SpawnObject : MonoBehaviour {

	Camera viewCamera;
	GameObject test;
	public String resource = "Test";
	public bool awaitingClick = false;
	public GameObject obj;
	public bool place = true;
    public LayerMask buildingMask;

    // Use this for initialization
    void Start () {
		viewCamera = Camera.main; //get the camera
	}

	//TODO clean up this class	
	
	// Update is called once per frame
	void Update () {

        if (awaitingClick)
        {
            if (place)
            {
                Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
                Plane groundPlane = new Plane(Vector3.up, Vector3.zero); //Grabing a plane
                float rayDistance;

                if (groundPlane.Raycast(ray, out rayDistance))
                { //Sending out a raycast to find the ground position.
                    Vector3 point = ray.GetPoint(rayDistance);
                    Debug.DrawLine(ray.origin, point, Color.red); //For debugging
                    obj.transform.position = new Vector3(point.x, point.y + (obj.transform.localScale.y / 2), point.z);//the y is edited to make it go to the top
                                                                                                                       //point.y + (obj.transform.localScale.y / 2)
                    if (EventSystem.current.IsPointerOverGameObject()) //If the Player's mouse is over the UI.
                    {
                        return;
                    }
                    if (Input.GetKeyDown(new KeyHandler().getKey("SpawnObject")))
                    {

                        Collider[] objColliders = Physics.OverlapSphere(point, 2);
                        StartCoroutine(whileLoop(objColliders, point));//start coroutine
						awaitingClick = false;

                    }
                    else if (Input.GetKeyDown(new KeyHandler().getKey("RotateObject")))
                    {//end mouse if
                        obj.transform.RotateAround(new Vector3(point.x, point.y + (gameObject.transform.localScale.y / 2), point.z), obj.transform.up, Time.deltaTime * 300f);
                    }//end else
                }
            }
            else
            {// place
                Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
				RaycastHit rayDistance;
                

                if (Physics.Raycast(ray.origin, ray.direction, out rayDistance, Mathf.Infinity, buildingMask))
                { //Sending out a raycast to find the ground position. 
					Vector3 point = rayDistance.point;
                    Debug.DrawLine(ray.origin, point, Color.red); //For ddddddddddddd
                    obj.transform.position = new Vector3(point.x, point.y + (obj.transform.localScale.y / 2), point.z);//the y is edited to make it go to the top
                                                                                                                       //point.y + (obj.transform.localScale.y / 2)
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        return;
                    }
                    if (Input.GetKeyDown(new KeyHandler().getKey("SpawnObject")))
                    {
						
						obj.transform.position = new Vector3 (point.x, point.y + (obj.transform.localScale.y / 2), point.z);//where it is placed
						obj.layer = 10;
                        obj.GetComponent<BoxCollider>().enabled = true; //Fixed the movement.
                        awaitingClick = false;



                    }
                    else if (Input.GetKeyDown(new KeyHandler().getKey("RotateObject")))
                    {//end mouse if
                        obj.transform.RotateAround(new Vector3(point.x, point.y + (gameObject.transform.localScale.y / 2), point.z), obj.transform.up, Time.deltaTime * 300f);
                    }//end else
                }
            }
        }
	}//

	public void Place(){
		obj = (GameObject) Instantiate (Resources.Load(resource), new Vector3(-900, 0, -900), Quaternion.identity);
        World.objects.Add(obj, resource);

	}//wow

	IEnumerator whileLoop(Collider[] objColliders, Vector3 point){
		int i = 0;
		while (i < objColliders.Length) {
			if (objColliders [i].gameObject.tag.Equals ("Ground")) {
				obj.transform.position = new Vector3 (point.x, point.y + (obj.transform.localScale.y / 2), point.z);//where it is placed
                obj.layer = 10;
                obj.GetComponent<BoxCollider>().enabled = true;

				break;
			}
			i++;
		}
		yield return null;
	}
}
