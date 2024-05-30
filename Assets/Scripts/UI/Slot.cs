using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
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
        if (Icon() == null)
        {
            IconDrag.beginDraggedIcon.transform.SetParent(transform);
            IconDrag.beginDraggedIcon.transform.position = transform.position;
        }
    }
}
