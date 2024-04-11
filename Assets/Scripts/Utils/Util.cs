using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public const int POSX = 100;
    public const int POSY = 65;

    // 컴포넌트를 반환하는 함수 -> 컴포넌트가 없으면 붙여서 반환
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();

        return component;
    }
    
    // 자식 게임 오브젝트를 찾는 함수
    public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
    {
        // 게임 오브젝트의 트랜스폼 컴포넌트를 활용하여 FindChild<T> 함수 재활용
        Transform transform = FindChild<Transform>(go, name, recursive);
        if (transform == null)
            return null;
        
        // 트랜스폼의 게임 오브젝트 return
        return transform.gameObject;
    }
    
    // 자식 컴포넌트를 찾는 함수
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go == null)
            return null;

        if (recursive == false)
        {
            // 직속 자식 컴포넌트만 찾는 경우
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(0);
                if (string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if (component != null)
                        return component;
                }
            }
        }
        else
        {
            // 재귀적으로 자식 컴포넌트를 찾는 경우
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                    return component;
            }
        }

        return null;
    }

    public static Vector2Int GetPos(Protocol.Pos pos)
    {
        int x = pos.X * POSX;
        int y = pos.Y * POSY;
        return new Vector2Int(x, y);
    }
}
