using Protocol;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager
{
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

        if (isMine)
        {
            Debug.Log("Player Info");

            GameObject player = Managers.Resource.Instantiate("TestMyPlayer");
            if (player == null)
                return;
            MyPlayer = player;

            MyPlayerController controller = player.GetComponent<MyPlayerController>();
            if (controller == null)
                return;

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
            GameObject player = Managers.Resource.Instantiate("TestAnotherPlayer");
            if (player == null)
                return;

            _players.Add(playerInfo.Id, player);

            PlayerController controller = player.GetComponent<PlayerController>();
            controller.Info = playerInfo;
            controller.SyncPos(new Vector3(playerInfo.PosX, 1, playerInfo.PosZ));
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
        
    }
}
