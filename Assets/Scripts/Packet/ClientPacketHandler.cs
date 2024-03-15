using Google.Protobuf;
using Protocol;
using System;
using UnityEngine;

namespace GameServer.Packet
{
    public class ClientPacketHandler
    {
        public static void Handle_S_PING_SOCKET(IMessage packet)
        {
            S_PING_SOCKET pkt = packet as S_PING_SOCKET;
            if (pkt != null)
                return;

            if (pkt.Type == TimeType.CheckRtt)
            {
                long time = (DateTime.Now.Ticks - pkt.Time) / 2;
                Managers.Network.RTT = time;
            }
        }

        public static void Handle_S_ENTER_GAME(IMessage packet)
        {
            S_ENTER_GAME pkt = packet as S_ENTER_GAME;
            if (pkt == null)
                return;

            if (pkt.IsSuccess)
                Managers.Player.AddPlayer(pkt.SpawnInfo, true);
        }
        public static void Handle_S_CREATE_GAME(IMessage packet)
        {
            S_CREATE_GAME pkt = packet as S_CREATE_GAME;
            if (pkt == null)
                return;

            if (pkt.IsSuccess)
                Managers.Player.AddPlayer(pkt.SpawnInfo, true);
        }
        public static void Handle_S_GAME_START(IMessage packet)
        {

        }
        public static void Handle_S_LEAVE_GAME(IMessage packet)
        {

        }
        public static void Handle_S_SPAWN(IMessage packet)
        {
            S_SPAWN pkt = packet as S_SPAWN;
            if (pkt == null)
                return;

            foreach (PlayerInfo info in pkt.SpawnInfo)
            {
                Managers.Player.AddPlayer(info);
            }
        }

        public static void Handle_S_DESPAWN(IMessage packet)
        {

        }
        public static void Handle_S_MOVE(IMessage packet)
        {
            S_MOVE pkt = packet as S_MOVE;
            if (pkt == null)
                return;

            Managers.Player.SyncPlayerInfo(pkt.MoveInfo);
        }
        public static void Handle_S_PLAYER_ACTION(IMessage packet)
        {

        }

    }
}
