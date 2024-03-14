using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
    // 경로를 받아서 리소스를 불러오는 함수
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    // 경로를 받아와서 오브젝트를 월드에 소환하는 함수
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefabs: {path}");
            return null;
        }
        
        GameObject go = Object.Instantiate(prefab, parent);
        go.name = prefab.name;

        return go;
    }

    // 오브젝트 소멸 함수
    public void Destory(GameObject go)
    {
        if (go == null)
            return;
        
        Object.Destroy(go);
    }
}
