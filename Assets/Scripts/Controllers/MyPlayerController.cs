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
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;

        // TODO CharcterController로 움직이기  

        if (dir != Vector3.zero)
        {
            _characterController.Move(dir * (_speed * Time.deltaTime));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.3f);
        }
    }

    void OnKeyboard()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;
        _characterController.Move(dir * (_speed * Time.deltaTime));
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), _speed * Time.deltaTime);
        // 도착 여부 체크
    }

    // 마우스 이벤트 발생 시
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;

        // TODO Mouse Event 처리
        // 추후 게임에서 어떤 이벤트 방식으로 미션을 수행할지 등등  -> Raycasting을 사용해야하는가 ?
    }
}
