using Protocol;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    public string NickName { get; set; }
    // Start is called before the first frame update

    protected Animator _animator;
    protected float _speed = 20.0f;

    protected CharacterController _characterController;
    protected PlayerMoveInfo _moveInfo = new PlayerMoveInfo();
    protected PlayerInfo _info = new PlayerInfo();
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

    public PlayerJob Job
    {
        get { return Info.PlayerJob; }
    }

    public MoveType MoveType
    {
        get { return _moveInfo.Type; }
        set { _moveInfo.Type = value; }
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
            _info = value;
            _moveInfo.Id = value.Id;
            _moveInfo.PosX = value.PosX;
            _moveInfo.PosZ = value.PosZ;
            _moveInfo.Type = MoveType.MoveIdle;
        }
        get { return _info; }
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
}