using Protocol;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TM1_Teacher : TM1
{
    private bool _isMoved = false;

    protected override void Init()
    {
        base.Init();

        Managers.Mission.MoveTile -= MoveTile;
        Managers.Mission.MoveTile += MoveTile;
    }

    protected override void Mission1Start(PathMissionPos startPos, PathMissionPos destPos)
    {
        base.Mission1Start(startPos, destPos);

        _ui = Managers.UI.ShowPopupUI<UI_TM1Teacher>();
        Vector2Int pos = Util.GetPos(startPos.TeacherPos);
        _ui.SetDefaultPos(pos);
    }

    protected override void OnKeyboard(KeyCode keyCode)
    {
        base.OnKeyboard(keyCode);

        CheckMoveNextGrid(keyCode);
    }

    public bool CheckMoveNextGrid(KeyCode code)
    {
        //if (_isMoved)
        //    return false;

        //_isMoved = true;
        C_PATH_MISSION_MOVE pkt = new C_PATH_MISSION_MOVE();
        pkt.PlayerInfo = Managers.Player.MyPlayerController.Info;

        if (code == KeyCode.W)
        {
            pkt.MoveType = MultiMissionMoveType.Down;
        }
        else if (code == KeyCode.S)
        {
            pkt.MoveType = MultiMissionMoveType.Up;
        }
        else if (code == KeyCode.A)
        {
            pkt.MoveType = MultiMissionMoveType.Left;
        }
        else if (code == KeyCode.D)
        {
            pkt.MoveType = MultiMissionMoveType.Right;
        }

        Managers.Network.Send(pkt, INGAME.PathMissionMove);

        return true;
    }
    public void MoveTile(Protocol.Pos destPos)
    {
        Vector2Int pos = Util.GetPos(destPos);
        _ui.MoveTile(pos);
    }
}
