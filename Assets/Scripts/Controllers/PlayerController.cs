using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 15.0f;
    private CharacterController _characterController;
    void Start()
    {
        // 캐릭터에 CharcterController 붙여주기 
        if (_characterController == null)
        {
            gameObject.AddComponent<CharacterController>();
        }
        _characterController = GetComponent<CharacterController>();

        // Input Manager의 Action 등록
        // 해당 이벤트가 발생 시 함수 호출 
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

        Managers.Resource.Instantiate("UI/UI_Button");
    }

    void Update()
    {
        
         
    }

    // 키보드 이벤트 발생 시 
    void OnKeyboard()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;
        
        if (dir != Vector3.zero)
        {
            _characterController.Move(dir*(_speed*Time.deltaTime));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), _speed * Time.deltaTime);
            
        }
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
