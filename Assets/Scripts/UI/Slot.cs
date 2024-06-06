using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    private bool flag = true;
    GameObject Icon()
    {
        // 슬롯에 아이템(자식 트랜스폼)이 있으면 아이템의 gameObject를 리턴
        // 슬롯에 아이템(자식 트랜스폼)이 없다면 null을 리턴
        if (transform.childCount > 0)
            return transform.GetChild(0).gameObject;

        return null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        
        // 슬롯이 비어있다면 Icon을 자식으로 추가 위치변경
        if (Icon() == null && flag)
        {
            // 퍼즐 위치 확인 
            string puzzleName = IconDrag.beginDraggedIcon.gameObject.name;
            puzzleName = puzzleName.Substring(puzzleName.LastIndexOf('e')+1);
            string slotName = gameObject.name;
            slotName = slotName.Substring(slotName.LastIndexOf('t') + 1);
            
            if (puzzleName.Equals(slotName))
            {                
                Managers.Mission.putPuzzleAction.Invoke();
                IconDrag.beginDraggedIcon.transform.SetParent(transform);
                IconDrag.beginDraggedIcon.transform.position = transform.position;
                flag = false;
            }
        }
    }
}
