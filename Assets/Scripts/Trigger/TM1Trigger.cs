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
            C_PATH_MISSION_JOIN pkt = new C_PATH_MISSION_JOIN();
            pkt.IsJoin = true;
            pkt.PlayerInfo = controller.Info;
            Managers.Network.Send(pkt, INGAME.PathMissionJoin);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // TODO ExitTrigger
        MyPlayerController controller = other.gameObject.GetComponent<MyPlayerController>();
        if (controller != null)
        {
            C_PATH_MISSION_JOIN pkt = new C_PATH_MISSION_JOIN();
            pkt.IsJoin = false;
            pkt.PlayerInfo = controller.Info;
            Managers.Network.Send(pkt, INGAME.PathMissionJoin);
        }
    }
}