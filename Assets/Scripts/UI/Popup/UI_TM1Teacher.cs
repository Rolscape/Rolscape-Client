using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TM1Teacher : UI_TM1
{
    public override void Init()
    {
        base.Init();
        _color = Color.blue;
        _grid[_curPos].color = _color;
    }

    public override void SetDefaultPos(int startPos)
    {
        base.SetDefaultPos(startPos);
        _curPos = startPos;
    }

    public override void MoveTile(int nextPos)
    {
        _grid[_curPos].color = Color.white;
        _grid[nextPos].color = _color;
        _curPos = nextPos;
    }
}
