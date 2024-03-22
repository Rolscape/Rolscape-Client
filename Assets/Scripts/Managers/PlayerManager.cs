using Google.Protobuf.Collections;
using Protocol;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager
{
    public uint MyPlayerID {  get; private set; }
    public GameObject MyPlayer { get; set; }
    public GameObject Camera { get; set; }
    public MyPlayerController MyPlayerController { get; set; }
    Dictionary<uint, GameObject> _players = new Dictionary<uint, GameObject>();

    public GameObject GetPlayer(UInt32 id)
    {
        if (_players.ContainsKey(id))
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
        if (GetPlayer(playerInfo.Id) != null)
            return;

        GameObject player = Managers.Resource.InstantiatePlayer(playerInfo.PlayerJob);
        if (player == null)
            return;

        if (isMine)
        {
            Debug.Log(playerInfo.PlayerJob);
            MyPlayer = player;

            MyPlayerController controller = Util.GetOrAddComponent<MyPlayerController>(player);
            if (controller == null)
                return;

            MyPlayerID = playerInfo.Id;
            controller.Info = playerInfo;
            controller.SyncPos(new Vector3(playerInfo.PosX, 1, playerInfo.PosZ));
            MyPlayerController = controller;

            GameObject camera = Managers.Resource.Instantiate("Camera/MainCamera");
            if (camera == null)
                return;
            Camera = camera;
            camera.GetComponent<CameraController>()._player = MyPlayer;
        }
        else
        {
            // 캐릭터 Spawn
            // 0 0 0
            _players.Add(playerInfo.Id, player);

            PlayerController controller = Util.GetOrAddComponent<PlayerController>(player);
            controller.Info = playerInfo;
            controller.SyncPos(new Vector3(playerInfo.PosX, 1, playerInfo.PosZ));
        }
    }

    public void OnGameStart(S_GAME_START packet)
    {
        Clear();

        foreach (var player in packet.PlayerInfo)
        {
            if(player.Id == MyPlayerID)
                AddPlayer(player, true);
            else
                AddPlayer(player, false);
        }
    }

    public void MovePlayerToScene(Scene scene)
    {
        foreach (var player in _players.Values)
        {
            SceneManager.MoveGameObjectToScene(player, scene);
        }

        {
            SceneManager.MoveGameObjectToScene(MyPlayer, scene);
            SceneManager.MoveGameObjectToScene(Camera, scene);
        }
    }

    public void SyncPlayerInfo(PlayerMoveInfo moveInfo)
    {
        GameObject player = GetPlayer(moveInfo.Id);
        if (player == null)
            return;

        PlayerController controller = player.GetComponent<PlayerController>();
        controller.MoveInfo = moveInfo;
    }

    public void Update()
    {

    }

    public void Clear()
    {
        MyPlayer = null;
        Camera = null;
        MyPlayerController = null;
        _players.Clear();
    }
}
