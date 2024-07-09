using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SMScience : UI_SM
{
    public List<RectTransform> positions;

    public override void Init()
    {
        base.Init();
        Managers.Sound.Play("MinigameSlow", Define.Sound.Bgm);
        BiundUI();
        SetFire();
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        
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
}
