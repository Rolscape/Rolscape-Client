using Protocol;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    void Start()
    {
        Init();
    }

    private void OnDestroy()
    {
        Clear();
    }


    // Update is called once per frame
    private void Update()
    {
        UpdateController();
    }

    protected virtual void Init()
    {
        _characterController = Util.GetOrAddComponent<CharacterController>(gameObject);
        _animator = Util.GetOrAddComponent<Animator>(gameObject);
    }

    protected virtual void Clear() { }

    protected virtual void UpdateController()
    {
        if (_isUpdated)
        {
            switch (MoveInfo.Type)
            {
                case MoveType.MoveIdle:
                    UpdateIdle();
                    break;
                case MoveType.MoveWalk:
                    UpdateMoving();
                    break;
                default:
                    break;
            }
        }
    }

    protected virtual void UpdateIdle()
    {
        if(_isUpdated)
            UpdateMoving();
        else
            UpdateAnimationIDLE();
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


            UpdateAnimationMOVE();
        }
    }

    protected virtual void MoveToNextPos()
    {
        _isUpdated = false;
    }

    protected virtual void UpdateAnimationMOVE()
    {
        _animator.SetFloat("Speed", _speed);
    }

    protected virtual void UpdateAnimationIDLE()
    {
        _animator.SetFloat("Speed", 0.0f);
    }
}
