using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM1_Police : UI_TM1
{
    private UI_TM1Police _ui;
    
    private int _teacherDestPos;
    private int _studentDestPos;

    public override void Init()
    {
        base.Init();
        
        
        _teacherDestPos = Random.Range(0, 45);
        SetDestPos(_teacherDestPos);
    }

    void Start()
    {
        Init();
    }
    
    public void CheckMoveNextGrid(int nextPos)
    {
        // TODO Add job type

        
    }
    
    
    public void SetDestPos(int idx)
    {
        _grid[idx].color = Color.green;
    }
}
