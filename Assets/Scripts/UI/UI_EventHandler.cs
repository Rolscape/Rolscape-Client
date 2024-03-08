using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// 이벤트가 발생하면 콜백으로 알려주는 핸들러 
public class UI_EventHandler : MonoBehaviour, IBeginDragHandler, IPointerClickHandler, IDragHandler
{
    public Action<PointerEventData> OnBeginDragHandler = null;
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> OnDragHandler = null;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragHandler != null)
            OnBeginDragHandler.Invoke(eventData);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClickHandler != null)
            OnClickHandler.Invoke(eventData);
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragHandler != null)
            OnDragHandler.Invoke(eventData);
    }
}
