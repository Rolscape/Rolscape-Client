using GameServer.Packet;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;
    private InputManager _input = new InputManager();
    private ResourceManager _resource = new ResourceManager();
    private UIManager _ui = new UIManager();
    
    // Network Manager
    private NetworkManager networkManager = new NetworkManager();
    private VivoxManager vivoxManager = new VivoxManager();

    public static Managers Instance
    {
        get
        {
            Init();
            return s_instance;
        }
    }

    public static InputManager Input
    {
        get { return Instance._input; }
    }
    public static ResourceManager Resource
    {
        get { return Instance._resource; }
    }
    public static UIManager UI
    {
        get { return Instance._ui; }
    }

    public static NetworkManager Network { get { return Instance.networkManager; } }
    public static VivoxManager Vivox { get { return Instance.vivoxManager; } }

    private void Awake()
    {
        VivoxManager.Init();   
    }

    private void Start()
    {
        Init();
    }

    void Update()
    {
        _input.OnUpdate();
        Network.Update();
    }
    
    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();

            Network.Init();
        }
        
    }


}
