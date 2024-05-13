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
        size = 3;
        word = "pen";
    }
    
}
