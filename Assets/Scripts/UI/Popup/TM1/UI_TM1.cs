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
        Dest,
        Player,
    }

    public int _curPos;

    public override void Init()
    {
        base.Init();

    }
    private void Start()
    {
        Init();
        BindUI();
        SetUI();
    }

    protected virtual void BindUI()
    {
        Bind<Image>(typeof(Images));
    }

    protected virtual void SetUI() { }

    protected virtual void MoveTile(int nextPos)
    {
        //_grid[_curPos].color = Color.white;
        //_grid[nextPos].color = _color;
        //_curPos = nextPos;
    }

    public virtual void PoliceMoveTile(PlayerJob job, int nextPos)
    {

    }

    public virtual void SetDefaultPos(int startPos)
    {

    }

    public virtual void SetDefaultPolicePos(int studentStartPos, int teacherStartPos, int studentDestPos, int teacherDestPos)
    {

    }
}
