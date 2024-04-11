using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SMPoliceCatch : UI_Popup, IPointerClickHandler
{
    private Image[] hearts = new Image[3];
    private Image[] shadows = new Image[8];
    private Sprite handsup;
    private Sprite handsdown;
    private Sprite heart;
    private Sprite emptyHeart;

    private int hp = 2;
    private bool bFind = false;
    
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
        
        heart = Managers.Resource.Load<Sprite>("Arts/Mission/Prison/heart");
        emptyHeart = Managers.Resource.Load<Sprite>("Arts/Mission/Prison/blackheart");
        handsup = Managers.Resource.Load<Sprite>("Arts/Mission/Prison/hand");
        handsdown = Managers.Resource.Load<Sprite>("Arts/Mission/Prison/nohand");
        
        for (int i = 0; i < hearts.Length; i++)
            hearts[i] = GetImage((int)Images.Heart + i);

        for (int i = 0; i < shadows.Length; i++)
            shadows[i] = GetImage((int)Images.Shadow + i);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        // TODO obejct check
        Debug.Log($"object name: {eventData.pointerCurrentRaycast.gameObject.name}");

        bFind = true;
    }

    IEnumerator HandsUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            int idx1 = Random.Range(0, 8);
            int idx2 = Random.Range(0, 8);
            shadows[idx1].sprite = handsup;
            shadows[idx2].sprite = handsup;
            yield return new WaitForSeconds(0.7f);
            shadows[idx1].sprite = handsdown;
            shadows[idx2].sprite = handsdown;
            if(!bFind)
                MinusHp();
            bFind = false;
        }
    }

    private void MinusHp()
    {
        if (hp < 0)
            return;
        
        hearts[hp--].sprite = emptyHeart;
    }

    public void Clear()
    {
        StopCoroutine(HandsUp());
    }
}
