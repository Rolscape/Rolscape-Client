using Protocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM1_Police : TM1
{
    public int _studentPos;
    public int _teacherPos;

    // Start is called before the first frame update
    protected override void Init()
    {
        base.Init();

        Managers.Mission.PoliceMoveTile -= MoveTile;
        Managers.Mission.PoliceMoveTile += MoveTile;
    }

    public void SetDestPos(PathGameDestPos dests)
    {
        _studentPos = (dests.StudentDestPos.X) + (dests.StudentDestPos.Y * 9);
        _teacherPos = (dests.TeacherDestPos.X) + (dests.TeacherDestPos.Y * 9);
    }

    protected override void Mission1Start()
    {
        base.Mission1Start();

        _ui = Managers.UI.ShowPopupUI<UI_TM1Police>();
        // 목적지 설정
    }

    public void MoveTile(PlayerJob job, Protocol.Pos destPos)
    {
        // TODO
        int pos = destPos.X + (9 * destPos.Y);
        _ui.PoliceMoveTile(job, pos);
    }
}
