using Protocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class TM1_Student : TM1
{
    private bool _isMoved = false;

    protected override void Init()
    {
        base.Init();

        Managers.Input.ClickedKeyAction -= OnKeyboard;
        Managers.Input.ClickedKeyAction += OnKeyboard;

        Managers.Mission.MoveTile -= MoveTile;
        Managers.Mission.MoveTile += MoveTile;
    }

    protected override void Mission1Start(PathGamePos startPos, PathGamePos destPos)
    {
        base.Mission1Start(startPos, destPos);

        _ui = Managers.UI.ShowPopupUI<UI_TM1Student>();
        int pos = Util.GetPos(startPos.StudentPos);
        _ui.SetDefaultPos(pos);
    }

    protected override void OnKeyboard(KeyCode keyCode)
    {
        base.OnKeyboard(keyCode);

        CheckMoveNextGrid(keyCode);
    }

    public bool CheckMoveNextGrid(KeyCode code)
    {
        C_PATH_GAME_MOVE pkt = new C_PATH_GAME_MOVE();
        pkt.PlayerInfo = Managers.Player.MyPlayerController.Info;

        if (code == KeyCode.W)
        {
            pkt.MoveType = MiniGameMoveType.Down;
        }
        else if (code == KeyCode.S)
        {
            pkt.MoveType = MiniGameMoveType.Up;
        }
        else if (code == KeyCode.A)
        {
            pkt.MoveType = MiniGameMoveType.Left;
        }
        else if (code == KeyCode.D)
        {
            pkt.MoveType = MiniGameMoveType.Right;
        }

        Managers.Network.Send(pkt, INGAME.PathGameMove);

        return true;
    }

    public void MoveTile(Protocol.Pos destPos)
    {
        int pos = Util.GetPos(destPos);
        _ui.MoveTile(pos);
    }
}
