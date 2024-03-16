using Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    protected float _speed = 10.0f;

    protected CharacterController _characterController;
    protected PlayerMoveInfo _moveInfo = new PlayerMoveInfo();
    private Vector3 _destPos = new Vector3(0, 0, 0);

    protected bool _isUpdated = false;

    public PlayerMoveInfo MoveInfo
    {
        get { return _moveInfo; }
        set
        {
            _moveInfo = value;
            _destPos = new Vector3(value.PosX, 0, value.PosZ);
            _isUpdated = true;
        }
    }

    public uint ID
    {
        get { return _moveInfo.Id; }
        set { _moveInfo.Id = value; }
    }

    public PlayerInfo Info
    {
        set
        {
            _moveInfo.Id = value.Id;
            _moveInfo.PosX = value.PosX;
            _moveInfo.PosZ = value.PosZ;
            _moveInfo.Type = MoveType.MoveIdle;
        }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public void SyncPos(Vector3 pos)
    {
        transform.position = pos;
    }

    void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        if (_characterController == null)
        {
            gameObject.AddComponent<CharacterController>();
        }
        _characterController = GetComponent<CharacterController>();
    }
    
    // Update is called once per frame
    private void Update()
    {
        UpdateController();
    }

    protected virtual void UpdateController()
    {
        if (_isUpdated)
        {
            UpdateMoving();
        }
    }

    protected virtual void UpdateMoving()
    {
        Vector3 moveDir = _destPos - transform.position;

        float dist = moveDir.magnitude;
        if (dist < _speed * Time.deltaTime)
        {
            transform.position = _destPos;
            MoveToNextPos();
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.3f);
            transform.position += moveDir.normalized * _speed * Time.deltaTime;
        }
    }

<<<<<<< HEAD
    // 키보드 이벤트 발생 시 

    protected virtual void MoveToNextPos() { }
=======
    protected virtual void MoveToNextPos()
    {
        _isUpdated = false;
    }
>>>>>>> 636b8f2a1cc04cddcd18eca1262b6aa512a3eda3
}
