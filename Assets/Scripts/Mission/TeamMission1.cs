using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeamMission1 : MonoBehaviour
{
    public void Init()
    {
        Managers.Mission.TriggerEnter -= OnEnter;
        Managers.Mission.TriggerEnter += OnEnter;
        Managers.Mission.TriggerExit -= OnExit;
        Managers.Mission.TriggerExit += OnExit;
    }

    private void Start()
    {
        Init();
    }

    void OnEnter(Collider other)
    {
        
    }

    void OnExit(Collider other)
    {
        
    }

    public void Mission1Start(GameObject go)
    {
        Debug.Log("Mission1 Start");
    }
}
