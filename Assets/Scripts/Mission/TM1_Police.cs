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

    protected override void Mission1Start(PathGamePos startPos, PathGamePos destPos)
    {
        base.Mission1Start(startPos, destPos);

        _ui = Managers.UI.ShowPopupUI<UI_TM1Police>();
        int studentStartPos = Util.GetPos(startPos.StudentPos);
        int teacherStartPos = Util.GetPos(startPos.TeacherPos);
        int studentDestPos = Util.GetPos(destPos.StudentPos);
        int teacherDestPos = Util.GetPos(destPos.TeacherPos);

        _ui.SetDefaultPolicePos(
            studentStartPos,
            teacherStartPos,
            studentDestPos,
            teacherDestPos);

        //_ui.SetDefaultPolicePos()
        // 목적지 설정
    }

    public void MoveTile(PlayerJob job, Protocol.Pos destPos)
    {
        // TODO
        int pos = Util.GetPos(destPos);
        _ui.PoliceMoveTile(job, pos);
    }
}
