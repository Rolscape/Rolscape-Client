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
        Mission1Start<Police>(other.gameObject);
    }

    void OnExit(Collider other)
    {
        
    }

    public void Mission1Start<T>(GameObject go) where T : Player
    {
        T player = go.GetComponent<T>();
        player.Mission1Start();

        
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
    }

    public void Clear()
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Mission.TriggerEnter -= OnEnter;
        Managers.Mission.TriggerExit -= OnExit;
    }
    
    
    void OnKeyboard()
    {
        if (Input.anyKeyDown == false)
            return;
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        Vector3 dir = new Vector3(h, 0, v).normalized;

        
        if (Managers.Mission.CheckMoveNextGrid(dir))
        {
        }
        else
        {
                
        }
        
        
    }
}
