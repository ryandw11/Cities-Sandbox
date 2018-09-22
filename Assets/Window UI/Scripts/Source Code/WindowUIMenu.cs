using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowUIMenu
{

    private UnityHook uh;
    private WindowUIManager wum;

    private WindowImage img;
    private WindowType type;
    private List<string> buttons;
    private string title;
    private string error;
    private bool exit;
    private GameObject windowUI;
    public int output = -1;
    private ExitDefault ex;
    private int id;


    public WindowUIMenu(WindowImage wimg, WindowType wtype, List<string> wbuttons, string wtitle, string werror, bool wexit, int id, ExitDefault ex)
    {
        //GameObject unityHook = GameObject.Find("WindowUI");
        uh = Resources.FindObjectsOfTypeAll<UnityHook>()[0];
       // uh = (UnityHook) unityHook.GetComponent(typeof(UnityHook));
        wum = new WindowUIManager(uh);
        windowUI = uh.windowUI;

        uh.activeMenu = this;

        img = wimg;
        type = wtype;
        buttons = wbuttons;
        title = wtitle;
        error = werror;
        exit = wexit;
        this.ex = ex;
        this.id = id;

        display();
    }

    public WindowImage getImage()
    {
        return img;
    }

    public WindowType getType()
    {
        return type;
    }

    public List<string> getButtons()
    {
        return buttons;
    }

    public string getTitle()
    {
        return title;
    }

    public string getError()
    {
        return error;
    }

    public bool hasExit()
    {
        return exit;
    }

    public string getInput()
    {
        return uh.inputField.text;
    }

    /* 
     * Display the gui 
     */
    public void display()
    {
        uh.inputField.gameObject.SetActive(false);
        uh.inputField.text = "";
        Image wimg = uh.image;
        wimg.sprite = wum.getImage(img);
        Text header = uh.textTitle;
        Text info = uh.textError;
        header.text = title;
        info.text = error;

        if (type == WindowType.OK)
        {
            uh.yes.gameObject.SetActive(false);
            uh.no.gameObject.SetActive(false);
            uh.ok.gameObject.SetActive(true);
            uh.ok.gameObject.GetComponentInChildren<Text>().text = buttons[0];
        }
        else if (type == WindowType.YES_NO)
        {
            uh.yes.gameObject.SetActive(true);
            uh.no.gameObject.SetActive(true);
            uh.ok.gameObject.SetActive(false);
            uh.yes.gameObject.GetComponentInChildren<Text>().text = buttons[0];
            uh.no.gameObject.GetComponentInChildren<Text>().text = buttons[1];
        }else if (type == WindowType.INPUTFIELD)
        {
            uh.yes.gameObject.SetActive(false);
            uh.no.gameObject.SetActive(false);
            uh.ok.gameObject.SetActive(true);
            uh.ok.gameObject.GetComponentInChildren<Text>().text = buttons[0];
            uh.inputField.gameObject.SetActive(true);
            uh.inputField.placeholder.GetComponent<Text>().text = buttons[1];
        }
        if (exit)
        {
            uh.exit.gameObject.SetActive(true);
        }
        else
        {
            uh.exit.gameObject.SetActive(false);
        }
        windowUI.SetActive(true);
    }

    /*
     Close the GUI
    */
    public void close()
    {
        windowUI.SetActive(false);
        uh.activeMenu = null;
    }

    public ExitDefault getEx()
    {
        return ex;
    }

    /* 
     * Grabbing the output  
     */

    public int getOutput()
    {
        return output;
    }


    /*
     * Grab the id of the message.
     */
    public int getId()
    {
        return id;
    }
}
