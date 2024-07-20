using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_SMMusicOffice : UI_SM
{
    private string answer;
    enum Texts
    {
        Timer
    }

    enum Images
    {
        BackGround,
        Quiz
    }

    enum InputFields
    {
        Answer
    }

    void BindUI()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<TMP_InputField>(typeof(InputFields));
        
        timerText = GetText((int)Texts.Timer);
        
        TMP_InputField inputField = Get<TMP_InputField>((int)InputFields.Answer);
        inputField.onEndEdit.AddListener(OnEndEdit);
    }
    
    public override void Init()
    {
        base.Init();
        BindUI();
        SetQuiz();
        SetTimer();
        StartCoroutine(TimerCoroutine());
        Managers.Sound.Play("MinigameFast", Define.Sound.Bgm);
    }

    void Start()
    {
        Init();
    }

    void SetQuiz()
    {
        int idx = Random.Range(0, Managers.Data.MusicOfficesDict.Count);
        MusicOffice musicOffice = Managers.Data.MusicOfficesDict[idx];
        answer = musicOffice.name;
        GetImage((int)Images.Quiz).sprite = Managers.Resource.Load<Sprite>($"Arts/Mission/MusicOffice/{answer}");
    }
    
    void OnEndEdit(string text)
    {
        if (!String.IsNullOrEmpty(text))
        {
            Debug.Log($"{text}, {answer}");
            if(answer==text)
                MissionSuccess();
            else
                MissionFailed();
        }
    }
    
}
