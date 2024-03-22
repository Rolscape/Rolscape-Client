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
        _studentDestPos = Random.Range(0, 45);
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
        // TODO Add Type and Select Student or Teacher  
        _grid[idx].color = Color.green;
        _grid[idx].color = Color.cyan;
    }
}
