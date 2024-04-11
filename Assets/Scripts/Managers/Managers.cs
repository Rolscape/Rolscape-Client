using GameServer.Packet;
using Protocol;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;

    private DataManager _data = new DataManager();
    private NetworkManager _network = new NetworkManager();
    private VivoxManager _vivox = new VivoxManager();
    private PlayerManager _player = new PlayerManager();
    private InputManager _input = new InputManager();
    private PoolManager _pool = new PoolManager();
    private ResourceManager _resource = new ResourceManager();
    private SceneManagerEx _scene = new SceneManagerEx();
    private UIManager _ui = new UIManager();
    private SoundManager _sound = new SoundManager();
    private MissionManager _mission = new MissionManager();
    private TriggerManager _trigger = new TriggerManager();

    public static Managers Instance
    {
        get
        {
            Init();
            return s_instance;
        }
    }
    
    public static DataManager Data { get { return Instance._data; } }
    public static InputManager Input { get { return Instance._input; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static MissionManager Mission { get { return Instance._mission; } }
    public static TriggerManager Trigger { get { return Instance._trigger; } }

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
        _input.Update();
        Network.Update();
    }
    
    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject{ name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
            
            s_instance._data.Init();
            s_instance._pool.Init();
            s_instance._sound.Init();
            //s_instance._mission.Init();

            Network.Init();
        }
    }

    public static void Clear()
    {
        //C_LEAVE_GAME pkt = new C_LEAVE_GAME();
        //pkt.PlayerInfo = Player.PlayerInfo;
        //Network.Send(pkt, INGAME.LeaveGame);

        Input.Clear();
        Sound.Clear();
        Scene.Clear();
        UI.Clear();
        Pool.Clear();
        //Player.Clear();
        //Network.Clear();
        //Mission.CLear();
    }
}
