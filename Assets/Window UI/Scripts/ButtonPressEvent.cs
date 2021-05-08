using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This handles the clicking of the UI.
/// </summary>
public class ButtonPressEvent : MonoBehaviour{

    public PlayUI pui;
    
    /*
     * Used to detect when a button is pressed for the window. use e.getId() to tell what window was interacted with.
     * Use e.getOutput() to get what button was pressed.
     * -1 = none.
     * 0 = Yes
     * 1 = no
     * 2 = ok
     * 3 = exit
     */
    public void buttonPressed(WindowUIEvent e)
    {
        if(e.getId() == 4)
        {
            if(e.getOutput() == 2)
            {
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
        }
        else if(e.getId() == 3)
        {
            if(e.getOutput() == 0)
            {
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
        }
        else if(e.getId() == 2)
        {
            if(e.getOutput() == 0)
            {
                Application.Quit();
            }
        }
        else if(e.getId() == 8)
        {
            pui.rWorld(e.getInput());
        }
        else if(e.getId() == 22)
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}
