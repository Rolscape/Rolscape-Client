using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM2Trigger : MonoBehaviour
{
    public void Init()
    {
      
        
    }
    
    void Start()
    {
        Init();
    }
    
    public void OnShowUI()
    {
        Managers.UI.ShowPopupUI<UI_TM2>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // TODO OnTrigger
        //Managers.Mission.Mission1Start();

        // MyPlayerController controller = other.gameObject.GetComponent<MyPlayerController>();
        // if (controller != null)
        // {
        //     C_PATH_MISSION_JOIN pkt = new C_PATH_MISSION_JOIN();
        //     pkt.IsJoin = true;
        //     pkt.PlayerInfo = controller.Info;
        //     Managers.Network.Send(pkt, INGAME.PathMissionJoin);
        // }
        
    }

    private void OnTriggerExit(Collider other)
    {
        // TODO ExitTrigger
        // MyPlayerController controller = other.gameObject.GetComponent<MyPlayerController>();
        // if (controller != null)
        // {
        //     C_PATH_MISSION_JOIN pkt = new C_PATH_MISSION_JOIN();
        //     pkt.IsJoin = false;
        //     pkt.PlayerInfo = controller.Info;
        //     Managers.Network.Send(pkt, INGAME.PathMissionJoin);
        // }        
    }
    
    
    
}
