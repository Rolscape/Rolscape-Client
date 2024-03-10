using GameServer.Packet;
using Protocol;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;
    private NetworkManager _network = new NetworkManager();
    private VivoxManager _vivox = new VivoxManager();
    private PlayerManager _player = new PlayerManager();
    private InputManager _input = new InputManager();
    private ResourceManager _resource = new ResourceManager();

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

    public static NetworkManager Network { get { return Instance._network; } }
    public static VivoxManager Vivox { get { return Instance._vivox; } }
    public static PlayerManager Player { get { return Instance._player; } }

    private void Awake()
    {
        //VivoxManager.Init();   
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
