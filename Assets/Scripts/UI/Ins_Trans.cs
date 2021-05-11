using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ins_Trans : MonoBehaviour {

	public RuntimeGizmos.TransformGizmo tg;

    public DuplicateObject dobk; //Grabs the inspector script

    private InspectorUtils insu;

	// Use this for initialization
	void Start () {
        insu = new InspectorUtils();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			//tg.selectedAxis = RuntimeGizmos.Axis.None;
		}
	}

	public void onTransform(){
		tg.type = RuntimeGizmos.TransformType.Move;
	}

	public void onRotate(){
		tg.type = RuntimeGizmos.TransformType.Rotate;
	}
	public void onScale(){
		tg.type = RuntimeGizmos.TransformType.Scale;
	}

    public void onDuplicate()
    {
        //tg.selectedAxis = RuntimeGizmos.Axis.None;
        dobk.duplicate();
    }

    public void onTransformPanel()
    {
        insu.changePanel("properties");
    }

    public void onPropertiesPanel()
    {
        insu.changePanel("transform");
    }

    public void onEnd()
    {
        insu.ins.selectedItem.GetComponent<BuildableStats>().transparency = System.Convert.ToInt32(insu.ins.transparencyField.text);
    }
}
