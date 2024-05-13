using GameServer.ServerCore;
using Google.Protobuf;
using Protocol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

namespace GameServer.Packet
{
    public class NetworkManager    
    {
        ClientSession session;

        public NetworkManager() { }
        public long RTT {  get; set; }

        public void Init()
        {
            session = new ClientSession();
            Connect();
        }

        public void Clear()
        {
            session.Disconnect();
        }

        public void Connect()
        {
            Debug.Log("Connect Start");
            PacketHandler.Instance.CustomHandle = new Action<ushort, IMessage>(RecvPacketQueue.Instance.PushBack);
            //session.Start(new IPEndPoint(IPAddress.Parse("192.168.35.175"), 7777));
            //session.Start(new IPEndPoint(IPAddress.Parse("218.50.132.162"), 7777));
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
        
        //public void StartRTT() => Managers.Instance.StartCoroutine(UpdateRTT());
        //private IEnumerator UpdateRTT()
        //{
        //    while(true)
        //    {
        //        C_PING_SOCKET pkt = new C_PING_SOCKET();
        //        pkt.Type = TimeType.CheckRtt;
        //        pkt.Time = DateTime.Now.Ticks;

        //        Managers.Network.Send(pkt, INGAME.PingSocket);

        //        yield return new WaitForSeconds(1000);
        //    }
        //}
    }
}
