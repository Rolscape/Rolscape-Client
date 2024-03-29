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
        
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

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

        if (Input.GetKey(KeyCode.M))
        {
            // TODO 중복으로 열리지 않게
            if (_isLeader)
                Managers.UI.ShowPopupUI<UI_LeaderMap>();
            else
                Managers.UI.ShowPopupUI<UI_CrewMap>();
        }
        
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

            _animator.SetFloat("Speed", _speed);
        }
        else
        {
            if (MoveInfo.Type == MoveType.MoveWalk)
            {
                SendStopPacket();
            }

            _animator.SetFloat("Speed", 0.0f);
        }
    }

    // CallBack Func When Mouse Event 
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;

        // TODO Mouse Event 
        // RayCasting Etc
        
    }

    void SendMovePacket()
    {
        Vector3 pos = transform.position;

        PlayerMoveInfo moveInfo = new PlayerMoveInfo();
        moveInfo.Id = MoveInfo.Id;
        moveInfo.PosX = pos.x;
        moveInfo.PosZ = pos.z;

        moveInfo.DirX = _movedir.x;
        moveInfo.DirZ = _movedir.z;

        moveInfo.Type = MoveType.MoveWalk;

        C_MOVE pkt = new C_MOVE();
        pkt.MoveInfo = moveInfo;
        Managers.Network.Send(pkt, INGAME.Move);
    }

    void SendStopPacket()
    {
        MoveInfo.Type = MoveType.MoveIdle;
        Vector3 pos = transform.position;
        
        PlayerMoveInfo moveInfo = new PlayerMoveInfo();
        moveInfo.Id = MoveInfo.Id;
        moveInfo.PosX = pos.x;
        moveInfo.PosZ = pos.z;
        moveInfo.Type = MoveType.MoveIdle;

        C_MOVE pkt = new C_MOVE();
        pkt.MoveInfo = moveInfo;
        Managers.Network.Send(pkt, INGAME.Move);
    }
}
