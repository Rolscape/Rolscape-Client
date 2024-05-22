using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_TM1 : UI_Popup
{
    protected int countTimer;
    protected TextMeshProUGUI timerText;
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

    protected virtual void BindUI()
    {
        Bind<Image>(typeof(Images));
        _player = GetImage((int)Images.Player);
    }
    
    protected virtual IEnumerator TimerCoroutine()
    {
        while (true)
        {
            if(countTimer <= 0)
                MissionFailed();     // 미션 실패
        
            SetTimer();
            yield return new WaitForSeconds(1f);            
        }
    }
    
    protected void SetTimer()
    {
        countTimer -= 1;
        timerText.text = (countTimer / 3600).ToString("D2") + ":" + (countTimer / 60 % 60).ToString("D2") + ":" +
                         (countTimer % 60).ToString("D2");
    }
    protected virtual void MissionSuccess()
    {
        // 미션 성공
        Managers.Sound.Play("MissionClear");
        Clear();
    }

    protected virtual void MissionFailed()
    {
        Managers.Sound.Play("MissionFailed");
        Clear();
    }

    protected virtual void Clear()
    {
        Managers.Sound.Play("MainBgm", Define.Sound.Bgm);
        StopAllCoroutines();
        ClosePopupUI();
    }

    protected virtual void SetUI() { }

    public virtual void MoveTile(Vector2Int nextPos)
    {
        Managers.Sound.Play("TM_PuzzleOnSuccess");
    }

    public virtual void PoliceMoveTile(Define.PlayerJob job, Vector2Int nextPos) { }

    public virtual void SetDefaultPos(Vector2Int startPos) { }

    public virtual void SetDefaultPolicePos(Vector2Int studentStartPos, Vector2Int teacherStartPos, Vector2Int studentDestPos, Vector2Int teacherDestPos) { }
}