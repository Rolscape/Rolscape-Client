using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Protocol;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MissionManager
{
    public Action<Collider> TriggerEnter = null;
    public Action<Collider> TriggerExit = null;

    public Action Mission1Start = null;
    public Action<bool> Mission1End = null;
    public Action<Protocol.Pos> MoveTile = null;
    public Action<PlayerJob, Protocol.Pos> PoliceMoveTile = null;
    public Action<PathGameDestPos> PoliceStart = null;

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

    public void MoveTileInvoke(Protocol.Pos destPos)
    {
        if (MoveTile != null)
            MoveTile.Invoke(destPos);
    }

    public void PoliceStartInvoke(PathGameDestPos destPos)
    {
        if(PoliceStart != null)
            PoliceStart.Invoke(destPos);
    }
    public void Mission1StartInvoke()
    {
        if (Mission1Start != null)
            Mission1Start.Invoke();
    }

    public void PoliceMoveTileInvoke(PlayerJob playerJob, Protocol.Pos destPos)
    {
        if (PoliceMoveTile != null)
            PoliceMoveTile.Invoke(playerJob, destPos);
    }


    public void Mission1EndInvoke(bool isSuccess)
    {
        if (Mission1End != null)
            Mission1End.Invoke(isSuccess);
    }
}
