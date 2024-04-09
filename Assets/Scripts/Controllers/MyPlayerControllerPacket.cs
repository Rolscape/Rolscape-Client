using Protocol;
using UnityEngine;

public partial class MyPlayerController : PlayerController
{
    void SendMovePacket()
    {
        Vector3 pos = transform.position;

        MoveInfo.Id = MoveInfo.Id;
        MoveInfo.PosX = pos.x;
        MoveInfo.PosZ = pos.z;

        MoveInfo.DirX = _movedir.x;
        MoveInfo.DirZ = _movedir.z;

        MoveInfo.Type = MoveType.MoveWalk;

        C_MOVE pkt = new C_MOVE();
        pkt.MoveInfo = MoveInfo;
        Managers.Network.Send(pkt, INGAME.Move);
    }

    void SendStopPacket()
    {
        Vector3 pos = transform.position;

        MoveInfo.Id = MoveInfo.Id;
        MoveInfo.PosX = pos.x;
        MoveInfo.PosZ = pos.z;
        MoveInfo.Type = MoveType.MoveIdle;

        C_MOVE pkt = new C_MOVE();
        pkt.MoveInfo = MoveInfo;
        Managers.Network.Send(pkt, INGAME.Move);
    }

    //public void SendSingleMissionJoin()
    //{

    //}

    //public void SendSingleMissionLeave()
    //{

    //}
    // Join Leave는 DefaultTrigger에 존재
    public void SendSingleMssionStart()
    {
        C_SINGLE_MISSION_START mission = new C_SINGLE_MISSION_START();
        mission.PlayerInfo = Info;
        mission.MissionType = Managers.Mission.CurrentMissionType;

        Managers.Network.Send(mission, INGAME.SingleMissionStart);
    }

    public void SendSingleMissionStop(bool isSuccess)
    {
        S_SINGLE_MISSION_END endPkt = new S_SINGLE_MISSION_END();
        endPkt.PlayerInfo = Info;
        endPkt.IsSucces = isSuccess;
        endPkt.MissionType = Managers.Mission.CurrentMissionType;

        Managers.Network.Send(endPkt, INGAME.SingleMissionEnd);
    }
}