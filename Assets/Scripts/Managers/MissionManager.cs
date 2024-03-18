using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MissionManager
{
    public Action<Collider> TriggerEnter = null;
    public Action<Collider> TriggerExit = null;
    
    public Image[] _grid;
    public Image _CurrentTile;
    
    private int gridSizeX = 9;
    private int gridSizeY = 6;
    public int _curIdx;
    public int _destPos1;
    public int _destPos2;

    public void Init()
    {
        _curIdx = 0;

        _destPos1 = Random.Range(0, gridSizeY * gridSizeX);
        _destPos2 = Random.Range(0, gridSizeY * gridSizeX);
        
    }

    public void CLear()
    {
        
    }

    public bool CheckMoveNextGrid(Vector3 dir)
    {
        int nextIdx = _curIdx;
        
        if (dir == Vector3.forward)
        {
            nextIdx -= gridSizeX;
        }
        if (dir == Vector3.back)
        {
            nextIdx += gridSizeX;

        }
        if (dir == Vector3.left)
        {
            if((nextIdx) % gridSizeX != 0)
                nextIdx--;
        }
        if (dir == Vector3.right)
        {
            if((nextIdx+1) % gridSizeX != 0)
                nextIdx++;
        }

        if (nextIdx >= 0 && nextIdx < gridSizeY * gridSizeX)
        {
            MoveNextGrid(nextIdx);
        }
        
        return false;
    }

    public void MoveNextGrid(int idx)
    {
        _grid[_curIdx].color = Color.white;
        _grid[idx].color = Color.red;
        _curIdx = idx;
        
    }
}
