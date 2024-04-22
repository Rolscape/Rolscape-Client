using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public struct CurrentMission
{
    public GameObject triggerObject;
    public SM_DefaultTrigger trigger;
    public Define.SingleMissionType type;
}

public class MissionManager
{
    // Single Mission Action
    public Action SMStart = null;
    public Action<bool> SMStop = null;
    
    // Team Mission Action
    
    // Team
    
    
    // Student
    public bool bStudentCal = false;
    
    // Police
    public bool bPoliceCatch = false;
    
    // Teacher
    public bool bTeacherErase = false;

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
                _currnetMission.type = Define.SingleMissionType.SingleIdle;
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
    public Define.SingleMissionType CurrentMissionType { get => _currnetMission.type; }
    
    //public Action<PathMissionPos, PathMissionPos> Mission1Start = null;
    public Action<bool> Mission1End = null;
    //public Action<Pos> MoveTile = null;
    //public Action<PlayerJob, Pos> PoliceMoveTile = null;
    
    public void Init()
    
    {
        
    }

    public void Clear()
    {
        
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

    public void SingleMissionStop(Define.SingleMissionType type, bool isSuccess)
    {
        SMStop(isSuccess);
    }
}
