using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager
{
    public Action KeyDownAction = null;
    public Action KeyUpAction = null;

    public Action<KeyCode> ClickedKeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    public Action AnimationActionStart = null;
    public Action AnimationActionStop = null;

    public bool IsMission { get; set; } = false;
    public bool IsChatting { get; set; } = false;
    private bool _keyPressed = false;
    private bool _pressed = false;
    // 리스너 패턴으로 입력을 받아옴
    public void Update()
    {
        // 키보드 입력이 들어오고 KeyAction을 구독한 오브젝트가 있다면 
        // KeyAction을 구독한 오브젝트에 BroadCasting
        if (!IsChatting)
        {
            if (Input.anyKey && KeyDownAction != null)
            {
                if (!IsMission)
                {
                    // keyPressed가 제대로 찍히는지 로그
                    _keyPressed = true;
                    KeyDownAction.Invoke();
                    AnimationActionStart.Invoke();
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.W))
                        ClickedKeyAction.Invoke(KeyCode.W);
                    else if (Input.GetKeyDown(KeyCode.A))
                        ClickedKeyAction.Invoke(KeyCode.A);
                    else if (Input.GetKeyDown(KeyCode.S))
                        ClickedKeyAction.Invoke(KeyCode.S);
                    else if (Input.GetKeyDown(KeyCode.D))
                        ClickedKeyAction.Invoke(KeyCode.D);

                    AnimationActionStop.Invoke();
                }
            }
            else if (_keyPressed)
            {
                Debug.Log("Key Pressed");
                // 키를 땟을 경우
                _keyPressed = false;
                KeyUpAction.Invoke();
                AnimationActionStop.Invoke();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Escape))
                Managers.UI.Chat.FocusInputField(false);
            AnimationActionStop.Invoke();
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
        KeyUpAction = null;
        KeyDownAction = null;
        MouseAction = null;
    }
}
