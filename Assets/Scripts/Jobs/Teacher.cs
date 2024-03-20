using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : Player
{
    private TM1_Teacher _tm1Student;
    protected override void Init()
    {
        base.Init();
        _isLeader = false;

        _tm1Student = gameObject.GetOrAddComponent<TM1_Teacher>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
