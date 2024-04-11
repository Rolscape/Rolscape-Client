using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TM1Teacher : UI_TM1
{
    public override void Init()
    {
        base.Init();
    }
    
    protected override void SetUI()
    {
        base.SetUI();
        _player = GetImage((int)Images.Player);
        _player.sprite = Managers.Resource.Load<Sprite>("Arts/Mission/TMMove/pinkeraser");
        _player.rectTransform.anchoredPosition = _curPos;
    }

    private void Start()
    {
        Init();
    }

    protected override void MoveTile(Vector2Int nextPos)
    {
        _player.rectTransform.anchoredPosition = nextPos;

        
    }
}
