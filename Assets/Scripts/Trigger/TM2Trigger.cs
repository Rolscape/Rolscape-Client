using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM2Trigger : MonoBehaviour
{
    public void Init()
    {
        Managers.Mission.Mission2Start -= Mission2Start;
        Managers.Mission.Mission2Start += Mission2Start;

        Managers.Mission.Mission2End -= Mission2End;
        Managers.Mission.Mission2End += Mission2End;
        
    }
    
    void Start()
    {
        Init();
    }
    
    public void OnShowUI()
    {
        Managers.UI.ShowPopupUI<UI_TM2>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // TODO OnTrigger
        
    }

    private void OnTriggerExit(Collider other)
    {
        // TODO ExitTrigger
        
    }
    
    protected virtual void Mission2Start()
    {
        // TODO 1번만 실행되게 
        Debug.Log("mission start");

        // TODO Player 움직임 봉쇄
        Managers.Input.bIsMission = true;
    }

    protected virtual void Mission2End(bool isSuccess)
    {
        Managers.UI.ClosePopupUI();
        Managers.Input.bIsMission = false;
        var ui = Managers.UI.ShowPopupUI<UI_MissionResult>();
        ui.PrintMissionResult(isSuccess);

        // 성공 실패 보여주기
    }

    public void Clear()
    {
        // TODO Player 움직임 복원
        Managers.Input.bIsMission = false;
    }
    
}
