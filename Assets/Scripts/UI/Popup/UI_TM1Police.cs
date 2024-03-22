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
    private Color _sColor = Color.red;
    private Color _tColor = Color.blue;

    public int _tCurPos;
    public int _sCurPos;

    public int _teacherDestPos;
    public int _studentDestPos;
    
    public override void Init()
    {
        base.Init();
        _color = Color.red;
        _sColor = Color.red;
        _tColor = Color.blue;

        _grid[_sCurPos].color = _sColor;
        _grid[_tCurPos].color = _tColor;

        _grid[_studentDestPos].color = Color.green;
        _grid[_teacherDestPos].color = Color.black;
    }
    
    public override void PoliceMoveTile(PlayerJob job, int nextPos)
    {
        // TODO 타입에 따라 색깔 다르게 
        if (job == PlayerJob.Student)
        {
            if (_sCurPos == _teacherDestPos)
                _grid[_sCurPos].color = Color.black;
            else if (_sCurPos == _studentDestPos)
                _grid[_sCurPos].color = Color.green;
            else
                _grid[_sCurPos].color = Color.white;

            _grid[nextPos].color = _sColor;
            _sCurPos = nextPos;
        }
        else
        {
            if (_tCurPos == _teacherDestPos)
                _grid[_tCurPos].color = Color.black;
            else if (_tCurPos == _studentDestPos)
                _grid[_tCurPos].color = Color.green;
            else
                _grid[_tCurPos].color = Color.white;

            _grid[nextPos].color = _tColor;
            _tCurPos = nextPos;
        }
    }

    public override void SetDefaultPolicePos(int studentStartPos, int teacherStartPos, int studentDestPos, int teacherDestPos)
    {
        _sCurPos = studentStartPos;
        _tCurPos = teacherStartPos;

        _studentDestPos = studentDestPos;
        _teacherDestPos = teacherDestPos;
        //_grid
    }
}
