using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SM_PoliceCatchTrigger : MonoBehaviour
{
    public void Init()
    {
        
    }
    
    private void Start()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Managers.Mission.bPoliceCatch)
        {
            Destroy(gameObject);
            return;
        }

        Police police = other.GetComponent<Police>();
        if(police == null)
            return;
        
        Util.GetOrAddComponent<SM_PoliceCatch>(gameObject);
        
        // TODO 암산 미션 시작하기 창 띄우기
        Managers.UI.ShowPopupUI<UI_SMStart>();
    }


    private void OnTriggerExit(Collider other)
    {
        Managers.UI.ClosePopupUI();
    }

    public void Clear()
    {
        
    }
}