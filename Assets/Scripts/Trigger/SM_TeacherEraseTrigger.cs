using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_TeacherEraseTrigger : MonoBehaviour
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
        if (Managers.Mission.bTeacherErase)
        {
            Destroy(gameObject);
            return;
        }
        
        Teacher teacher = other.GetComponent<Teacher>();
        if(teacher == null)
            return;
        
        Util.GetOrAddComponent<SM_TeacherErase>(gameObject);

        
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
