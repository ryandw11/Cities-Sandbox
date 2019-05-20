using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Event
{
    private List<IEventHandler> eventHandleList;

    public Event()
    {
        eventHandleList = new List<IEventHandler>();
    }

    public void registerHandler(IEventHandler evh)
    {
        eventHandleList.Add(evh);
    }

    protected List<IEventHandler> getRegisters()
    {
        return eventHandleList;
    }
    /// <summary>
    /// Call an event.
    /// </summary>
    /// <param name="o">The event to be called. Ex: CarHitTriggerEvent <seealso cref="CarHitTriggerEvent"/></param>
    public void callEvent(object o)
    {
        foreach (IEventHandler e in this.getRegisters())
        {
            startEventCall(e, o);
        }
    }

    /// <summary>
    /// Starts the event call.
    /// Grabs all of the methods within the IEventHandler class.
    /// </summary>
    /// <param name="e"></param>
    /// <param name="o">The object event Ex: CarHitTriggerEvent</param>
    private void startEventCall(IEventHandler e, object o)
    {
        Type t = e.GetType();
        foreach (System.Reflection.MethodInfo mi in t.GetMethods())
        {
            if (this.containsHandler(mi))
            {
                triggerEvent(e, mi, o);
            }
        }
    }

    /// <summary>
    /// Check to make sure there is a method that has the attribute [EventHandler]
    /// </summary>
    /// <param name="mi"></param>
    /// <returns></returns>
    private bool containsHandler(System.Reflection.MethodInfo mi)
    {
        foreach (object o in mi.GetCustomAttributes(false))
        {
            if (o.GetType() == typeof(EventHandlerAttribute)) return true;
        }
        return false;
    }

    /// <summary>
    /// Invokes the method that has the correct Parameter.
    /// </summary>
    /// <param name="e">The IEventHandler class.</param>
    /// <param name="mi">THe method info</param>
    /// <param name="o">The parameter that is being called.</param>
    private void triggerEvent(IEventHandler e, System.Reflection.MethodInfo mi, object o)
    {
        bool lookFor = false;
        foreach (System.Reflection.ParameterInfo pi in mi.GetParameters())
        {
            if (pi.ParameterType == o.GetType())
            {
                lookFor = true;
            }
        }

        if (lookFor)
        {
            mi.Invoke(e, new object[] { o });
        }

    }
}
