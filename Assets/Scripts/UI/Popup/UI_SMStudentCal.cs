using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_SMStudentCal : UI_SM
{
    public enum Panel
    {
        Panel,
    }
    
    public enum Images
    {
        Question,
    }

    public enum InputFields
    {
        InputField,
    }

    public enum Texts
    {
        PointText,
        Answer,
        Timer,
    }

    public enum Solutions
    {
        Question1 = 100,
        Question2 = 6,
        Question3 = 40,
        Question4 = 4,
        Question5 = 6,
        Question6 = 120,
        Question7 = 5,
        Question8 = 23,
        Question9 = 9,
        Question10 = 0,
        Question11 = 200,
        Question12 = 14,
    }
    
    private Dictionary<string, int> solDict = new Dictionary<string, int>();
    private int solution;
    public override void Init()
    {
        base.Init();

        BindUI();
        SetInputField();
        SetImage();
        StartCoroutine(TimerCoroutine());
        Managers.Sound.Play("MinigameSlow", Define.Sound.Bgm);
    }

    void Start()
    {
        Init();
    }

    void BindUI()
    {
        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<TMP_InputField>(typeof(InputFields));
        timerText = GetText((int)Texts.Timer);
        timerText.text = countTimer.ToString("D2");

        foreach (Solutions sol in System.Enum.GetValues(typeof(Solutions)))
        {
            if(!solDict.ContainsKey(sol.ToString()))
                solDict.Add(sol.ToString(), (int)sol);
            
        }
    }

    void SetInputField()
    {
        GetText((int)Texts.PointText).text = "A";
        TMP_InputField inputField = Get<TMP_InputField>((int)InputFields.InputField);
        inputField.transform.localPosition = new Vector3(490.0f, 30.0f, 0.0f);
        inputField.pointSize = 100;
        inputField.characterLimit = 3;
        inputField.contentType = TMP_InputField.ContentType.DecimalNumber;

        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    void SetImage()
    {
        Image image = GetImage((int)Images.Question);
        image.rectTransform.sizeDelta = new Vector2(1500.0f, 800.0f);
        int idx = Random.Range(1, 13);
        
        string key = $"Question{idx}";
        if (solDict.ContainsKey(key))
            solution = solDict[$"Question{idx}"];
        
        Texture2D texture2D = Managers.Resource.Load<Texture2D>($"Arts/Mission/Question/Question{idx}");
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one * 0.5f);
        image.sprite = sprite;
    }

    void OnEndEdit(string text)
    {
        if (string.IsNullOrEmpty(text))
            return;

        int answer = int.Parse(text);
        if(answer == solution)
            MissionSuccess();
        else
            MissionFailed();
    }
    
    protected override IEnumerator TimerCoroutine()
    {
        while (true)
        {
            if(countTimer <= 0)
                MissionFailed();     // 미션 실패
        
            countTimer -= 1;
            timerText.text = (countTimer / 3600).ToString("D2") + ":" + (countTimer / 60 % 60).ToString("D2") + ":" +
                             (countTimer % 60).ToString("D2");
            
            yield return new WaitForSeconds(1f);            
        }
    }
    
    protected override void MissionSuccess()
    {
        // 미션 성공
        Managers.Mission.bStudentCal = true;
        
        base.MissionSuccess();
    }

    protected override void MissionFailed()
    {
        Managers.Mission.bStudentCal = false;

        base.MissionFailed();
    }
}
