using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//LOCATED ON THE SCRIPT MANAGER

public class OnClick : MonoBehaviour {
	public bool isMenuOpen = false;
	public GameObject panel;
	public GameObject ui;

	public Delete del;
	public Inspector ins;
	public RuntimeGizmos.TransformGizmo tg;
	public Camera cam;

	public Button btn;
	public Button ibtn;

	public Sprite delBtn;
	public Sprite delBtnSel;
	public Sprite infBtn;
	public Sprite infBtnSel;

	//TODO fix this class

	void Start(){
		panel.SetActive (false);
		ins.pnl.SetActive (false);
	}

	public void Click(){ //when the settings button is clicked
		if (!isMenuOpen) {
			panel.SetActive (true);
			ui.SetActive (false);
			isMenuOpen = true;

		} else {
			panel.SetActive (false);
			ui.SetActive (true);
			isMenuOpen = false;
		}
	}

	public void Delete(){
		if (del.delete) {
			del.delete = false;
			btn.image.overrideSprite = delBtn;
		} else {
			del.delete = true;
			btn.image.overrideSprite = delBtnSel;
		}
	}

	public void Info(){
		if (!ins.info) {
			ins.awatingInfoClick = true;
			ins.info = true;
			ibtn.image.overrideSprite = infBtnSel;
		} else {
			ins.info = false;
			ins.awatingInfoClick = false;
			ins.pnl.SetActive (false);
			ibtn.image.overrideSprite = infBtn;
		}
	}

	public void Close(){
		if (ins.pnl.activeSelf) {
			ins.pnl.SetActive (false);
			tg.target = null;
			tg.selectedAxis = RuntimeGizmos.Axis.None;
			ins.info = false;
			ins.selectedItem.transform.root.transform.GetComponent<MeshRenderer> ().enabled = false;
		}
	}



}
