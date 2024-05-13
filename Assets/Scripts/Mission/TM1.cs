using Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TM1 : MonoBehaviour
{
    protected UI_TM1 _ui;
    
    protected Vector3 _dir;
    protected virtual void Init()
    {
        Managers.Mission.Mission1Start -= Mission1Start;
        Managers.Mission.Mission1Start += Mission1Start;

        Managers.Mission.Mission1End -= Mission1End;
        Managers.Mission.Mission1End += Mission1End;

        Managers.Input.ClickedKeyAction -= OnKeyboard;
        Managers.Input.ClickedKeyAction += OnKeyboard;
    }

    private void Start()
    {
        Init();
    }

    void OnEnter(Collider other)
    {
        // TEMP code
        // TODO Send to Server trigger
    }

    void OnExit(Collider other)
    {
        
    }

    protected virtual void Mission1Start(PathMissionPos startPos, PathMissionPos destPos)
    {
        // TODO 1번만 실행되게 
        Debug.Log("mission start");

        // TODO Player 움직임 봉쇄
        Managers.Input.IsMission = true;
    }

    protected virtual void Mission1End(bool isSuccess)
    {
        Managers.UI.ClosePopupUI();
        Managers.Input.IsMission = false;
        var ui = Managers.UI.ShowPopupUI<UI_MissionResult>();
        ui.PrintMissionResult(isSuccess);

        // 성공 실패 보여주기
    }

    public void Clear()
    {
        // TODO Player 움직임 복원
        Managers.Input.IsMission = false;
        Managers.Input.ClickedKeyAction -= OnKeyboard;
    }

    protected virtual void OnKeyboard(KeyCode keyCode)
    {

    }
}