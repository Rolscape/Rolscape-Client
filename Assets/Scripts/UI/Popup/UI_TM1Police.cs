using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_TM1Police : UI_TM1
{
    protected new enum Images
    {
        TeacherDest,
        StudentDest,
        Teacher,
        Student,
    }

    private Image _teacher;
    private Image _student;
    
    public Vector2Int _tCurPos;
    public Vector2Int _sCurPos;

    public Vector2Int _teacherDestPos;
    public Vector2Int _studentDestPos;
    
    public override void Init()
    {
        BindUI();
        SetUI();
        
        
    }


    protected override void BindUI()
    {
        Bind<Image>(typeof(Images));
    }

    private void Start()
    {
        Init();
    }

    protected override void SetUI()
    {
        GetImage((int)Images.StudentDest).sprite = Managers.Resource.Load<Sprite>("Arts/Mission/TMMove/bluesquare");
        GetImage((int)Images.TeacherDest).sprite = Managers.Resource.Load<Sprite>("Arts/Mission/TMMove/pinksquare");
        _student = GetImage((int)Images.Student);
        _student.sprite = Managers.Resource.Load<Sprite>("Arts/Mission/TMMove/blueeraser");
        _teacher = GetImage((int)Images.Teacher);
        _teacher.sprite = Managers.Resource.Load<Sprite>("Arts/Mission/TMMove/pinkeraser");
    }

    public void SetDestPos(Vector2Int idx)
    {
        _teacher.rectTransform.anchoredPosition = idx;
    }
   
}
