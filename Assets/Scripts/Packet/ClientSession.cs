using GameServer.ServerCore;
using Google.Protobuf;
using Protocol;
using System;
using System.Net;
using System.Runtime.InteropServices;
using UnityEngine;


namespace GameServer.Packet
{
    public class ClientSession : PacketSession
    {
        public void Send(IMessage message, INGAME type)
        {
            int headSize = Marshal.SizeOf(typeof(PacketHeader));
            UInt16 pktSize = (UInt16)message.CalculateSize();
            PacketHeader header = new PacketHeader();
            header.size = pktSize;
            header.size += 4;
            header.type = (UInt16)type;
            byte[] sendBuffer = new byte[header.size];

            IntPtr ptr = Marshal.AllocHGlobal(headSize);
            Marshal.StructureToPtr(header, ptr, false);
            Marshal.Copy(ptr, sendBuffer, 0, headSize);
            Marshal.FreeHGlobal(ptr);

            Array.Copy(message.ToByteArray(), 0, sendBuffer, headSize, pktSize);
            Send(new ArraySegment<byte>(sendBuffer));
        }

        public override void OnConnected()
        {
            UnityEngine.Debug.Log("On Connected");
            
            C_CONNECT_SOCKET socket = new C_CONNECT_SOCKET();
            Managers.Network.Send(socket, INGAME.ConnectSocket);
        }

        public override void OnDisconnected(EndPoint endPoint)
        {

        }

        public override void OnRecvPacket(ArraySegment<byte> buffer, PacketHeader header)
        {
            PacketHandler.Instance.ParsingPacket(buffer, header);
        }

        public override void OnSend(int size)
        {
            // TODO
        }
    }
}
