using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SM_StudentCalTrigger : MonoBehaviour
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
        if (Managers.Mission.bStudentCal)
        {
            Destroy(gameObject);
            return;
        }
            
        // TODO 미션 했는지 안했는지 여부 및 직업 체크 
        Student student = other.GetComponent<Student>();
        if(student == null)
            return;
        
        // TODO 암산 미션 시작하기 창 띄우기
        Managers.UI.ShowPopupUI<UI_Start>();
    }


    private void OnTriggerExit(Collider other)
    {
        
    }

    public void Clear()
    {
        
    }
}
