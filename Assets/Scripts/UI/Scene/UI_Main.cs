using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_Main : UI_Scene
{
    private int countTimer = 1800;

    private TextMeshProUGUI timerText = null;
    enum Buttons
    {
        PointButton,
    }
    
    enum Texts
    {
        PointText,
        TimerText,
    }
    enum GameObjects
    {
        TestObject,
    }

    enum Images
    {
        ItemIcon,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        GetText((int)Texts.PointText).text = "Settings";
        timerText = GetText((int)Texts.TimerText);
        
        GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);
        
        StartCoroutine(TimerCoroutine());
    }
    
    public void OnButtonClicked(PointerEventData data)
    {
        Debug.Log("Button Clicked!");
    }
    
    IEnumerator TimerCoroutine()
    {
        while (true)
        {
            if(countTimer <= 0)
                MissionFailed();     // 미션 실패
        
            countTimer -= 1;
            timerText.text = (countTimer / 3600).ToString("D2") + ":" + (countTimer / 60 % 60).ToString("D2") + ":" +
                             (countTimer % 60).ToString("D2");
            
            yield return new WaitForSeconds(1f);            
        }
    }

    public void MissionFailed()
    {
        // TODO 미션 실패
    }
}
 