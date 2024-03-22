using Protocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool _isLeader;
    public PlayerJob Job { get; protected set; }
    protected virtual void Init()
    {
        
    }

    public virtual void Mission1Start()
    {
        
    }
    void Start()
    {
        Init();   
    }

    void Update()
    {
        
    }
}
