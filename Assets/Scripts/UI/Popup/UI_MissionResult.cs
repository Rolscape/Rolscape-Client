using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class UI_MissionResult : UI_Popup
{
    enum Texts
    {
        PointText,
    }
    public override void Init()
    {
        base.Init();
        
        Bind<TextMeshProUGUI>(typeof(Texts));
    }

    void Start()
    {
        Init();
    }

    public void PrintMissionResult(bool clear)
    {
        MissionClear(clear);
        Destroy(gameObject, 1.0f);
    }

    public void MissionClear(bool clear)
    {
        if(clear)
            GetText((int)Texts.PointText).text = "Mission Clear";
        else
            GetText((int)Texts.PointText).text = "Mission Failed";
        
    }

    
}
