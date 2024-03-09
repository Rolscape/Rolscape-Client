using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Vivox;
using UnityEngine;
using UnityEngine.UI;

public class VoiceStartController : MonoBehaviour
{
    [SerializeField]
    private Button StartButton;

    [SerializeField]
    private Button SendChatButton;

    [SerializeField]
    private TMP_InputField nameInput;

    // Start is called before the first frame update
    private void Start()
    {
        VivoxService.Instance.LoggedIn += OnLoggedIn;
        VivoxService.Instance.LoggedOut += OnLoggedOut;
        VivoxService.Instance.ConnectionRecovered += OnConnectionRecovered;
        VivoxService.Instance.ConnectionRecovering += OnConnectionRecovering;
        VivoxService.Instance.ConnectionFailedToRecover += OnConnectionFailedToRecover;

        VivoxService.Instance.ChannelJoined += OnChannelJoined;
        VivoxService.Instance.ChannelLeft += OnChannelLeft;

        StartButton.onClick.AddListener(InsideRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        VivoxService.Instance.LoggedIn -= OnLoggedIn;
        VivoxService.Instance.LoggedOut -= OnLoggedOut;
        VivoxService.Instance.ConnectionRecovered -= OnConnectionRecovered;
        VivoxService.Instance.ConnectionRecovering -= OnConnectionRecovering;
        VivoxService.Instance.ConnectionFailedToRecover -= OnConnectionFailedToRecover;

        VivoxService.Instance.ChannelJoined -= OnChannelJoined;
        VivoxService.Instance.ChannelLeft -= OnChannelLeft;
    }

    private void OnLoggedIn()
    {
        Debug.Log("LoggedIn");
    }

    private void OnLoggedOut()
    {
        Debug.Log("Logged out");
    }

    private void OnConnectionRecovered()
    {
        Debug.Log("Connection Recovered");
    }

    private void OnConnectionRecovering()
    {
        Debug.Log("Connection Recovering");
    }

    private void OnConnectionFailedToRecover()
    {
        Debug.Log("Failed Connection Recovered");
    }
    private void OnChannelJoined(string channel)
    {
        Debug.Log($"{channel} : Channel Joined");
    }
    private void OnChannelLeft(string channel)
    {

    }

    private async void InsideRoom()
    {
        StartButton.interactable = false;
        // 로그인
        await Managers.Vivox.LoginAsync("Test");

        // 룸 입장
        await Managers.Vivox.JoinChannel("TestChannel");
    }
}
