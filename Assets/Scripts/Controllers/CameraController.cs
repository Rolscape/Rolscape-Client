using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Define.CameraMode _mode = Define.CameraMode.QuarterView;

    [SerializeField] private Vector3 _delta = new Vector3(0.0f, 10.0f, -3.0f);
    
    [SerializeField]
    private GameObject _player = null;

    void Start()
    {
        // TODO Player 찾아서 넣어주기
        // if (_player == null)
        // {
        //     _player = GameObject.Find("@Player");
        // }
       transform.rotation = Quaternion.Euler(70.0f, -1.0f, 0.0f);
    }

    void LateUpdate()
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            RaycastHit hit;
            
            // 카메라가 벽에 가려졌다면 카메라를 벽 앞으로 이동해 시점 변환하기
            if (Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;
                transform.position = _player.transform.position + _delta.normalized * dist;
            }
            else
            {
                transform.position = _player.transform.position + _delta;
                transform.LookAt(_player.transform);   
            }
        }
    }

    public void SetQuarterView(Vector3 delta)
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
