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

    public List<GameObject> question;
    public List<GameObject> clearImage;
    public RectTransform imageX;

    private List<GameObject> leftClear = new List<GameObject>();
    private List<GameObject> rightClear = new List<GameObject>();
    private int clearCount;

    public override void Init()
    {
        base.Init();
        Managers.Sound.Play("MinigameSlow", Define.Sound.Bgm);
        BiundUI();
    }

    void Start()
    {
        Init();
        SetGame();
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

    void SetGame()
    {
        foreach (var image in question)
        {
            image.SetActive(false);
        }

        foreach (var image in clearImage)
        {
            image.SetActive(false);
        }

        imageX.gameObject.SetActive(false);
        int random = Random.Range(0, question.Count);
        question[random].SetActive(true);
        clearCount = 0;

        GameObject left = Util.FindChild(question[random], "Left", true);
        GameObject right = Util.FindChild(question[random], "Right", true);

        for (int i = 0; i < clearImage.Count; ++i)
        {
            leftClear.Add(Util.FindChild(left, $"Check_{i}", true));
            rightClear.Add(Util.FindChild(right, $"Check_{i}", true));
        }

        for (int i = 0; i < clearImage.Count; ++i)
        {
            leftClear[i].SetActive(false);
            rightClear[i].SetActive(false);
        }
    }

    void SetDot()
    {
        for (int i = 0; i < clearImage.Count; ++i)
        {
            clearImage[i].SetActive(i < clearCount);
        }
    }

    void DisableX()
    {
        imageX.gameObject.SetActive(false);
    }

    void MissionClear()
    {
        Clear();
    }

    public void OnClick_X()
    {
        imageX.position = Input.mousePosition;
        imageX.gameObject.SetActive(true);
        Invoke("DisableX", 0.5f);
    }

    public void OnClick_O(int _idx)
    {
        leftClear[_idx].SetActive(true);
        rightClear[_idx].SetActive(true);

        leftClear[_idx].transform.parent.GetComponent<Button>().interactable = false;
        rightClear[_idx].transform.parent.GetComponent<Button>().interactable = false;

        clearCount++;
        SetDot();

        if (clearCount == 5)
        {
            Invoke("MissionClear", 0.5f);
        }
    }
}
