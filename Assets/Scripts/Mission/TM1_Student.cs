using Protocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM1_Student : TM1
{
    private bool _isMoved = false;

    protected override void Init()
    {
        base.Init();

        Managers.Mission.MoveTile -= MoveTile;
        Managers.Mission.MoveTile += MoveTile;
    }

    protected override void Mission1Start()
    {
        base.Mission1Start();

        _ui = Managers.UI.ShowPopupUI<UI_TM1Student>();
    }

    protected override void OnKeyboard(KeyCode keyCode)
    {
        base.OnKeyboard(keyCode);

        CheckMoveNextGrid(keyCode);
    }

    public bool CheckMoveNextGrid(KeyCode code)
    {
        if (_isMoved)
            return false;

        _isMoved = true;
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
        if (!_isMoved)
            return;

        int pos = destPos.X + (9 * destPos.Y);
        _ui.MoveTile(pos);

        _isMoved = false;
    }
}
