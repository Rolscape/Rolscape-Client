using GameServer.Packet;
using Google.Protobuf;
using Protocol;
using System;
using System.Collections.Generic;

namespace GameServer.ServerCore
{ 
    public class PacketHandler
    {
        #region Singleton
        static PacketHandler _instance = new PacketHandler();
        public static PacketHandler Instance { get { return _instance; } }
        #endregion

        Dictionary<UInt16, Action<ArraySegment<byte>, UInt16>> _onRecv = new Dictionary<UInt16, Action<ArraySegment<byte>, UInt16>>();
        Dictionary<UInt16, Action<IMessage>> _handle = new Dictionary<UInt16, Action<IMessage>>();

        public Action<UInt16, IMessage> CustomHandle {  get; set; }
        public PacketHandler() 
        {
            Init();
        }

        void Init()
        {
            _onRecv.Add((UInt16)INGAME.PingSocket, MakePacket<S_PING_SOCKET>);
            _handle.Add((UInt16)INGAME.PingSocket, ClientPacketHandler.Handle_S_PING_SOCKET);
            _onRecv.Add((UInt16)INGAME.EnterGame, MakePacket<S_ENTER_GAME>);
            _handle.Add((UInt16)INGAME.EnterGame, ClientPacketHandler.Handle_S_ENTER_GAME);
            _onRecv.Add((UInt16)INGAME.CreateGame, MakePacket<S_CREATE_GAME>);
            _handle.Add((UInt16)INGAME.CreateGame, ClientPacketHandler.Handle_S_CREATE_GAME);
            _onRecv.Add((UInt16)INGAME.GameStart, MakePacket<S_GAME_START>);
            _handle.Add((UInt16)INGAME.GameStart, ClientPacketHandler.Handle_S_GAME_START);
            _onRecv.Add((UInt16)INGAME.GameEnd, MakePacket<S_GAME_END>);
            _handle.Add((UInt16)INGAME.GameEnd, ClientPacketHandler.Handle_S_GAME_END);
            _onRecv.Add((UInt16)INGAME.LeaveGame, MakePacket<S_LEAVE_GAME>);
            _handle.Add((UInt16)INGAME.LeaveGame, ClientPacketHandler.Handle_S_LEAVE_GAME);
            _onRecv.Add((UInt16)INGAME.Spawn, MakePacket<S_SPAWN>);
            _handle.Add((UInt16)INGAME.Spawn, ClientPacketHandler.Handle_S_SPAWN);
            _onRecv.Add((UInt16)INGAME.Despawn, MakePacket<S_DESPAWN>);
            _handle.Add((UInt16)INGAME.Despawn, ClientPacketHandler.Handle_S_DESPAWN);
            _onRecv.Add((UInt16)INGAME.Move, MakePacket<S_MOVE>);
            _handle.Add((UInt16)INGAME.Move, ClientPacketHandler.Handle_S_MOVE);
            _onRecv.Add((UInt16)INGAME.PathMissionJoin, MakePacket<S_PATH_MISSION_JOIN>);
            _handle.Add((UInt16)INGAME.PathMissionJoin, ClientPacketHandler.Handle_S_PATH_MISSION_JOIN);
            _onRecv.Add((UInt16)INGAME.PathMissionStart, MakePacket<S_PATH_MISSION_START>);
            _handle.Add((UInt16)INGAME.PathMissionStart, ClientPacketHandler.Handle_S_PATH_MISSION_START);
            _onRecv.Add((UInt16)INGAME.PathMissionMove, MakePacket<S_PATH_MISSION_MOVE>);
            _handle.Add((UInt16)INGAME.PathMissionMove, ClientPacketHandler.Handle_S_PATH_MISSION_MOVE);
            _onRecv.Add((UInt16)INGAME.PathMissionEnd, MakePacket<S_PATH_MISSION_END>);
            _handle.Add((UInt16)INGAME.PathMissionEnd, ClientPacketHandler.Handle_S_PATH_MISSION_END);
            _onRecv.Add((UInt16)INGAME.SingleMissionJoin, MakePacket<S_SINGLE_MISSION_JOIN>);
            _handle.Add((UInt16)INGAME.SingleMissionJoin, ClientPacketHandler.Handle_S_SINGLE_MISSION_JOIN);
            _onRecv.Add((UInt16)INGAME.SingleMissionLeave, MakePacket<S_SINGLE_MISSION_LEAVE>);
            _handle.Add((UInt16)INGAME.SingleMissionLeave, ClientPacketHandler.Handle_S_SINGLE_MISSION_LEAVE);
            _onRecv.Add((UInt16)INGAME.SingleMissionStart, MakePacket<S_SINGLE_MISSION_START>);
            _handle.Add((UInt16)INGAME.SingleMissionStart, ClientPacketHandler.Handle_S_SINGLE_MISSION_START);
            _onRecv.Add((UInt16)INGAME.SingleMissionTodo, MakePacket<S_SINGLE_MISSION_TODO>);
            _handle.Add((UInt16)INGAME.SingleMissionTodo, ClientPacketHandler.Handle_S_SINGLE_MISSION_TODO);
            _onRecv.Add((UInt16)INGAME.SingleMissionEnd, MakePacket<S_SINGLE_MISSION_END>);
            _handle.Add((UInt16)INGAME.SingleMissionEnd, ClientPacketHandler.Handle_S_SINGLE_MISSION_END);
            _onRecv.Add((UInt16)INGAME.Chat, MakePacket<S_CHAT>);
            _handle.Add((UInt16)INGAME.Chat, ClientPacketHandler.Handle_S_CHAT);

        }

        public void ParsingPacket(ArraySegment<byte> buffer, PacketHeader head)
        {
            UInt16 id = head.type;

            Action<ArraySegment<byte>, UInt16> action = null;
            if(_onRecv.TryGetValue(id, out action))
            {
                action.Invoke(buffer, id);
            }
        }

        void MakePacket<T>(ArraySegment<byte> buffer, UInt16 id)where T: IMessage, new()
        {
            T pkt = new T();
            pkt.MergeFrom(buffer.Array, buffer.Offset + 4, buffer.Count - 4);

            if(CustomHandle != null)
            {
                CustomHandle.Invoke(id, pkt);
            }
            else
            {
                Action<IMessage> action = null;
                if (_handle.TryGetValue(id, out action))
                {
                    action.Invoke(pkt);
                }
            }
        }

        public Action<IMessage> GetPakcetHandler(UInt16 id)
        {
            Action<IMessage> action = null;
            if (_handle.TryGetValue(id, out action))
            {
                return action;
            }

            return null;
        }
    }
}
