using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Nickname : UI_Base
{
    enum Texts
    {
        PointText,
    }
    public override void Init()
    {
        Bind<TextMeshProUGUI>(typeof(Texts));
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Transform parent = transform.parent;
        transform.position = parent.position + Vector3.up*(parent.GetComponent<Collider>().bounds.size.y);
    }
}
