using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Protocol;
using UnityEngine;

public class MyPlayerController : PlayerController
{
    private bool _isLeader;
    public bool _isMission = false;

    // Start is called before the first frame update
    private const float TickTime = 0.1f;
    private float _lastTick = TickTime;
    private Vector3 _movedir = Vector3.zero;
    protected override void Init()
    {
        base.Init();

        KeyActionOutput();
        KeyActionInput();

        Managers.UI.MakeWorldSpaceUI<UI_Nickname>(transform);

        //Player player = GetComponent<Player>();
        //_isLeader = player._isLeader;

        _moveInfo.Type = MoveType.MoveIdle;
        //Managers.Resource.Instantiate("UI/UI_Button");
    }

    protected override void UpdateController()
    {
        _lastTick -= Time.deltaTime;

        if (_lastTick < 0.0f)
        {
            UpdateMoving();
            _lastTick = TickTime;
        }
    }

    protected override void UpdateMoving()
    {
        if (_moveInfo.Type == MoveType.MoveIdle)
            return;

        SendMovePacket();
    }

    public void KeyActionInput()
    {
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.MouseAction += OnMouseClicked;
        Managers.Input.AnimationActionStart += OnAnimationStart;
        Managers.Input.AnimationActionStop += OnAnimationStop;
    }

    public void KeyActionOutput()
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.AnimationActionStart -= OnAnimationStart;
        Managers.Input.AnimationActionStop -= OnAnimationStop;
    }

    void Start()
    {
        Init();
    }

    void OnKeyboard()
    {
        if (_isMission)
            return;

        if (Input.GetKey(KeyCode.Escape))
        {
            Managers.UI.ClosePopupUI();
        }
        else if (Input.GetKey(KeyCode.M))
        {
            // TODO 중복으로 열리지 않게
            if (_isLeader)
                Managers.UI.ShowPopupUI<UI_LeaderMap>();
            else
                Managers.UI.ShowPopupUI<UI_CrewMap>();
        }
        else
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 dir = new Vector3(h, 0, v).normalized;
            // TODO CharcterController

            if (dir != Vector3.zero)
            {
                _characterController.Move(dir * (_speed * Time.deltaTime));
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.3f);

                _movedir = dir;

                if (MoveInfo.Type == MoveType.MoveIdle)
                {
                    SendMovePacket();
                }
            }
            else
            {
                if (MoveInfo.Type == MoveType.MoveWalk)
                {
                    SendStopPacket();
                }
            }
        }
    }
    // 멈추는 작업이 필요하다.

    // CallBack Func When Mouse Event 
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;

        // TODO Mouse Event 

    }

    public void OnAnimationStart()
    {
        _animator.SetFloat("Speed", _speed);
    }

    public void OnAnimationStop()
    {
        _animator.SetFloat("Speed", 0.0f);
    }

    void SendMovePacket()
    {
        Vector3 pos = transform.position;

        MoveInfo.Id = MoveInfo.Id;
        MoveInfo.PosX = pos.x;
        MoveInfo.PosZ = pos.z;

        MoveInfo.DirX = _movedir.x;
        MoveInfo.DirZ = _movedir.z;

        MoveInfo.Type = MoveType.MoveWalk;

        C_MOVE pkt = new C_MOVE();
        pkt.MoveInfo = MoveInfo;
        Managers.Network.Send(pkt, INGAME.Move);
    }

    void SendStopPacket()
    {
        Vector3 pos = transform.position;

        MoveInfo.Id = MoveInfo.Id;
        MoveInfo.PosX = pos.x;
        MoveInfo.PosZ = pos.z;
        MoveInfo.Type = MoveType.MoveIdle;

        C_MOVE pkt = new C_MOVE();
        pkt.MoveInfo = MoveInfo;
        Managers.Network.Send(pkt, INGAME.Move);
    }
}
