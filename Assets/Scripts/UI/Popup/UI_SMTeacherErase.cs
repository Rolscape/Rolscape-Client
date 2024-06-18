using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_SMTeacherErase : UI_SM, IPointerDownHandler, IDragHandler, IBeginDragHandler
{
    [SerializeField] private Color backgroundColor = new Color(38, 67, 39);

private float eraserSize = 20.0f;
    private Vector2Int imageSize;
    private Texture2D doodleTexture;
    
    private float totalDragTime; // 누적 드래그 시간
    private float startTime; // 드래그 시작 시간
    private float endTime; // 드래그 종료 시간
    
    public enum Texts
    {
        Timer
    }
    
    public enum Images
    {
        Background,
        Doodle
    }
    
    public override void Init()
    {
        base.Init();
        BindUI();
        SetBackground();
        SetDoodle();
        StartCoroutine(TimerCoroutine());
        Managers.Sound.Play("MinigameSlow", Define.Sound.Bgm);
    }
    
    void SetBackground()
    {
        Texture2D texture2D = Managers.Resource.Load<Texture2D>($"Arts/Mission/BlackboardErase/WhiteBoard");
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one * 0.5f);
        GetImage((int)Images.Background).sprite = sprite;
    }

    void SetDoodle()
    {
        int idx = Random.Range(1, 5);
        Texture2D texture = Managers.Resource.Load<Texture2D>($"Arts/Mission/BlackboardErase/Doodle{idx}");
        Texture2D texture2D = duplicateTexture(texture);
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one * 0.5f);
        Image image = GetImage((int)Images.Doodle);
        image.sprite = sprite;

        imageSize = new Vector2Int((int)image.rectTransform.rect.width, (int)image.rectTransform.rect.height);
        doodleTexture = image.sprite.texture;
    }

    void BindUI()
    {
        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(Texts));

        countTimer = 16;
        timerText = GetText((int)Texts.Timer);
        timerText.text = countTimer.ToString("D2");
    }

    private void Start()
    {
        Init();
    }
    
    

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerEnter == GetImage((int)Images.Doodle).gameObject)
        {
            // TODO Call Erase Board Func
        }
            
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        int idx = Random.Range(0, 6);
        Managers.Sound.Play($"SM_TeacherEraser{idx}", Define.Sound.Effect);
        if (eventData.pointerEnter == GetImage((int)Images.Doodle).gameObject)
        {
            // 드래그가 종료된 시간 기록
            endTime = Time.time;

            // 드래그에 소요된 시간 계산하여 누적
            totalDragTime += (endTime - startTime) * Time.deltaTime;
            Debug.Log("누적 드래그 시간: " + totalDragTime + "초");
            if (totalDragTime >= 5.0f)
            {
                MissionSuccess();
            }
            // TODO Call Erase Baord Func
        }
            
    }
    
    Texture2D duplicateTexture(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
            source.width,
            source.height,
            0,
            RenderTextureFormat.Default,
            RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그가 시작된 시간 기록
        startTime = Time.time;
    }
    
}
