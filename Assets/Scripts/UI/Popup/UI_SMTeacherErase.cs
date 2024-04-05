using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SMTeacherErase : UI_Popup, IPointerDownHandler, IDragHandler
{
    private float eraserSize = 20.0f;
    
    [SerializeField]
    private Texture2D doodleTexture;
    
    [SerializeField]
    private Image doodleImage;
    
    enum Images
    {
        Background,
        Doodle,
    }
    
    public override void Init()
    {
        base.Init();
        
        BindUI();
        
        // Set Cursor Eraser
        // Texture2D texture2D = Managers.Resource.Load<Texture2D>("Arts/Mission/BlackboardErase/Eraser");
        // Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.Auto);
        // SetBackground();
        // SetDoodle();
    }
    
    void SetBackground()
    {
        Texture2D texture2D = Managers.Resource.Load<Texture2D>($"Arts/Mission/BlackboardErase/Background");
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one * 0.5f);
        GetImage((int)Images.Background).sprite = sprite;
    }

    void SetDoodle()
    {
        Texture2D texture2D = Managers.Resource.Load<Texture2D>($"Arts/Mission/BlackboardErase/Doodle");
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one * 0.5f);
        Image image = GetImage((int)Images.Doodle);
        image.sprite = sprite; 

        doodleTexture = image.sprite.texture;
    }

    void BindUI()
    {
        Bind<Image>(typeof(Images));
    }

    private void Start()
    {
        Init();
    }

    void Erase(Vector2 position)
    {
        Vector2 localPos = GetLocalPosition(position);
        Vector2Int texPos = new Vector2Int((int)localPos.x, (int)localPos.y);
        EraseTexture(texPos);
    }

    Vector2 GetLocalPosition(Vector2 position)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(doodleImage.rectTransform, position, null, out Vector2 localPos);
        localPos += new Vector2(doodleImage.rectTransform.rect.width / 2, doodleImage.rectTransform.rect.height / 2);
        return localPos;
    }

    void EraseTexture(Vector2Int pos)
    {
        for (int x = -Mathf.RoundToInt(eraserSize) / 2; x < Mathf.RoundToInt(eraserSize) / 2; x++)
        {
            for (int y = -Mathf.RoundToInt(eraserSize) / 2; y < Mathf.RoundToInt(eraserSize) / 2; y++)
            {
                int eraserX = pos.x + x;
                int eraserY = pos.y + y;
                if (eraserX >= 0 && eraserX < doodleTexture.width && eraserY >= 0 && eraserY < doodleTexture.height)
                {
                    doodleTexture.SetPixel(eraserX, eraserY, Color.clear);
                }
            }
        }
        doodleTexture.Apply();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Erase(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Erase(eventData.position);
    }
}
