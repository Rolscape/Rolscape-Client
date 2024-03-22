using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class UI_TM1Police : UI_TM1
{
    private Color _sColor = Color.red;
    private Color _tColor = Color.blue;

    public int _tCurPos;
    public int _sCurPos;
    
    public override void Init()
    {
        base.Init();
        _color = Color.red;
        _sColor = Color.red;
        _tColor = Color.blue;
        _tCurPos = 0;
        _sCurPos = 0;
    }

    public override void MoveTile(int nextPos)
    {
        _grid[_curPos].color = Color.white;
        // TODO 타입에 따라 색깔 다르게 
        _grid[nextPos].color = _color;
        _curPos = nextPos;
    }
   
}
