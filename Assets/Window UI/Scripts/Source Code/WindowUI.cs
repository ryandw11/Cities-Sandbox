using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The main class for the Window UI.
/// <para>You must call <see cref="WindowUI.Display"/> in order for the UI to pop up.</para>
/// </summary>
public class WindowUI {

    private WindowUIMenu wum;

    [System.Obsolete]
    public WindowUI(WindowImage image, WindowType type, List<string> buttons, string title, string errorMessage)
    {
        wum = new WindowUIMenu(image, type, buttons, title, errorMessage, true, 0, ExitDefault.CLOSEOPERATION);
    }

    [System.Obsolete]
    public WindowUI(WindowImage image, WindowType type, List<string> buttons, string title, string errorMessage, bool exitButton)
    {
        wum = new WindowUIMenu(image, type, buttons, title, errorMessage, exitButton, 0, ExitDefault.CLOSEOPERATION);
    }

    public WindowUI(WindowImage image, WindowType type, List<string> buttons, string title, string errorMessage, int id)
    {
        wum = new WindowUIMenu(image, type, buttons, title, errorMessage, true, id, ExitDefault.CLOSEOPERATION);
    }

    public WindowUI(WindowImage image, WindowType type, List<string> buttons, string title, string errorMessage, bool exitButton, int id)
    {
        wum = new WindowUIMenu(image, type, buttons, title, errorMessage, exitButton, id, ExitDefault.CLOSEOPERATION);
    }

    public WindowUI(WindowImage image, WindowType type, List<string> buttons, string title, string errorMessage, bool exitButton, int id, ExitDefault defaultCloseOperation)
    {
        wum = new WindowUIMenu(image, type, buttons, title, errorMessage, exitButton, id, defaultCloseOperation);
    }

    public void Display()
    {
        wum.display();
    }

    public void SetBackgroundActive(bool background)
    {
        wum.setBackgroundActive(background);
    }

    public WindowUIMenu GetWindowUIMenu()
    {
        return wum;
    }

}
