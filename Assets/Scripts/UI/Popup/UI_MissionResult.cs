using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class UI_MissionResult : UI_Popup
{
    public string Text {  get; private set; }
    enum Texts
    {
        PointText,
    }
    public override void Init()
    {
        base.Init();
        
        Bind<TextMeshProUGUI>(typeof(Texts));
        GetText((int)Texts.PointText).text = Text;
    }

    void Start()
    {
        Init();
    }

    public void PrintMissionResult(bool clear)
    {
        MissionClear(clear);
        Destroy(gameObject, 5.0f);
    }

    public void MissionClear(bool clear)
    {
        if(clear)
            Text = "Mission Clear";
        else
            Text = "Mission Failed";
        
    }

    
}
