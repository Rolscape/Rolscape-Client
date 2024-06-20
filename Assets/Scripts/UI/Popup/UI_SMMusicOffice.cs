using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class UI_SMMusicOffice : UI_SM
{
    private Dictionary<int, string> answer = new Dictionary<int, string>();
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
        Managers.Sound.Play("MingameFast", Define.Sound.Bgm);
    }

    void Start()
    {
        Init();
    }

    void SetQuiz()
    {
        int rand = Random.Range(0, Managers.Data.MusicOfficesDict.Count);
        Debug.Log($"{rand}, {Managers.Data.MusicOfficesDict.Count}");
        MusicOffice musicOffice = Managers.Data.MusicOfficesDict[rand];
        Debug.Log($"{Managers.Data.MusicOfficesDict.Count}, {musicOffice}");
        GetImage((int)Images.Quiz).sprite = Managers.Resource.Load<Sprite>($"Arts/Mission/MusicOffice/{musicOffice.name}");
    }

    void CheckAnswer()
    {
        
    }

    void OnEndEdit(string text)
    {
        Debug.Log($"{text}");
    }
    
}
