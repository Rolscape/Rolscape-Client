using Protocol;
using UnityEngine;

public class ResourceManager
{
    // 경로를 받아서 리소스를 불러오는 함수
    public T Load<T>(string path) where T : Object
    {
        // Check Pooling
        if (typeof(T) == typeof(GameObject))
        {
            string name = path;
            int index = name.LastIndexOf('/');
            if (index > 0)
                name = name.Substring(index + 1);

            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
                return go as T;
        }

        return Resources.Load<T>(path);
    }

    // 경로를 받아와서 오브젝트를 월드에 소환하는 함수
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed to load prefabs: {path}");
            return null;
        }

        // Check Pooling, the target of pooling
        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;

        return go;
    }

    public GameObject InstantiatePlayer(PlayerJob playerJob)
    {
        string path = "";
        switch (playerJob)
        {
            case PlayerJob.None:
                path = "Players/Default";
                break;
            case PlayerJob.Student:
                path = "Players/Student";
                break;
            case PlayerJob.Teacher:
                path = "Players/Teacher";
                break;
            case PlayerJob.Police:
                path = "Players/Police";
                break;
        }

        return Instantiate(path);
    }

    // 오브젝트 소멸 함수
    public void Destory(GameObject go)
    {
        if (go == null)
            return;

        // if target is pooling object
        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }
}
