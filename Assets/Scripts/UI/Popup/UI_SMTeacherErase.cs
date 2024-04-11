using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_SMTeacherErase : UI_Popup, IPointerDownHandler, IDragHandler, IBeginDragHandler
{
    private float eraserSize = 20.0f;
    private Vector2Int imageSize;
    private Texture2D doodleTexture;
    
    private float totalDragTime; // 누적 드래그 시간
    private float startTime; // 드래그 시작 시간
    private float endTime; // 드래그 종료 시간
    
    private TextMeshProUGUI timerText;
    private int countTimer = 16;


    enum Texts
    {
        Timer,
    }
    
    enum Images
    {
        Background,
        Doodle,
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
        
        timerText = GetText((int)Texts.Timer);
        timerText.text = countTimer.ToString("D2");
    }

    private void Start()
    {
        Init();
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

    // void Erase(Vector2 position)
    // {
    //     Vector2 localPos = GetLocalPosition(position);
    //     Vector2Int texPos = new Vector2Int((int)localPos.x, (int)localPos.y);
    //     Debug.Log($"texPos: {texPos}");
    //     EraseTexture(texPos);
    // }
    //
    // Vector2 GetLocalPosition(Vector2 position)
    // {
    //     Vector2 localPoint;
    //     RectTransformUtility.ScreenPointToLocalPointInRectangle(GetImage((int)Images.Doodle).rectTransform, position, Camera.main, out localPoint);
    //     Debug.Log($"localpos: {localPoint}");
    //     return localPoint;
    // }
    //
    // void EraseTexture(Vector2Int pos)
    // {
    //     for (int x = -Mathf.RoundToInt(eraserSize) / 2; x < Mathf.RoundToInt(eraserSize) / 2; x++)
    //     {
    //         for (int y = -Mathf.RoundToInt(eraserSize) / 2; y < Mathf.RoundToInt(eraserSize) / 2; y++)
    //         {
    //             Vector2 eraserPos = pos + new Vector2(x, y);
    //             Vector2 uv = new Vector2(eraserPos.x / imageSize.x, eraserPos.y / imageSize.y);
    //
    //             if (eraserPos.x >= 0 && eraserPos.x < imageSize.x && eraserPos.y >= 0 && eraserPos.y < imageSize.y)
    //             {
    //                 int pixelX = Mathf.RoundToInt(uv.x * doodleTexture.width);
    //                 int pixelY = Mathf.RoundToInt(uv.y * doodleTexture.height);
    //
    //                 Debug.Log($"ErasePos: {pixelX}, {pixelY}");
    //                 doodleTexture.SetPixel(pixelX, pixelY, Color.clear);
    //             }
    //         }
    //     }
    //     doodleTexture.Apply();
    // }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerEnter == GetImage((int)Images.Doodle).gameObject)
        {
            //Erase(eventData.position);
        }
            
    }
    
    public void OnDrag(PointerEventData eventData)
    {
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
                // 미션 성공
                bool isSuccess = true;

                Managers.Player.MyPlayerController.SendSingleMissionStop(isSuccess);

                ClosePopupUI();
            }
            //Erase(eventData.position);
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
        ClosePopupUI();
    }
}
