using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TM1 : MonoBehaviour
{
    protected Vector3 _dir;
    protected virtual void Init()
    {
        // Managers.Mission.TriggerEnter -= OnEnter;
        // Managers.Mission.TriggerEnter += OnEnter;
        // Managers.Mission.TriggerExit -= OnExit;
        // Managers.Mission.TriggerExit += OnExit;
       
    }

    private void Start()
    {
        Init();
    }

    void OnEnter(Collider other)
    {
        // TEMP code
        // TODO Send to Server trigger
        // Managers.Mission.Mission1Start();
    }

    void OnExit(Collider other)
    {
        
    }

    protected virtual void Mission1Start()
    {
        // TODO 1번만 실행되게 
        Debug.Log("mission start");
        
        // TODO Player 움직임 봉쇄
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
    }

    public void Clear()
    {
        // TODO Player 움직임 복원
        Managers.Input.KeyAction -= OnKeyboard;
        
    }
    
    
    protected virtual void OnKeyboard()
    {
        if (Input.anyKeyDown)
            return;
        
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        _dir = new Vector3(h, 0, v).normalized;
        
        // if (Managers.Mission.CheckMoveNextGrid(dir))
        // {
        //     
        // }
        // else
        // {
        //         
        // }
    }
}
