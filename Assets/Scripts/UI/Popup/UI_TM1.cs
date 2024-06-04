using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TM1 : UI_TM
{
    enum Texts
    {
        Timer,
    }
    
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
        StartCoroutine(TimerCoroutine());
        Managers.Sound.Play("TM_Slow", Define.Sound.Bgm);
    }
    private void Start()
    {
        Init();
    }

    protected void SetPlayerPos(Vector2Int pos)
    {
        _player.rectTransform.anchoredPosition = pos;
    }

    protected override void BindUI()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));
        timerText = GetText((int)Texts.Timer);
        timerText.text = countTimer.ToString("D2");
        _player = GetImage((int)Images.Player);
    }
    
    public virtual void MoveTile(Vector2Int nextPos)
    {
        Managers.Sound.Play("TM_PuzzleOnSuccess");
    }

    public virtual void PoliceMoveTile(Define.PlayerJob job, Vector2Int nextPos) { }

    public virtual void SetDefaultPos(Vector2Int startPos) { }

    public virtual void SetDefaultPolicePos(Vector2Int studentStartPos, Vector2Int teacherStartPos, Vector2Int studentDestPos, Vector2Int teacherDestPos) { }
}