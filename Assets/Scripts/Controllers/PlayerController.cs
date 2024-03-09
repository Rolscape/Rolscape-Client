using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    protected float _speed = 10.0f;
    protected CharacterController _characterController;

    private Vector3 _nowPos = new Vector3(0, 0, 0);
    private Vector3 _destPos = new Vector3(0, 0, 0);

    protected bool _isUpdated = false;

    void Start()
    {
        // 캐릭터에 CharcterController 붙여주기 
        if (_characterController == null)
        {
            gameObject.AddComponent<CharacterController>();
        }
        _characterController = GetComponent<CharacterController>();

        // Input Manager??Action ?깅줉
        // ?대떦 ?대깽?멸? 諛쒖깮 ???⑥닔 ?몄텧 
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

        Managers.Resource.Instantiate("UI/UI_Button");
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateController();
    }

    protected virtual void UpdateController()
    {
        UpdateMoving();
    }

    protected virtual void UpdateMoving()
    // 키보드 이벤트 발생 시 
    void OnKeyboard()
    {
        Vector3 moveDir = _destPos - transform.position;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;
        
        // 도착 여부 체크
        float dist = moveDir.magnitude;
        if (dist < _speed * Time.deltaTime)
        {
            transform.position = _destPos;
            MoveToNextPos();
        }
        else
        {
            _characterController.Move(dir*(_speed*Time.deltaTime));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), _speed * Time.deltaTime);
            
            transform.position += moveDir.normalized * _speed * Time.deltaTime;
            //State = CreatureState.Moving;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.3f);
    }

    protected virtual void MoveToNextPos()
    
    // 마우스 이벤트 발생 시
    void OnMouseClicked(Define.MouseEvent evt)
{
    if (evt != Define.MouseEvent.Click)
        return;

    // TODO Mouse Event 처리
    // 추후 게임에서 어떤 이벤트 방식으로 미션을 수행할지 등등  -> Raycasting을 사용해야하는가 ?
}
}
