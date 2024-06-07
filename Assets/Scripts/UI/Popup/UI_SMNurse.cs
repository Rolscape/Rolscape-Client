using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SMNurse : UI_SM
{
    enum Texts
    {
        Timer
    }

    public Image[] answer;
    private int answerCount;
    private bool isGameStart;

    public override void Init()
    {
        base.Init();
        Managers.Sound.Play("MinigameSlow", Define.Sound.Bgm);
        BiundUI();
        StartCoroutine(AnswerView());
    }

    void Start()
    {
        Init();
    }

    void BiundUI()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        countTimer = 30;
        timerText = GetText((int)Texts.Timer);
        //timerText.text = countTimer.ToString("D2");
    }

    IEnumerator AnswerView()
    {
        isGameStart = false;
        answerCount = 5;
        foreach (var img in answer)
        {
            img.color = Random.ColorHSV();
            img.gameObject.SetActive(true);
        }
        yield return null;

        while (true)
        {
            if (answerCount == 0)
            {
                if (!isGameStart)
                    StartGame();
                yield return null;
            }
            else
            {
                timerText.text = answerCount.ToString("D2");
                answerCount--;
                yield return new WaitForSeconds(1f);
            }
        }
    }

    void StartGame()
    {
        isGameStart = true;
        foreach (var img in answer)
        {
            img.gameObject.SetActive(false);
        }

        StopCoroutine(AnswerView());
        timerText.text = countTimer.ToString("D2");
        StartCoroutine(TimerCoroutine());
    }
}
