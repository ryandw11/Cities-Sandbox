using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowUI {

    [System.Obsolete]
    public WindowUI(WindowImage image, WindowType type, List<string> buttons, string title, string errorMessage)
    {
        WindowUIMenu wum = new WindowUIMenu(image, type, buttons, title, errorMessage, true, 0, ExitDefault.CLOSEOPERATION);
    }

    [System.Obsolete]
    public WindowUI(WindowImage image, WindowType type, List<string> buttons, string title, string errorMessage, bool exitButton)
    {
        WindowUIMenu wum = new WindowUIMenu(image, type, buttons, title, errorMessage, exitButton, 0, ExitDefault.CLOSEOPERATION);
    }

    public WindowUI(WindowImage image, WindowType type, List<string> buttons, string title, string errorMessage, int id)
    {
        WindowUIMenu wum = new WindowUIMenu(image, type, buttons, title, errorMessage, true, id, ExitDefault.CLOSEOPERATION);
    }

    public WindowUI(WindowImage image, WindowType type, List<string> buttons, string title, string errorMessage, bool exitButton, int id)
    {
        WindowUIMenu wum = new WindowUIMenu(image, type, buttons, title, errorMessage, exitButton, id, ExitDefault.CLOSEOPERATION);
    }

    public WindowUI(WindowImage image, WindowType type, List<string> buttons, string title, string errorMessage, bool exitButton, int id, ExitDefault defaultCloseOperation)
    {
        WindowUIMenu wum = new WindowUIMenu(image, type, buttons, title, errorMessage, exitButton, id, defaultCloseOperation);
    }

}
