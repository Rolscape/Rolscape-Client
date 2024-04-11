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
            //S_PING_SOCKET pkt = packet as S_PING_SOCKET;
            //if (pkt != null)
            //    return;

            //if (pkt.Type == TimeType.CheckRtt)
            //{
            //    long time = (DateTime.Now.Ticks - pkt.Time) / 2;
            //    Managers.Network.RTT = time;
            //}
        }

        public static void Handle_S_ENTER_GAME(IMessage packet)
        {
            S_ENTER_GAME pkt = packet as S_ENTER_GAME;
            if (pkt == null)
                return;

            if (pkt.IsSuccess)
            {
                Managers.Player.AddPlayer(pkt.SpawnInfo, true);
                Managers.UI.StartChat();
            }
        }

        public static void Handle_S_CREATE_GAME(IMessage packet)
        {
            S_CREATE_GAME pkt = packet as S_CREATE_GAME;
            if (pkt == null)
                return;

            if (pkt.IsSuccess)
            {
                // 로비로 들어간다 치고?
                Managers.Player.AddPlayer(pkt.SpawnInfo, true);
                Managers.UI.StartChat();
            }
        }

        public static void Handle_S_GAME_START(IMessage packet)
        {
            S_GAME_START pkt = packet as S_GAME_START;
            if (pkt == null)
                return;

            // 수정 예정
            Managers.Player.OnGameStart(pkt);

            Managers.Scene.LoadGameScene(Managers.Player.MyPlayerController.NickName);
        }

        public static void Handle_S_GAME_END(IMessage packet)
        {
            S_GAME_END pkt = packet as S_GAME_END;
            if (pkt == null)
                return;
        }

        public static void Handle_S_LEAVE_GAME(IMessage packet)
        {
            S_LEAVE_GAME pkt = packet as S_LEAVE_GAME;
            if (pkt == null)
                return;

            // TODO
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
            S_DESPAWN pkt = packet as S_DESPAWN;
            if (pkt == null)
                return;

            Managers.Player.DeletePlayer(pkt.PlayerInfo);
        }
        public static void Handle_S_MOVE(IMessage packet)
        {
            S_MOVE pkt = packet as S_MOVE;
            if (pkt == null)
                return;

            Managers.Player.SyncPlayerInfo(pkt.MoveInfo);
        }
        public static void Handle_S_PATH_MISSION_JOIN(IMessage packet)
        {
            S_PATH_MISSION_JOIN pkt = packet as S_PATH_MISSION_JOIN;
            if (pkt == null) return;

            if(pkt.IsSucces && (pkt.PlayerInfo.Id == Managers.Player.MyPlayerID))
                Managers.Mission.CurrentMissoinTrigger.OnShowUI();
        }

        public static void Handle_S_PATH_MISSION_START(IMessage packet)
        {
            // 게임 시작하면 
            S_PATH_MISSION_START pkt = packet as S_PATH_MISSION_START;
            if (pkt == null)
                return;

            if (!pkt.IsStart)
                return;

            Debug.Log("Path Mission Start");

            if (Managers.Player.MyPlayerController.Job == PlayerJob.Police)
                Managers.Mission.Mission1StartInvoke(pkt.StartPos, pkt.DestPos);
            else
                Managers.Mission.Mission1StartInvoke(pkt.StartPos);
        }

        public static void Handle_S_PATH_MISSION_MOVE(IMessage packet)
        {
            // 이동 전달 받음
            S_PATH_MISSION_MOVE pkt = packet as S_PATH_MISSION_MOVE;
            if (pkt == null)
                return;

            if (!pkt.IsSucces)
                return;

            if (Managers.Player.MyPlayerController.Job == PlayerJob.Police)
                Managers.Mission.PoliceMoveTileInvoke(pkt.PlayerInfo.PlayerJob, pkt.DestPos);
            else
                Managers.Mission.MoveTileInvoke(pkt.DestPos);

        }

        public static void Handle_S_PATH_MISSION_END(IMessage packet)
        {
            // 게임 종료
            S_PATH_MISSION_END pkt = packet as S_PATH_MISSION_END;
            if (pkt == null)
                return;

            Managers.Mission.Mission1End(pkt.IsSucces);
        }

        public static void Handle_S_SINGLE_MISSION_JOIN(IMessage packet)
        {
            S_SINGLE_MISSION_JOIN pkt = packet as S_SINGLE_MISSION_JOIN;
            if (pkt == null) return;
            if (!pkt.IsSucces) return;

            if (Managers.Mission.CurrentMissoinTrigger != null)
                Managers.Mission.CurrentMissoinTrigger.OnShowUI();
        }

        public static void Handle_S_SINGLE_MISSION_START(IMessage packet)
        {
            S_SINGLE_MISSION_START pkt = packet as S_SINGLE_MISSION_START;
            if (pkt == null) return;
            if (!pkt.IsSucces) return;

            if (pkt.PlayerInfo.Id == Managers.Player.MyPlayerID)
            {
                // 내가 하고 있느냐
                Managers.Mission.SingleMissionStart();
            }
            else
            {
                // 남이 하고 있느냐
                Managers.Mission.SingleMissionStart(false);
            }
        }

        public static void Handle_S_SINGLE_MISSION_TODO(IMessage packet)
        {
            return;
        }

        public static void Handle_S_SINGLE_MISSION_END(IMessage packet)
        {
            S_SINGLE_MISSION_END pkt = packet as S_SINGLE_MISSION_END;
            if (pkt == null) return;

            Managers.Mission.SingleMissionStop(pkt.MissionType, pkt.IsSucces);
        }

        internal static void Handle_S_SINGLE_MISSION_LEAVE(IMessage packet)
        {
            S_SINGLE_MISSION_LEAVE pkt = packet as S_SINGLE_MISSION_LEAVE;
            if (pkt == null) return;

        }

        internal static void Handle_S_CHAT(IMessage message)
        {
            S_CHAT pkt = message as S_CHAT;
            if (pkt == null) return;

            Debug.Log("Receive Chat " + pkt.ChatType);

            if (pkt.ChatType == ChatType.ChatSend)
                return;


            Managers.UI.Chat.ReceiveAllMessage(pkt);
        }
    }
}
