using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject _player = null;
    
    void Start()
    {
        // TODO Player 찾아서 넣어주기
        if (_player == null)
        {
            _player = GameObject.Find("@Player");
        }
       transform.rotation = Quaternion.Euler(70.0f, -1.0f, 0.0f);
    }

    void Update()
    {
        // TODO 캐릭터 따라다니기
        transform.position = _player.transform.position + new Vector3(0.0f, 10.0f, -3.0f);
    }
}
