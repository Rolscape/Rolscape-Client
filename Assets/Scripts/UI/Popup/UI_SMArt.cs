using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_SMArt : UI_SM
{
    enum Texts
    {
        Timer
    }

    public override void Init()
    {
        base.Init();
        Managers.Sound.Play("MinigameSlow", Define.Sound.Bgm);
        BiundUI();
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    void BiundUI()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));

        countTimer = 30;
        timerText = GetText((int)Texts.Timer);
        timerText.text = countTimer.ToString("D2");
        StartCoroutine(TimerCoroutine());
    }
}
