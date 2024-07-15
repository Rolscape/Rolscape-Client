using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class WaterBall : MonoBehaviour
{
    private Vector3 goalPos;
    private IObjectPool<WaterBall> waterPool;
    private float moveSpeed = 5.0f;

    void Start()
    {

    }

    void OnEnable()
    {
        transform.localScale = Vector3.one;
    }

    void Update()
    {
        if (waterPool == null)
            return;

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, goalPos, moveSpeed);
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.3f, 0.3f, 0.3f), Time.deltaTime * moveSpeed);
        //transform.localPosition = Vector3.Lerp(transform.localPosition, goalPos, Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.localPosition, goalPos) <= 0.5f)
        {
            waterPool.Release(this);
        }
    }

    public void SetPool(IObjectPool<WaterBall> _pool)
    {
        waterPool = _pool;
        goalPos = Vector3.zero;
    }

    public void SetGoal(Vector3 _goal)
    {
        goalPos = _goal;
    }

    public Vector3 GetGoal()
    {
        return goalPos;
    }
}
