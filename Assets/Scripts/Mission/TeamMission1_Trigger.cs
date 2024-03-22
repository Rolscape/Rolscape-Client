using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeamMission1_Trigger : MonoBehaviour
{
    
    public void Init()
    {
        Managers.Mission.TriggerEnter -= OnTriggerEnter;
        Managers.Mission.TriggerEnter += OnTriggerEnter;
        Managers.Mission.TriggerExit -= OnTriggerExit;
        Managers.Mission.TriggerExit += OnTriggerExit;
    }
    
    void Start()
    {
        Init();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        // TODO OnTrigger
        Managers.Mission.Mission1Start();
    }

    private void OnTriggerExit(Collider other)
    {
        // TODO ExitTrigger
    }
}
