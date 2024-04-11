using Protocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TM1 : UI_Popup
{
    protected enum Images
    {
        BackGround,
        Player,
    }

    // x, y (100, 65) 단위로 움직이기 
    // minX (-405, 405), minY(-165, 165)
    protected Image _player;
    public Vector2Int _curPos;

    public override void Init()
    {
        base.Init();
        //_curPos = new Vector2Int(-405, -165);
        BindUI();
        SetUI();

    }
    private void Start()
    {
        Init();
    }

    protected void SetPlayerPos(Vector2Int pos)
    {
        _player.rectTransform.anchoredPosition = pos;
    }

    protected virtual void BindUI()
    {
        Bind<Image>(typeof(Images));
        _player = GetImage((int)Images.Player);
    }

    protected virtual void SetUI() { }

    public virtual void MoveTile(Vector2Int nextPos) { }

    public virtual void PoliceMoveTile(PlayerJob job, Vector2Int nextPos) { }

    public virtual void SetDefaultPos(Vector2Int startPos) { }

    public virtual void SetDefaultPolicePos(Vector2Int studentStartPos, Vector2Int teacherStartPos, Vector2Int studentDestPos, Vector2Int teacherDestPos) { }
}
