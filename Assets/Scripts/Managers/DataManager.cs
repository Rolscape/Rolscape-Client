using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{

    public Dictionary<int, Stat> StatDict { get; private set; } = new Dictionary<int, Stat>();
    public Dictionary<int, Cal> CalDict { get; private set; } = new Dictionary<int, Cal>();
    public Dictionary<int, Word> WordDict { get; private set; } = new Dictionary<int, Word>();
    public Dictionary<int, MusicOffice> MusicOfficesDict { get; private set; } = new Dictionary<int, MusicOffice>();
    
    public void Init()
    {
        StatDict = LoadJson<StatData, int, Stat>("StatData").MakeDict();
        //CalDict = LoadJson<CalData, int, Cal>("CalData").MakeDict();
        WordDict = LoadJson<WordData, int, Word>("WordData").MakeDict();
        MusicOfficesDict = LoadJson<MusicOfficeData, int, MusicOffice>("MusicOfficeData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
