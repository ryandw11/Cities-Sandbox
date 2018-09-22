using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public GameObject menuPanel;
	public GameObject settingS;
	public GameObject overlay;
	public GameObject overlaySelection;
    public GameObject controlMenu;
    //a
    public SaveAndLoad sal;

	// Use this for initialization
	void Start () {
		menuPanel.SetActive (false);
        controlMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if (menuPanel.activeSelf) {
				menuPanel.SetActive (false);
				overlay.SetActive (true);
			} else if (settingS.activeSelf) {
				settingS.SetActive (false);
				overlay.SetActive (true);
			}else if (controlMenu.activeSelf)
            {
                controlMenu.SetActive(false);
                overlay.SetActive(true);
            }
			else{
				menuPanel.SetActive (true);
				overlay.SetActive (false);
				overlaySelection.SetActive (false);
			}
		}
	}

	public void mainMenu(){
        //sal.Save(World.name); (unused)
        //Debug.Log(World.name); (unused)
        List<string> s = new List<string>();
        s.Add("Yes");
        s.Add("No");
        WindowUI wui = new WindowUI(WindowImage.INFO, WindowType.YES_NO, s, "Main Menu", "Are you sure you want to go back to the main menu? (Your progress will not be saved)", true, 3, ExitDefault.CLOSEOPERATION);
        
	}

    /**
     * Save the game
     */
    public void saveGame()
    {
        sal.Save(World.name);
        menuPanel.SetActive(false);
        overlay.SetActive(true);
        List<string> s = new List<string>();
        s.Add("Ok");
        WindowUI wui = new WindowUI(WindowImage.INFO, WindowType.OK, s, "Game Saved", "The game has been saved!", false, 10, ExitDefault.CLOSEOPERATION);
    }

	public void settings(){
		menuPanel.SetActive (false);
		settingS.SetActive (true);
	}

    public void controls()
    {
        menuPanel.SetActive(false);
        controlMenu.SetActive(true);
    }
    /*
     * If the player clicks exit game.
     */
    public void exitGame(){
        //sal.Save(World.name);
        List<string> s = new List<string>();
        s.Add("Yes");
        s.Add("No");
        WindowUI wui = new WindowUI(WindowImage.INFO, WindowType.YES_NO, s, "Exit The Game", "Are you sure you want to exit the game? (Any unsaved progress will not be saved.)", true, 2, ExitDefault.CLOSEOPERATION);
        menuPanel.SetActive(false);
        overlay.SetActive(true);
	}
	public void backSettings(){
		settingS.SetActive (false);
		menuPanel.SetActive (true);
	}
    public void backControls()
    {
        controlMenu.SetActive(false);
        menuPanel.SetActive(true);
    }

}
