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

    public Action Mission1Start = null;
    public Action Mission1End = null;
    public Action<int> MoveTile = null;

    public void OnTriggerEnter(Collider other)
    {
        TriggerEnter.Invoke(other);
    }
    
    public void OnTriggerExit(Collider other)
    {
        TriggerExit.Invoke(other);
    }

    public void MoveTileInvoke(int nextPos)
    {
        if(MoveTile!=null)
            MoveTile.Invoke(nextPos);
    }
    
    public void Mission1StartInvoke()
    {
        if(Mission1Start!=null)
            Mission1Start.Invoke();
    }

    public void Mission1EndInvoke()
    {
        if(Mission1End!=null)
            Mission1End.Invoke();
    }
}
