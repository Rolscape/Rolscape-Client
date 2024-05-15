using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class UI_SMStudentWord : UI_SM
{
    enum InputFields
    {
        InputField,
    }

    enum Texts
    {
        PointText,
        Timer,
        Answer,
    }

    enum Grid
    {
        GridLayout,
    }
    
    private int size;
    private string word;
    private int count=0;
    private TextMeshProUGUI[] texts;

    public override void Init()
    {
        base.Init();
        BindUI();
        SetWord();
        SetTexts();
        SetInputField();
        StartCoroutine(TimerCoroutine());
    }

    void Start()
    {
        Init();
    }

    void BindUI()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<TMP_InputField>(typeof(InputFields));
        Bind<GameObject>(typeof(Grid));

        countTimer = 31;
        timerText = GetText((int)Texts.Timer);
        timerText.text = countTimer.ToString("D2");
    }

    void SetInputField()
    {
        GetText((int)Texts.PointText).text = "A";
        TMP_InputField inputField = Get<TMP_InputField>((int)InputFields.InputField);
        inputField.pointSize = 100;
        inputField.characterLimit = 1;
        inputField.contentType = TMP_InputField.ContentType.Alphanumeric;
        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    void SetWord()
    {
        int idx = Random.Range(1, 49);
        size = Managers.Data.WordDict[idx].size;
        word = Managers.Data.WordDict[idx].word;
        texts = new TextMeshProUGUI[size];
    }

    void SetTexts()
    {
        for (int i = 0; i < size; i++)
        {
            GameObject go = new GameObject();
            go.transform.SetParent(Get<GameObject>((int)Grid.GridLayout).transform);
            texts[i] = go.AddComponent<TextMeshProUGUI>();
            texts[i].text = "?";
            texts[i].alignment = TextAlignmentOptions.CenterGeoAligned;
            texts[i].fontStyle = FontStyles.Underline;
            texts[i].color = Color.black;
        }
    }
    
    void OnEndEdit(string text)
    {
        char[] answer = text.ToCharArray();
        // TODO 정답 체크
        for(int i=0; i<size; i++)
        {
            if (word[i] == answer[0])
            {
                texts[i].text = text;
                count++;
            }
        }
        if(count == size)
            MissionSuccess();
    }
    
}
