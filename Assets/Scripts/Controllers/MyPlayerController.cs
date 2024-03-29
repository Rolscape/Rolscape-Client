using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyPlayerController : PlayerController
{
    private Animator _animator;
    private bool _isLeader;
    public bool _isMission = false;
    
    // Start is called before the first frame update
    protected override void Init()
    {
        base.Init();
        
        _animator = gameObject.GetComponent<Animator>();
        
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

        Managers.UI.MakeWorldSpaceUI<UI_Nickname>(transform);

        _animator = Util.FindChild<Animator>(gameObject);
        
        Player player = GetComponent<Player>();
        _isLeader = player._isLeader;
    }

    protected override void UpdateController()
    {
        base.UpdateController();
    }

    protected override void UpdateMoving()
    {
        
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
            _animator.SetFloat("Speed", _speed);
        }
        else
        {
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
    
}
