using Google.Protobuf;
using Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Managers.Scene.LoadGameScene(pkt.SpawnInfo.UserName);
                Managers.Player.AddPlayer(pkt.SpawnInfo, true);
            }
        }

        public static void Handle_S_CREATE_GAME(IMessage packet)
        {
            S_CREATE_GAME pkt = packet as S_CREATE_GAME;
            if (pkt == null)
                return;

            if (pkt.IsSuccess)
            {
                Managers.Scene.LoadGameScene(pkt.SpawnInfo.UserName);
                Managers.Player.AddPlayer(pkt.SpawnInfo, true);
            }
        }

        public static void Handle_S_GAME_START(IMessage packet)
        {
            S_GAME_START pkt = packet as S_GAME_START;
            foreach(PlayerInfo info in pkt.PlayerInfo)
            {
                if(Managers.Player.MyPlayerController.ID == info.Id)
                {
                    Managers.Player.MyPlayerController.Info = info;
                    if(info.PlayerJob == PlayerJob.Teacher)
                    {
                        Util.GetOrAddComponent<Teacher>(Managers.Player.MyPlayer);
                    }
                    else if(info.PlayerJob == PlayerJob.Student)
                    {
                        Util.GetOrAddComponent<Student>(Managers.Player.MyPlayer);
                    }
                    else if(info.PlayerJob == PlayerJob.Police)
                    {
                        Util.GetOrAddComponent<Police>(Managers.Player.MyPlayer);
                    }

                    break;
                }
            }
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
        public static void Handle_S_PATH_GAME_JOIN(IMessage packet)
        {

		}
        public static void Handle_S_PATH_GAME_START(IMessage packet)
        {
            // 게임 시작하면 
            S_PATH_GAME_START pkt = packet as S_PATH_GAME_START;
            if (pkt == null)
                return;

            Managers.Mission.Mission1Start();
		}
        public static void Handle_S_PATH_GAME_MOVE(IMessage packet)
        {
            // 이동 전달 받음
            S_PATH_GAME_MOVE pkt = packet as S_PATH_GAME_MOVE;
            if (pkt == null)
                return;


        }
        public static void Handle_S_PATH_GAME_END(IMessage packet)
        {
            // 게임 종료
            S_PATH_GAME_END pkt = packet as S_PATH_GAME_END;
            if (pkt == null)
                return;


        }
    }
}
