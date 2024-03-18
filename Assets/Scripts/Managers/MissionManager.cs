using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager
{
    public Action<Collider> TriggerEnter = null;
    public Action<Collider> TriggerExit = null;
    
    public GameObject[] _grid;
    public GameObject _CurrentTile;
    
    private int gridSizeX = 9;
    private int gridSizeY = 6;
    public int _curIdx;

    public void Init()
    {
        _curIdx = 0;
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
        _grid[_curIdx].GetComponent<Image>().color = Color.white;
        _grid[idx].GetComponent<Image>().color = Color.red;
        _curIdx = idx;
        
    }
}
