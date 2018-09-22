using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnityHook : MonoBehaviour {

    public Button yes;
    public Button no;
    public Button ok;
    public Button exit;
    public Image image;
    public Text textTitle;
    public Text textError;
    public GameObject windowUI;
    public ButtonPressEvent ev;
    public WindowUIMenu activeMenu;
    public InputField inputField;

    public Sprite info;
    public Sprite error;
    public Sprite warnning;

    
    /*
     * Button Hooks
     */

    public void Yes()
    {
        if(activeMenu == null)
        {
            Debug.LogWarning("Error: There is not active menu.");
            return;
        }
        activeMenu.output = 0;
        ev.buttonPressed(new WindowUIEvent(activeMenu.getId(), activeMenu.getOutput(), activeMenu));

    }

    public void No()
    {
        if (activeMenu == null)
        {
            Debug.LogWarning("Error: There is not active menu.");
            return;
        }
        activeMenu.output = 1;
        ev.buttonPressed(new WindowUIEvent(activeMenu.getId(), activeMenu.getOutput(), activeMenu));

    }

    public void Ok()
    {
        if (activeMenu == null)
        {
            Debug.LogWarning("Error: There is not active menu.");
            return;
        }
        activeMenu.output = 2;
        ev.buttonPressed(new WindowUIEvent(activeMenu.getId(), activeMenu.getOutput(), activeMenu));

    }

    public void Exit()
    {
        if (activeMenu == null)
        {
            Debug.LogWarning("Error: There is not active menu.");
            return;
        }
        activeMenu.output = 3;
        ev.buttonPressed(new WindowUIEvent(activeMenu.getId(), activeMenu.getOutput(), activeMenu));

    }

    /*
 * For when all the buttons are tirggered.
 */
    public void allButtonTrigger()
    {
        if (activeMenu.getEx() == ExitDefault.NONE)
        {

        }
        else if (activeMenu.getEx() == ExitDefault.CLOSEOPERATION)
        {
            activeMenu.close();
        }
    }

}
