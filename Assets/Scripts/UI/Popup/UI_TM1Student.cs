using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_TM1Student : UI_TM1
{
    
    public override void Init()
    {
        base.Init();
        _color = Color.red;
        _grid[_curPos].color = Color.red;
        Debug.Log(_grid[_curPos].color);
    }
    public override void SetDefaultPos(int startPos)
    {
        base.SetDefaultPos(startPos);
        _curPos = startPos;
    }

    public override void MoveTile(int nextPos)
    {
        _grid[_curPos].color = Color.white;
        _grid[nextPos].color = Color.red;
        _curPos = nextPos;
    }
}
