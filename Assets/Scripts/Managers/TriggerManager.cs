using System;

using UnityEngine;

public class TriggerManager
{    
    public Action<Collider> TriggerEnter = null;
    public Action<Collider> TriggerExit = null;
    public void OnTriggerEnter(Collider other)
    {
        if (TriggerEnter != null)
            TriggerEnter.Invoke(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (TriggerExit != null)
            TriggerExit.Invoke(other);
    }
}
