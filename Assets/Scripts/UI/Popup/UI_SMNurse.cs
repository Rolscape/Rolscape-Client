using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SMNurse : UI_SM
{
    enum Texts
    {
        Timer
    }

    public List<Sprite> sources = new List<Sprite>();
    public RectTransform beds;
    public Image[] answer;

    public GameObject exampleView;
    public Image[] example;

    public Image dragObject;
    

    private List<int> answerList = new List<int>();
    private int answerCount;
    private bool isGameStart;
    private bool isDrag;
    private bool isClear;
    private int selectIndex;
    private int slotIndex;

    public override void Init()
    {
        base.Init();
        Managers.Sound.Play("MinigameSlow", Define.Sound.Bgm);
        BiundUI();
        SetAnswer();
        StartCoroutine(AnswerView());
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (isDrag)
        {
            dragObject.GetComponent<RectTransform>().position = Input.mousePosition;

            if (Input.GetMouseButtonUp(0))
            {
                Managers.Sound.Play("Health_Room_misson_02");
                isDrag = false;
                dragObject.gameObject.SetActive(false);
                slotIndex = GetSlotIndex();
                if (slotIndex >= 0)
                {
                    answer[slotIndex].gameObject.SetActive(true);
                }
                else
                {
                    example[selectIndex].gameObject.SetActive(true);
                }
            }
        }

        if (IsClearCheck() && isGameStart && !isClear)
        {
            isClear = true;
            MissionSuccess();
        }
    }

    void BiundUI()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));

        isDrag = false;
        isClear = false;
        dragObject.gameObject.SetActive(false);

        countTimer = 20;
        timerText = GetText((int)Texts.Timer);
        beds.anchoredPosition = new Vector2(0f, -60f);
        exampleView.SetActive(false);
        //timerText.text = countTimer.ToString("D2");
    }

    void SetAnswer()
    {
        answerList.Clear();

        // 0~19Áß ·£´ý
        int random;
        while (true)
        {
            random = Random.Range(0, 19);
            if (!answerList.Exists(match => match == random))
            {
                answerList.Add(random);

                if (answerList.Count == 6)
                    break;
            }
        }
    }

    IEnumerator AnswerView()
    {
        isGameStart = false;
        answerCount = 5;
        for (int i = 0; i < answer.Length; ++i)
        {
            answer[i].sprite = sources[answerList[i]];
            answer[i].gameObject.SetActive(true);
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
        beds.anchoredPosition = new Vector2(-200f, -60f);

        var temp = new List<int>();
        var list = new List<int>() { 0, 1, 2, 3, 4, 5 };
        var random = new System.Random();

        var randomized = list.OrderBy(x => random.Next());
        foreach (var i in randomized)
        {
            temp.Add(i);
        }

        for (int i = 0; i < example.Length; ++i)
        {
            example[temp[i]].sprite = sources[answerList[i]];
        }
        exampleView.SetActive(true);

        StopCoroutine(AnswerView());
        timerText.text = countTimer.ToString("D2");
        StartCoroutine(TimerCoroutine());
    }

    int GetSlotIndex()
    {
        Vector3 mPos = dragObject.GetComponent<RectTransform>().position;

        for (int i = 0; i < answer.Length; ++i)
        {
            if (Vector3.Distance(mPos, answer[i].GetComponent<RectTransform>().position) < 100 && dragObject.sprite.name.Equals(answer[i].sprite.name))
            {
                return i;
            }
        }
        
        return -1;
    }

    bool IsClearCheck()
    {
        int clearCount = 0;
        for (int i = 0; i < answer.Length; ++i)
        {
            if (answer[i].gameObject.activeSelf)
                clearCount++;
        }

        return clearCount == 6;
    }

    public void PointerDown(int _idx)
    {
        isDrag = true;
        selectIndex = _idx;
        example[_idx].gameObject.SetActive(false);
        dragObject.gameObject.SetActive(true);
        dragObject.sprite = example[_idx].sprite;
        Managers.Sound.Play("Health_Room_misson_01");
    }
}
