using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UI_Button : UI_Base
{
    enum Buttons
    {
        PointButton,
    }
    
    enum Texts
    {
        PointText,
        TimerText,
    }

    enum GameObjects
    {
        TestObject,
    }
    
    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        GetText((int)Texts.TimerText).text = "Timer";
    }

    

    public void OnButtonClicked()
    {
        Debug.Log("Button Clicked!");
    }
}
 