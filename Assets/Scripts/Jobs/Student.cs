using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : Player
{
    private TM1_Student _tm1Student;
    protected override void Init()
    {
        base.Init();
        _isLeader = false;
        Job = Protocol.PlayerJob.Student;

        _tm1Student = gameObject.GetOrAddComponent<TM1_Student>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
}
