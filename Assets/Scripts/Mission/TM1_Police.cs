using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM1_Police : TM1
{
    // Start is called before the first frame update
    protected override void Init()
    {
        base.Init();

        Managers.Mission.PoliceMoveTile -= MoveTile;
        Managers.Mission.PoliceMoveTile += MoveTile;
    }

    protected override void Mission1Start(Define.PathMissionPos startPos, Define.PathMissionPos destPos)
    {
        base.Mission1Start(startPos, destPos);

        _ui = Managers.UI.ShowPopupUI<UI_TM1Police>();
        Vector2Int studentStartPos = Util.GetPos(startPos.StudentPos);
        Vector2Int teacherStartPos = Util.GetPos(startPos.TeacherPos);
        Vector2Int studentDestPos = Util.GetPos(destPos.StudentPos);
        Vector2Int teacherDestPos = Util.GetPos(destPos.TeacherPos);

        _ui.SetDefaultPolicePos(
            studentStartPos,
            teacherStartPos,
            studentDestPos,
            teacherDestPos);
        
    }

    public void MoveTile(Define.PlayerJob job, Define.Pos destPos)
    {
        // TODO
        Vector2Int pos = Util.GetPos(destPos);
        _ui.PoliceMoveTile(job, pos);
    }
}