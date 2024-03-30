using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Stat
[Serializable] 
public class Stat
{
    public int level;
    public int exp;
}

[Serializable]
public class StatData : ILoader<int, Stat>
{
    public List<Stat> stats = new List<Stat>();
    public Dictionary<int, Stat> MakeDict()
    {
        Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
        foreach (Stat stat in stats)
            dict.Add(stat.level, stat);

        return dict;
    }
}
#endregion

#region Cal

[Serializable]
public class Cal
{
    public int id;
    public string question;
    public int result;
}

[Serializable]
public class CalData : ILoader<int, Cal>
{
    public List<Cal> cals = new List<Cal>();
    public Dictionary<int, Cal> MakeDict()
    {
        Dictionary<int, Cal> dict = new Dictionary<int, Cal>();
        foreach (Cal cal in cals)
            dict.Add(cal.id, cal);

        return dict;
    }
}


#endregion