using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
            if (checkPuzzle())
            {               
                // 알맞은 퍼즐 위치 찾음
                // TODO Server Code
                putPuzzle();
            }
        }
    }

    // 알맞은 퍼즐 위치인지 확인
    public bool checkPuzzle()
    {
        string puzzleName = IconDrag.beginDraggedIcon.gameObject.GetComponent<Image>().sprite.name;
        puzzleName = puzzleName.Substring(puzzleName.LastIndexOf('_')+1);
        string slotName = gameObject.name;
        slotName = slotName.Substring(slotName.LastIndexOf('t') + 1);

        return puzzleName.Equals(slotName);
    }

    // 퍼즐을 퍼즐 위치에 놓는 함수
    public void putPuzzle()
    {
        Managers.Mission.CountPuzzle.Invoke();
        IconDrag.beginDraggedIcon.transform.SetParent(transform);
        IconDrag.beginDraggedIcon.transform.position = transform.position;
        flag = false;
    }
}
