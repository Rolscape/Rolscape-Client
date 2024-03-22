using Protocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM1_Teacher : TM1
{
    private UI_TM1Teacher _ui;
    private bool _isMoved = false;

    protected override void Init()
    {
        base.Init();
        
        Managers.Mission.Mission1Start -= Mission1Start;
        Managers.Mission.Mission1Start += Mission1Start;

        Managers.Mission.MoveTile -= MoveTile;
        Managers.Mission.MoveTile += MoveTile;
    }

    protected override void Mission1Start()
    {
        base.Mission1Start();

        _ui = Managers.UI.ShowPopupUI<UI_TM1Teacher>();
    }

    protected override void OnKeyboard()
    {
        base.OnKeyboard();

        CheckMoveNextGrid(_dir);
    }

    public bool CheckMoveNextGrid(Vector3 dir)
    {
        if (_isMoved)
            return false;

        _isMoved = true;
        C_PATH_GAME_MOVE pkt = new C_PATH_GAME_MOVE();
        pkt.PlayerInfo = Managers.Player.MyPlayerController.Info;

        if (dir == Vector3.forward)
        {
            pkt.MoveType = MiniGameMoveType.Up;
        }
        if (dir == Vector3.back)
        {
            pkt.MoveType = MiniGameMoveType.Down;
        }
        if (dir == Vector3.left)
        {
            pkt.MoveType = MiniGameMoveType.Left;
        }
        if (dir == Vector3.right)
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
