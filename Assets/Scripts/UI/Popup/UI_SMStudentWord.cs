using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SMStudentWord : UI_SM
{
    private int size;
    private string word;
    public override void Init()
    {
        base.Init();
        BindUI();
        SetWord();
    }

    void Start()
    {
        Init();   
    }

    void BindUI()
    {
        
    }

    void SetWord()
    {
        
    }

    protected override void MissionSuccess()
    {
        base.MissionSuccess();
        Managers.Mission.bStudentWord = true;
    }
}
