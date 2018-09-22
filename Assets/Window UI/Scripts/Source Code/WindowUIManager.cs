using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowUIManager {

    private UnityHook uh;

    public WindowUIManager(UnityHook uh)
    {
        this.uh = uh;
    }

    public Sprite getImage(WindowImage type)
    {
        if(type == WindowImage.INFO)
        {
            return uh.info;
        }
        if(type == WindowImage.ERROR)
        {
            return uh.error;
        }
        if(type == WindowImage.WARNING)
        {
            return uh.warnning;
        }
        return uh.info;
    }
}
