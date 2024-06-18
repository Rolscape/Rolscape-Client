using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CrewMap : UI_Popup
{
    enum Maps
    {
        Map
    }
    public override void Init()
    {
        base.Init();
        
        Bind<Image>(typeof(Maps));

        Texture2D texture2D = Managers.Resource.Load<Texture2D>("Arts/Map/CrewMap");
        Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one * 0.5f);

        Image image = GetImage((int)Maps.Map);
        image.sprite = sprite;
    }

    private void Start()
    {
        Init();
    }
}
