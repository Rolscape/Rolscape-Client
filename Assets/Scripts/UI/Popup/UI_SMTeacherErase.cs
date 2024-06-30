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
    private Color backgroundColor = new Color(38f / 255f, 67f / 255f, 39f / 255f); // 올바른 색상 설정

    private float eraserSize = 60.0f; // 색칠 크기를 더 크게 설정
    
    private float totalDragTime; // 누적 드래그 시간
    private float startTime; // 드래그 시작 시간
    private float endTime; // 드래그 종료 시간
    
    private Texture2D doodleTexture;
    
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
        Sprite sprite = Managers.Resource.Load<Sprite>($"Arts/Mission/BlackboardErase/WhiteBoard");
        GetImage((int)Images.Background).sprite = sprite;
    }

    void SetDoodle()
    {
        int idx = Random.Range(1, 5);
        Texture2D texture = Managers.Resource.Load<Texture2D>($"Arts/Mission/BlackboardErase/Doodle{idx}");
        doodleTexture = duplicateTexture(texture);
        Sprite sprite = Sprite.Create(doodleTexture, new Rect(0, 0, doodleTexture.width, doodleTexture.height), Vector2.one * 0.5f);
        Image image = GetImage((int)Images.Doodle);
        image.sprite = sprite;
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

    protected override void MissionSuccess()
    {
        Managers.Sound.Play("MissionClear");
        StartCoroutine(FadeOutDoodle(1.0f));
    }
    private IEnumerator FadeOutDoodle(float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            for (int y = 0; y < doodleTexture.height; y++)
            {
                for (int x = 0; x < doodleTexture.width; x++)
                {
                    Color color = doodleTexture.GetPixel(x, y);
                    color.a = Mathf.Lerp(color.a, 0, elapsedTime / duration);
                    doodleTexture.SetPixel(x, y, color);
                }
            }
            doodleTexture.Apply();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 최종적으로 알파 값을 완전히 0으로 설정
        for (int y = 0; y < doodleTexture.height; y++)
        {
            for (int x = 0; x < doodleTexture.width; x++)
            {
                Color color = doodleTexture.GetPixel(x, y);
                color.a = 0;
                doodleTexture.SetPixel(x, y, color);
            }
        }
        doodleTexture.Apply();
        Clear();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그가 시작된 시간 기록
        startTime = Time.time;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerEnter == GetImage((int)Images.Doodle).gameObject)
        {
            Erase(eventData);
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
            Erase(eventData);
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
    
    private void Erase(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            GetImage((int)Images.Doodle).rectTransform, 
            eventData.position, 
            eventData.pressEventCamera, 
            out Vector2 localPoint);

        Vector2 pivot = GetImage((int)Images.Doodle).rectTransform.pivot;
        Vector2 normalizedPoint = new Vector2(
            (localPoint.x + GetImage((int)Images.Doodle).rectTransform.rect.width * pivot.x) / GetImage((int)Images.Doodle).rectTransform.rect.width,
            (localPoint.y + GetImage((int)Images.Doodle).rectTransform.rect.height * pivot.y) / GetImage((int)Images.Doodle).rectTransform.rect.height
        );

        int x = Mathf.RoundToInt(normalizedPoint.x * doodleTexture.width);
        int y = Mathf.RoundToInt(normalizedPoint.y * doodleTexture.height);

        int halfEraserSize = Mathf.RoundToInt(eraserSize / 2.0f);

        for (int i = -halfEraserSize; i < halfEraserSize; i++)
        {
            for (int j = -halfEraserSize; j < halfEraserSize; j++)
            {
                int pixelX = x + i;
                int pixelY = y + j;

                if (pixelX >= 0 && pixelX < doodleTexture.width && pixelY >= 0 && pixelY < doodleTexture.height)
                {
                    doodleTexture.SetPixel(pixelX, pixelY, backgroundColor);
                }
            }
        }

        doodleTexture.Apply();
    }
}
