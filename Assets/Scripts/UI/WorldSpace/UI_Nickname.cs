using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Nickname : UI_Base
{
    public static string NickName { get; set; }
    enum Texts
    {
        PointText,
    }
    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
        GetText((int)Texts.PointText).text = NickName;
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Transform parent = transform.parent;
        transform.position = parent.position + new Vector3(0.0f, 1.5f, 0.0f)*(parent.GetComponent<Collider>().bounds.size.y);
        transform.rotation = Camera.main.transform.rotation;
    }
}
