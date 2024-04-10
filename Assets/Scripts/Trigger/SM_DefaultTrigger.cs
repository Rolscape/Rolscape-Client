using Protocol;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;

public class SM_DefaultTrigger : MonoBehaviour
{
    public SingleMissionType missionType;

    public virtual void Init()
    {

    }

    private void Start()
    {
        Init();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("It Trigger 1");

        if (other.gameObject != Managers.Player.MyPlayer)
            return;

        Debug.Log("It Trigger 2");

        if (!TriggerEnterEvent(other))
            return;

        Debug.Log("It Trigger 3");

        Managers.Mission.CurrentMissionTriggerObject = gameObject;

        C_SINGLE_MISSION_JOIN joinPkt = new C_SINGLE_MISSION_JOIN();
        joinPkt.PlayerInfo = Managers.Player.MyPlayerController.Info;
        joinPkt.MissionType = missionType;

        Managers.Network.Send(joinPkt, INGAME.SingleMissionJoin);
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerExitEvent(other);

        Managers.Mission.CurrentMissionTriggerObject = null;

        if (Managers.Mission.bStudentCal)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            C_SINGLE_MISSION_LEAVE leavePkt = new C_SINGLE_MISSION_LEAVE();
            leavePkt.PlayerInfo = Managers.Player.MyPlayerController.Info;
            leavePkt.MissionType = missionType;

            Managers.Network.Send(leavePkt, INGAME.SingleMissionLeave);
        }
    }

    public virtual void OnShowUI() { }
    protected virtual bool TriggerEnterEvent(Collider other) { return true; }
    protected virtual void TriggerExitEvent(Collider other) { }
}