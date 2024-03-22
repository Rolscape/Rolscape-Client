using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MissionManager
{
    public Action<Collider> TriggerEnter = null;
    public Action<Collider> TriggerExit = null;

    public Action _mission1 = null;
    

    public void Mission1Start()
    {
        if(_mission1!=null)
            _mission1.Invoke();
    }
}
