using Protocol;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_SMStudentCal : UI_Popup
{
    enum Panel
    {
        Panel,
    }
    
    enum Images
    {
        Question,
    }

    enum InputFields
    {
        InputField,
    }

    enum Texts
    {
        PointText,
        Answer,
        Timer,
    }
    
    private TextMeshProUGUI timerText;
    private int countTimer = 16;
    
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
        Texture2D texture2D = Managers.Resource.Load<Texture2D>($"Arts/Mission/Question/Question{idx}");
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one * 0.5f);
        image.sprite = sprite;
    }

    void OnEndEdit(string text)
    {
        Managers.UI.ClosePopupUI();
        // TODO 정답 체크
        Debug.Log($"사용자가 입력한 정담은: {text}");
        // TODO 정답 여부에 따라 
        // 성공 시 정답
        
        // Managers.Mission.bStudentCal = true;
        // 실패 시 다시 시작
        //Managers.UI.ShowPopupUI<UI_Start>();
    }
    
    IEnumerator TimerCoroutine()
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
    
    public void MissionSuccess()
    {
        // 미션 성공
        Managers.Sound.Play("MissionClear");
        Managers.Player.MyPlayerController.SendSingleMissionStop(true);
        Clear();
    }

    public void MissionFailed()
    {
        Managers.Sound.Play("MissionFailed");
        Managers.Player.MyPlayerController.SendSingleMissionStop(false);
        Clear();
    }

    public void Clear()
    {
        Managers.Sound.Play("MainBgm", Define.Sound.Bgm);
        StopAllCoroutines();
        Managers.UI.ClosePopupUI();
    }
}
