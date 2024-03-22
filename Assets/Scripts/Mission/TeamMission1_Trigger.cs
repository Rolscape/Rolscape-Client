using Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeamMission1_Trigger : MonoBehaviour
{
    
    public void Init()
    {
        Managers.Mission.TriggerEnter -= OnTriggerEnter;
        Managers.Mission.TriggerEnter += OnTriggerEnter;
        Managers.Mission.TriggerExit -= OnTriggerExit;
        Managers.Mission.TriggerExit += OnTriggerExit;
    }
    
    void Start()
    {
        Init();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        // TODO OnTrigger
        //Managers.Mission.Mission1Start();

        MyPlayerController controller = other.gameObject.GetComponent<MyPlayerController>();
        if (controller != null)
        {
            C_PATH_GAME_JOIN pkt = new C_PATH_GAME_JOIN();
            pkt.IsJoin = true;
            pkt.PlayerInfo = controller.Info;
            Managers.Network.Send(pkt, INGAME.PathGameJoin);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // TODO ExitTrigger
        MyPlayerController controller = other.gameObject.GetComponent<MyPlayerController>();
        if (controller != null)
        {
            C_PATH_GAME_JOIN pkt = new C_PATH_GAME_JOIN();
            pkt.IsJoin = false;
            pkt.PlayerInfo = controller.Info;
            Managers.Network.Send(pkt, INGAME.PathGameJoin);
        }
    }
}
