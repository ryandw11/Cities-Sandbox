using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class is for the moving of the camera using wasd.
//LOCATED ON THE MAINCAMERA

public class WASDCam : MonoBehaviour {

	public int moveSpeed;
	public float minX = -360.0f;
	public float maxX = 360.0f;

	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;

	public OnClick settingsButton;
    public Dropdown moveControl;
    public Dropdown moveType;

	float rotationY = 0.0f;
	float rotationX = 0.0f;
	private float zoomSpeed = 20.0f;

    private KeyHandler kh;

    void Start()
    {
        kh = Camera.main.GetComponent<KeyHandler>();
    }

    // Update is called once per frame
    void Update () {
		if (!settingsButton.isMenuOpen) {
			float scroll = Input.GetAxis ("Mouse ScrollWheel"); //This gets the scroll
			transform.Translate (0, -(scroll * zoomSpeed), scroll * zoomSpeed, Space.World); //translate the camera. (Inverted so the controls feel right).
            int mouseButton = moveControl.value;
            switch (mouseButton)
            {
                case 0:
                    mouseButton = 2;
                    break;
                case 1:
                    mouseButton = 1;
                    break;
                case 2:
                    mouseButton = 0;
                    break;
            }
            if (moveType.value == 0)
            {
                if (Input.GetKey(kh.getKey("MoveCamera")))
                { //if the mouse is pressed down
                    rotationX += Input.GetAxis("Mouse X") * sensX /** Time.deltaTime*/;
                    rotationY += Input.GetAxis("Mouse Y") * sensY /* *Time.deltaTime*/;
                    //rotationX += Input.GetAxis("Vertical") * 100F * Time.deltaTime;
                    //rotationY += Input.GetAxis("Horizontal") * 100F * Time.deltaTime;
                    rotationY = Mathf.Clamp(rotationY, minY, maxY);
                    transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0); //Angles the camera.
                }
            }
            else
            {
                if (Input.GetKey(kh.getKey("Move_Forward")) || Input.GetKey(kh.getKey("Move_Backwards")) || Input.GetKey(kh.getKey("Move_Left")) || Input.GetKey(kh.getKey("Move_Right")))
                {
                }
                else
                {
                    rotationX += Input.GetAxis("Vertical") * 100F * Time.deltaTime;
                    rotationY += Input.GetAxis("Horizontal") * 100F * Time.deltaTime;
                    //rotationY = Mathf.Clamp(rotationY, minY, maxY);
                    transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0); //Angles the camera.
                }
            }

            if (Input.GetKey (kh.getKey("Move_Forward"))) {
				transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime); //move forward
			}
			if (Input.GetKey (kh.getKey("Move_Left"))) {
				transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);//move right (inverted)
			}
			if (Input.GetKey (kh.getKey("Move_Backwards"))) {
				transform.Translate (Vector3.back * moveSpeed * Time.deltaTime);//move back
			}
			if (Input.GetKey (kh.getKey("Move_Right"))) {
				transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);//move left (inverted)
			}
            if (Input.GetKey(kh.getKey("Reset_Motion"))) // Resets Velocity so that when the camera is going crazy it will be fixed
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
            
		}//end else
	}//end void update
}
