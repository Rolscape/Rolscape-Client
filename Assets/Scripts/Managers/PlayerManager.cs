using Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerManager
{
    public MyPlayerController MyPlayer {  get; set; }
    Dictionary<UInt32, GameObject> _players = new Dictionary<UInt32, GameObject>();


    public GameObject GetPlayer(UInt32 id)
    {
        if(_players.ContainsKey(id))
        {
            return _players[id];
        }
        else
        {
            return null;
        }
    }

    public void AddPlayer(PlayerInfo playerInfo, bool isMine = false)
    {
        if(isMine)
        {

        }
        else
        {
            // 캐릭터 Spawn
        }
    }
}
