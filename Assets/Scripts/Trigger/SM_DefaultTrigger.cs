using Protocol;
using UnityEngine;

public class SM_DefaultTrigger : MonoBehaviour
{
    public SingleMissionType missionType;
    bool isJoin = false;

    public void Clear()
    {
        MissionLeave();
    }

    public void MissionJoin()
    {
        Managers.Mission.SMStart += MissionStart;
        Managers.Mission.SMStop += MissionStop;

        isJoin = true;
    }

    public void MissionLeave()
    {
        Managers.Mission.SMStart -= MissionStart;
        Managers.Mission.SMStop -= MissionStop;

        Managers.UI.ClosePopupUI();
    }

    private void Start()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != Managers.Player.MyPlayer)
            return;

        if (!TriggerEnterEvent(other))
            return;

        if (!isJoin)
            MissionJoin();

        Managers.Mission.CurrentMissionTriggerObject = gameObject;

        C_SINGLE_MISSION_JOIN joinPkt = new C_SINGLE_MISSION_JOIN();
        joinPkt.PlayerInfo = Managers.Player.MyPlayerController.Info;
        joinPkt.MissionType = missionType;

        Managers.Network.Send(joinPkt, INGAME.SingleMissionJoin);

        MissionJoin();
    }

    private void OnTriggerExit(Collider other)
    {
        if (Managers.Mission.IsSingleMissionStart)
        {
            return;
        }

        bool isMissionSuccess = TriggerExitEvent(other);

        Managers.Mission.CurrentMissionTriggerObject = null;

        if (isMissionSuccess)
        {
            Destroy(gameObject);
            return;
        }
        else if (isJoin)
        {
            C_SINGLE_MISSION_LEAVE leavePkt = new C_SINGLE_MISSION_LEAVE();
            leavePkt.PlayerInfo = Managers.Player.MyPlayerController.Info;
            leavePkt.MissionType = missionType;

            Managers.Network.Send(leavePkt, INGAME.SingleMissionLeave);

            MissionLeave();
            if (!isMissionSuccess)
                isJoin = false;
        }
    }

    public virtual void OnShowUI() { }
    protected virtual bool TriggerEnterEvent(Collider other) { return true; }
    protected virtual bool TriggerExitEvent(Collider other) { return true; }

    protected virtual void MissionStart()
    {
        Managers.Input.IsMission = true;
    }

    protected virtual void MissionStop(bool isSuccess)
    {
        Managers.Input.IsMission = false;
    }

    protected virtual void Init() { }
}