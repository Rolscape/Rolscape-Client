using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _text.text = "TestButton";
    }

    public void OnButtonClicked()
    {
        Debug.Log("Button Clicked!");
    }
}
