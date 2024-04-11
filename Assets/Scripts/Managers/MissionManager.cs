using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Protocol;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public struct CurrentMission
{
    public GameObject triggerObject;
    public SM_DefaultTrigger trigger;
    public SingleMissionType type;
}

public class MissionManager
{
    // Team Mission Action

    // Team

    // Single Mission Action To Student
    public Action SMStart = null;
    public Action<bool> SMStop = null;

    // Student
    public bool bStudentCal = false;

    // Police


    // Teacher
    public bool bTeacherErase = false;


    // 현재 미션

    CurrentMission _currnetMission = new CurrentMission();

    public GameObject CurrentMissionTriggerObject
    {
        get => _currnetMission.triggerObject;
        set
        {
            if (value == null)
            {
                _currnetMission.trigger = null;
                _currnetMission.triggerObject = null;
                _currnetMission.type = SingleMissionType.SingleIdle;
            }
            else
            {
                _currnetMission.triggerObject = value;
                _currnetMission.trigger = value.GetComponent<SM_DefaultTrigger>();
                _currnetMission.type = _currnetMission.trigger.missionType;
            }
        }
    }

    public SM_DefaultTrigger CurrentMissoinTrigger { get => _currnetMission.trigger; }
    public SingleMissionType CurrentMissionType { get => _currnetMission.type; }

    public Action<PathMissionPos, PathMissionPos> Mission1Start = null;
    public Action<bool> Mission1End = null;
    public Action<Pos> MoveTile = null;
    public Action<PlayerJob, Pos> PoliceMoveTile = null;

    public void MoveTileInvoke(Pos destPos)
    {
        if (MoveTile != null)
            MoveTile.Invoke(destPos);
    }

    public void Mission1StartInvoke(PathMissionPos startPos, PathMissionPos destPos = null)
    {
        if (Mission1Start != null)
            Mission1Start.Invoke(startPos, destPos);
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

    public void SingleMissionStart(bool isMine = true)
    {
        if (isMine)
        {
            if(SMStart != null)
                SMStart();
            else
            {
                // 실패 처리 해야됨.
            }
        }
        else
        {
            //if (SMStart != null)
            //    SMStart();
        }
    }

    public void SingleMissionStop(SingleMissionType type, bool isSuccess)
    {
        SMStop(isSuccess);
    }
}
