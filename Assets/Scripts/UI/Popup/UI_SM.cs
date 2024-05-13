using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_SM : UI_Popup
{
    protected int countTimer;
    protected TextMeshProUGUI timerText;
    public override void Init()
    {
        base.Init();
        StartCoroutine(TimerCoroutine());
    }

    protected virtual IEnumerator TimerCoroutine()
    {
        while (true)
        {
            if(countTimer <= 0)
                MissionFailed();     // 미션 실패
        
            SetTimer();
            yield return new WaitForSeconds(1f);            
        }
    }

    protected void SetTimer()
    {
        countTimer -= 1;
        timerText.text = (countTimer / 3600).ToString("D2") + ":" + (countTimer / 60 % 60).ToString("D2") + ":" +
                         (countTimer % 60).ToString("D2");
    }

    protected virtual void MissionSuccess()
    {
        // 미션 성공
        Managers.Sound.Play("MissionClear");
        Clear();
    }

    protected virtual void MissionFailed()
    {
        Managers.Sound.Play("MissionFailed");
        Clear();
    }

    protected virtual void Clear()
    {
        Managers.Sound.Play("MainBgm", Define.Sound.Bgm);
        StopAllCoroutines();
        ClosePopupUI();
    }
}
