using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IconDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject beginDraggedIcon;
    
    // 퍼즐을 틀린 칸에 놓았을 경우 원복할 위치 
    private Vector3 startPosition;

    // Drag 중 UI 레이어에 비정상적으로 보이기 때문에
    // Icon Drag 중 변경할 부모 RectTransform 변수
    private Transform onDragParent;

    // 슬롯이 아닌 다른 오브젝트에 Icon을 드랍할 경우 원복할 부모 백업용 
    [HideInInspector] public Transform startParent;

    private void Start()
    {
        GameObject panel =  GameObject.Find("TM2_MainPanel");
        if (panel != null)
        {
            onDragParent = panel.GetComponent<RectTransform>();
            if(onDragParent==null)
                Debug.Log("Drag Parent is null");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그가 시작될 때 대상 icon의 gameObject를 static 변수에 할당
        beginDraggedIcon = gameObject;
        
        // 백업용 포지션과 부모 트랜스폼을 백업
        startPosition = transform.position;
        startParent = transform.parent;
        
        // drag 이벤트를 정상적으로 감지하기 위해 icon rectTransform을 무시
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        
        // 드래그를 시작할 때 부모 transform을 변경
        transform.SetParent(onDragParent);

    }

    public void OnDrag(PointerEventData eventData)
    {
        // 드래그중에는 아이콘을 마우스나 터치된 포인트의 위치로 이동
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그 대상을 지우고 해당 아이콘에 이벤트 감지를 허용
        beginDraggedIcon = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // 드랍이벤트에 따라 부모가 변경되지 않고
        // 이동중에 할당 되었던 부모 transform과 같다면
        // 아이콘의 위치 원복
        if (transform.parent == onDragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }
}
