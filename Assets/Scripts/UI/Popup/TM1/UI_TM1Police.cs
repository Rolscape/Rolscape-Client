using Protocol;
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
    private Image _teacherDest;
    private Image _studentDest;

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
        _studentDest = GetImage((int)Images.StudentDest);
        _studentDest.sprite = Managers.Resource.Load<Sprite>("Arts/Mission/TMMove/bluesquare");
        _studentDest.rectTransform.anchoredPosition = _studentDestPos;

        _teacherDest = GetImage((int)Images.TeacherDest);
        _teacherDest.sprite = Managers.Resource.Load<Sprite>("Arts/Mission/TMMove/pinksquare");
        _teacherDest.rectTransform.anchoredPosition = _teacherDestPos;

        _student = GetImage((int)Images.Student);
        _student.sprite = Managers.Resource.Load<Sprite>("Arts/Mission/TMMove/blueeraser");
        _student.rectTransform.anchoredPosition = _sCurPos;

        _teacher = GetImage((int)Images.Teacher);
        _teacher.sprite = Managers.Resource.Load<Sprite>("Arts/Mission/TMMove/pinkeraser");
        _teacher.rectTransform.anchoredPosition = _tCurPos;
    }

    public override void SetDefaultPolicePos(Vector2Int studentStartPos, Vector2Int teacherStartPos, Vector2Int studentDestPos, Vector2Int teacherDestPos)
    {
        //_student.
        _sCurPos = studentStartPos;
        _tCurPos = teacherStartPos;

        _studentDestPos = studentDestPos;
        _teacherDestPos= teacherDestPos;
    }

    public override void PoliceMoveTile(PlayerJob job, Vector2Int nextPos)
    {
        if(job == PlayerJob.Student)
        {
            _student.rectTransform.anchoredPosition = nextPos;
        }
        else if(job == PlayerJob.Teacher)
        {
            _teacher.rectTransform.anchoredPosition = nextPos;
        }
    }
}
