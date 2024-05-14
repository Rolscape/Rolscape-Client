using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class UI_SMStudentWord : UI_SM
{
    private int size;
    private string word;
    public override void Init()
    {
        base.Init();
        BindUI();
        SetInputField();
    }

    void Start()
    {
        Init();   
    }

    void BindUI()
    {
        
    }

    void SetInputField()
    {
        
    }

    void SetWord()
    {
        int idx = Random.Range(1, 49);
        size = Managers.Data.WordDict[idx].size;
        word = Managers.Data.WordDict[idx].word;
    }
    
}
