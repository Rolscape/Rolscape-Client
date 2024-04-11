using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SMPoliceCatch : UI_Popup, IPointerDownHandler
{
    private Image[] hearts = new Image[3];
    private Image[] shadows = new Image[8];
    private Sprite handsup;
    private Sprite handsdown;
    private Sprite heart;
    private Sprite emptyHeart;
    
    private int clickCount = 0;
    private int hp = 2;
    private bool bFind = false;

    private TextMeshProUGUI timerText;
    private int countTimer = 16;
    
    enum Texts
    {
        Timer,
    }

    enum Images
    {
        Note,
        Prison,
        Heart,
        Heart1,
        Heart2,
        Shadow,
        Shadow1,
        Shadow2,
        Shadow3,
        Shadow4,
        Shadow5,
        Shadow6,
        Shadow7,
    }
    
    public override void Init()
    {
        base.Init();
        BindUI();

        Managers.Sound.Play("MinigameFast", Define.Sound.Bgm);
        Managers.Sound.Play("Timer");
        StartCoroutine(TimerCoroutine());
        StartCoroutine(HandsUp());
    }

    void Start()
    {
        Init();
    }

    void BindUI()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<Image>(typeof(Images));

        timerText = GetText((int)Texts.Timer);
        timerText.text = countTimer.ToString("D2");
        
        heart = Managers.Resource.Load<Sprite>("Arts/Mission/Prison/heart");
        emptyHeart = Managers.Resource.Load<Sprite>("Arts/Mission/Prison/blackheart");
        handsup = Managers.Resource.Load<Sprite>("Arts/Mission/Prison/hand");
        handsdown = Managers.Resource.Load<Sprite>("Arts/Mission/Prison/nohand");
        
        for (int i = 0; i < hearts.Length; i++)
            hearts[i] = GetImage((int)Images.Heart + i);

        for (int i = 0; i < shadows.Length; i++)
            shadows[i] = GetImage((int)Images.Shadow + i);
    }
    
    IEnumerator HandsUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            int idx1 = Random.Range(0, 4);
            int idx2 = Random.Range(4, 8);
            shadows[idx1].sprite = handsup;
            shadows[idx2].sprite = handsup;
            yield return new WaitForSeconds(0.7f);
            shadows[idx1].sprite = handsdown;
            shadows[idx2].sprite = handsdown;

            if (clickCount >= 2)
                bFind = true;
            
            clickCount = 0;
            if(!bFind)
                MinusHp();
            bFind = false;            
        }
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

    private void MinusHp()
    {
        if (hp <= 0)
        {
            MissionFailed(); // 미션 실패
            return;
        }
        hearts[hp--].sprite = emptyHeart;
    }

    public void MissionSuccess()
    {
        // 미션 성공
        Managers.Sound.Play("MissionClear");
        Clear();
    }

    public void MissionFailed()
    {
        Managers.Sound.Play("MissionFailed");
        Clear();
    }

    public void Clear()
    {
        Managers.Sound.Play("MainBgm", Define.Sound.Bgm);
        StopAllCoroutines();
        Managers.UI.ClosePopupUI();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // TODO obejct check
        Managers.Sound.Play("Click");
        GameObject gameObject = eventData.pointerCurrentRaycast.gameObject;
        Image image = gameObject.GetComponent<Image>();

        if (image.sprite == handsup)
        {
            image.sprite = handsdown;
            clickCount++;
        }
        else
            MinusHp();
        
    }
}
