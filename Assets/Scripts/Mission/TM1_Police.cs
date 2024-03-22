using Protocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM1_Police : TM1
{
    private UI_TM1Police _ui;

    public int _studentPos;
    public int _teacherPos;

    // Start is called before the first frame update
    protected override void Init()
    {
        base.Init();

        Managers.Mission.Mission1Start -= Mission1Start;
        Managers.Mission.Mission1Start += Mission1Start;

        Managers.Mission.PoliceMoveTile -= MoveTile;
        Managers.Mission.PoliceMoveTile += MoveTile;

    }

    protected override void Mission1Start()
    {
        base.Mission1Start();

        _ui = Managers.UI.ShowPopupUI<UI_TM1Police>();
    }

    public void MoveTile(PlayerJob job, Protocol.Pos destPos)
    {
        // TODO
        int pos = destPos.X + (9 * destPos.Y);
        //_ui.MoveTile(pos);
    }
}
