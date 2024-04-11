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
        C_SINGLE_MISSION_START missionStartPkt = new C_SINGLE_MISSION_START();
        missionStartPkt.PlayerInfo = Info;
        missionStartPkt.MissionType = Managers.Mission.CurrentMissionType;

        Managers.Network.Send(missionStartPkt, INGAME.SingleMissionStart);
    }

    public void SendSingleMissionStop(bool isSuccess)
    {
        C_SINGLE_MISSION_END missionEndPkt = new C_SINGLE_MISSION_END();
        missionEndPkt.PlayerInfo = Info;
        missionEndPkt.IsSucces = isSuccess;
        missionEndPkt.MissionType = Managers.Mission.CurrentMissionType;

        Managers.Network.Send(missionEndPkt, INGAME.SingleMissionEnd);
    }

    public void SendChat(string message)
    {
        C_CHAT sendChatPkt = new C_CHAT();
        sendChatPkt.ChatType = ChatType.ChatSend;
        sendChatPkt.Message = message;
        sendChatPkt.PlayerInfo = Info;

        Managers.Network.Send(sendChatPkt, INGAME.Chat);
    }

    public void StartChat()
    {
        C_CHAT chatPkt = new C_CHAT();
        chatPkt.ChatType = ChatType.ChatReceiveAll;

        Managers.Network.Send(chatPkt, INGAME.Chat);
    }
}