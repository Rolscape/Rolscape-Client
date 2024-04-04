using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM1_Student : TM1
{
    private UI_TM1Student _ui;

    protected override void Init()
    {
        base.Init();
        
    }

    protected override void Mission1Start()
    {
        base.Mission1Start();

        _ui = Managers.UI.ShowPopupUI<UI_TM1Student>();
    }

    protected override void OnKeyboard()
    {
        base.OnKeyboard();

        CheckMoveNextGrid(_dir);
    }

    public bool CheckMoveNextGrid(Vector3 dir)
    {
        int nextPos = _ui._curPos;
        
        if (dir == Vector3.forward)
        {
            nextPos -= _ui._gridSizeX;
        }
        if (dir == Vector3.back)
        {
            nextPos += _ui._gridSizeX;
    
        }
        if (dir == Vector3.left)
        {
            if((nextPos) % _ui._gridSizeX != 0)
                nextPos--;
        }
        if (dir == Vector3.right)
        {
            if((nextPos+1) % _ui._gridSizeX != 0)
                nextPos++;
        }
    
        if (nextPos >= 0 && nextPos < _ui._gridSizeY * _ui._gridSizeX)
        {
            // TODO Change call MoveTile to Action
            _ui.MoveTile(nextPos);
        }
        
        return false;
    }
    
}
