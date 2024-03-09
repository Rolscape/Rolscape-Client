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
        UpdateMoving();
    }

    protected virtual void UpdateMoving()
    {
        Vector3 moveDir = _destPos - transform.position;

        // 도착 여부 체크
        float dist = moveDir.magnitude;
        if (dist < _speed * Time.deltaTime)
        {
            transform.position = _destPos;
            MoveToNextPos();
        }
        else
        {
            transform.position += moveDir.normalized * _speed * Time.deltaTime;
            //State = CreatureState.Moving;
        } 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), 0.3f);
    }

    protected virtual void MoveToNextPos()
    {

    }
}
