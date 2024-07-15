using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class UI_SMScience : UI_SM
{
    public List<RectTransform> positions;
    [SerializeField] private GameObject waterPrefab;

    private IObjectPool<WaterBall> waterPool;
    private Vector3 waterStartPos = new Vector3(-853f, -287f, 0);
    private Vector3 waterEndPos = Vector3.zero;
    private float waterBalltTime;
    private bool isSpaceBar;

    public override void Init()
    {
        base.Init();
        Managers.Sound.Play("MinigameSlow", Define.Sound.Bgm);
        BiundUI();
        SetFire();
    }

    void Awake()
    {
        waterPool = new ObjectPool<WaterBall>(
                PoolCreate,
                PoolGet,
                PoolRelease,
                PoolDestroy,
                maxSize: 10
            );
    }

    void Start()
    {
        Init();
        isSpaceBar = false;

        // player
        MyPlayerController player = FindObjectOfType<MyPlayerController>();
        if (player != null)
            player._isMission = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpaceBar = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isSpaceBar = false;
        }

        if (isSpaceBar)
        {
            if (waterBalltTime >= 0.1f)
            {
                waterPool.Get();
                waterBalltTime = 0f;
            }

            waterBalltTime += Time.deltaTime;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                waterEndPos += Vector3.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                waterEndPos += Vector3.down;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                waterEndPos += Vector3.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                waterEndPos += Vector3.right;
            }
        }
    }

    void BiundUI()
    {
        
    }

    void SetFire()
    {
        int totalCount = Random.Range(4, 6);

        var indexList = new List<int>();
        for (int i = 0; i < positions.Count; ++i)
        {
            indexList.Add(i);
            positions[i].gameObject.SetActive(false);
        }

        var temp = new List<int>();
        var random = new System.Random();
        var randomized = indexList.OrderBy(x => random.Next());
        foreach (var i in randomized)
        {
            temp.Add(i);
            positions[i].gameObject.SetActive(true);
            if (temp.Count == totalCount)
                break;
        }
    }

    public void CheckFire(Vector3 _goal)
    {
        for (int i = 0; i < positions.Count; ++i)
        {
            if (positions[i].gameObject.activeSelf)
            {
                if (Vector3.Distance(positions[i].localPosition, _goal) < 50)
                {
                    positions[i].gameObject.SetActive(false);
                }
            }
        }

        bool isEndGame = true;
        foreach (var pos in positions)
        {
            if (pos.gameObject.activeSelf)
            {
                isEndGame = false;
                break;
            }
        }

        if (isEndGame)
        {
            MyPlayerController player = FindObjectOfType<MyPlayerController>();
            if (player != null)
                player._isMission = false;
            
            Managers.Sound.Play("MainBgm", Define.Sound.Bgm);
            ClosePopupUI();
        }
    }

    #region Pool
    private WaterBall PoolCreate()
    {
        WaterBall go = Instantiate(waterPrefab.GetComponent<WaterBall>(), transform);
        go.SetPool(waterPool);
        return go;
    }

    private void PoolGet(WaterBall water)
    {
        water.transform.localPosition = waterStartPos;
        water.gameObject.SetActive(true);
        water.SetGoal(waterEndPos);
    }

    private void PoolRelease(WaterBall water)
    {
        CheckFire(water.GetGoal());
        water.gameObject.SetActive(false);
    }

    private void PoolDestroy(WaterBall water)
    {
        Destroy(water.gameObject);
    }
    #endregion
}
