using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }
    
    public Scene UnLoadScene { get; set; }
    public void LoadScene(Define.Scene type)
    {
        Managers.Clear();
        SceneManager.LoadScene(GetSceneName(type), LoadSceneMode.Additive);
    }

    public void UnloadScene(Define.Scene type)
    {
        //Scene scene = SceneManager.GetSceneByName(GetSceneName(type));
        AsyncOperation operation = SceneManager.UnloadSceneAsync(UnLoadScene);
        while (operation.isDone)
        {

        }
    }

    string GetSceneName(Define.Scene type)
    {
        string name = System.Enum.GetName(typeof(Define.Scene), type);
        return name;
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }

    public void LoadGameScene(string name)
    {
        SceneManager.sceneLoaded += OnGameSceneLoaded;
        LoadScene(Define.Scene.Game);
    }

    public void OnGameSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnGameSceneLoaded;
        UnLoadScene = SceneManager.GetActiveScene();
        SceneManager.SetActiveScene(scene);
    }
}
