using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<KeyCode> ClickedKeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    public bool IsMission { get; set; } = false;
    private bool _pressed = false;
    // 리스너 패턴으로 입력을 받아옴
    public void OnUpdate()
    {
        // 키보드 입력이 들어오고 KeyAction을 구독한 오브젝트가 있다면 
        // KeyAction을 구독한 오브젝트에 BroadCasting
        if (Input.anyKey && KeyAction != null && !IsMission)
            KeyAction.Invoke();

        if (IsMission)
        {
            if (Input.GetKeyDown(KeyCode.W))
                ClickedKeyAction.Invoke(KeyCode.W);
            else if (Input.GetKeyDown(KeyCode.A))
                ClickedKeyAction.Invoke(KeyCode.A);
            else if (Input.GetKeyDown(KeyCode.S))
                ClickedKeyAction.Invoke(KeyCode.S);
            else if (Input.GetKeyDown(KeyCode.D))
                ClickedKeyAction.Invoke(KeyCode.D);
        }

        // 마우스 입력에 대한 BroadCasting
        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _pressed = true;

                // TODO Drag 구현
                // 일정 시간(0.2초) 이상 누르고 있다면 and 움직임이 있다면 Drag 상태로 변경 
            }
            else
            {
                if (_pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);

                _pressed = false;
            }
        }
    }

    public void Clear()
    {
        KeyAction = null;
        MouseAction = null;
    }
}
