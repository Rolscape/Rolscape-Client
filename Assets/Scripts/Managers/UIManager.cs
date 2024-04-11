using Protocol;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager
{
    // UI SortOrder
    private int _order = 10;
    
    // Use Stack in Popup Structure
    private Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();
    private UI_Scene _sceneUI = null;
    public UI_Chat Chat = null;

    // Find UI Root GameObject
    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
                root = new GameObject { name = "@UI_Root" };

            return root;
        }
    }

    // Set Popup UI Canvas's Sorting order
    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            // not Popup UI
            canvas.sortingOrder = 0;
        }
    }

    public T MakeWorldSpaceUI<T>(Transform parent = null, string name = null) where T : UI_Base
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/WorldSpace/{name}");
        if(parent != null)
            go.transform.SetParent(parent);

        Canvas canvas = go.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;

        return Util.GetOrAddComponent<T>(go);
    }
    
    // Show Scene UI Func
    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        T SceneUI = Util.GetOrAddComponent<T>(go);
        _sceneUI = SceneUI;
        go.transform.SetParent(Root.transform);
            
        return SceneUI;
    }

    // Show Popup UI Func
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);
        go.transform.SetParent(Root.transform);
            
        return popup;
    }

    // Close Popup UI Func Safety Version Using Cross Checking
    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed !");
            return;
        }
        
        ClosePopupUI();
    }

    // Close Popup UI Func
    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;
        
        // recently used popup UI
        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destory(popup.gameObject);
        popup = null;
        _order--;
    }

    public void CloseAllPopupUI()
    {
        while(_popupStack.Count > 0)
            ClosePopupUI();
    }

    public void Clear()
    {
        CloseAllPopupUI();
        _sceneUI = null;
    }

    public void StartChat()
    {
        UI_Chat uiChat = ShowSceneUI<UI_Chat>();
        Chat = uiChat;

        Managers.Player.MyPlayerController.StartChat();
    }
}
