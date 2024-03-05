using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 10.0f;
    private CharacterController _characterController;
    void Start()
    {
        if (_characterController == null)
        {
            gameObject.AddComponent<CharacterController>();
        }
        _characterController = GetComponent<CharacterController>();

        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;

    }

    void Update()
    {
        
         
    }

    void OnKeyboard()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;
        

        if (dir != Vector3.zero)
        {
            _characterController.Move(dir*(_speed*Time.deltaTime));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 0.3f);   
        }
    }
}
