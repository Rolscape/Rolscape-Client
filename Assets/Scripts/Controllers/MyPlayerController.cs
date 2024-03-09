using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : PlayerController
{
    // Start is called before the first frame update


    protected override void Init()
    {
        base.Init();

        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
        
        Managers.Resource.Instantiate("UI/UI_Button");
    }

    protected override void UpdateController()
    {
        base.UpdateController();
        
    }

    protected override void UpdateMoving()
    {
        
    }

    void OnKeyboard()
    {
        // ���� ���� üũ
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(h, 0, v).normalized;
        // TODO CharcterController�� �����̱�  
        
        if (dir != Vector3.zero)
        {
            _characterController.Move(dir * (_speed * Time.deltaTime));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.3f);
        }
    }

    // ���콺 �̺�Ʈ �߻� ��
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;

        // TODO Mouse Event ó��
        // ���� ���ӿ��� � �̺�Ʈ ������� �̼��� �������� ���  -> Raycasting�� ����ؾ��ϴ°� ?
    }
}
