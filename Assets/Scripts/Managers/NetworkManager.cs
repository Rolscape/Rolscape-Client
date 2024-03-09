using GameServer.ServerCore;
using Google.Protobuf;
using Protocol;
using System;
using System.Collections.Generic;
using System.Net;

namespace GameServer.Packet
{
    public class NetworkManager    
    {
        ClientSession session;

        public NetworkManager() { }


        public void Init()
        {
            session = new ClientSession();
            Connect();
        }
        public void Connect()
        {
            PacketHandler.Instance.CustomHandle = new Action<ushort, IMessage>(RecvPacketQueue.Instance.PushBack);
            session.Start(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7777));
        }
        public void Send(IMessage message, INGAME type)
        {
            session.Send(message, type);
        }

        public void Update()
        {
            List<Tuple<UInt16, IMessage>> values = RecvPacketQueue.Instance.PopAll();
            foreach(Tuple<UInt16, IMessage> value in values)
            {
                Action<IMessage> action = null;
                action = PacketHandler.Instance.GetPakcetHandler(value.Item1);
                if (action != null)
                {
                    action.Invoke(value.Item2);
                }
            }
        }
    }
}
