using UnityEngine;
using Unity.Services.Vivox;
using System.Threading.Tasks;
using Unity.Services.Core;
using System;
using UnityEngine.Android;
using System.Collections.ObjectModel;
using System.Linq;
using Unity.Services.Authentication;
using System.Collections;

class ChannelSetting
{
    public ChannelSetting()
    {
        AudibleDistance = 32;
        ConversationalDistance = 1;
        AudioFadeIntensityByDistance = 1.0f;
        AudioModel = AudioFadeModel.InverseByDistance;
    }
    public int AudibleDistance { get; set; }
    public int ConversationalDistance { get; set; }
    public float AudioFadeIntensityByDistance { get; set; }
    public AudioFadeModel AudioModel { get; set; }
}

public class VivoxManager
{
    static bool isInit = false;
    static bool isJoinChannel = false;

    string _channelName = "";
    ChannelSetting settings = new ChannelSetting();

    [SerializeField]
    private float positionUpdateRate = 0.5f;

    [SerializeField]
    GameObject _myObject = null;

    public static async void Init()
    {
        if (!isInit)
        {
            isInit = true;
            Debug.Log("Awake");

            await UnityServices.InitializeAsync();
            // 테스트 모드 에서는 사용 X
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            // 실제 인증에서는 JWT Token이 필요
            await VivoxService.Instance.InitializeAsync();

            Debug.Log("Init Success");
        }
    }

    public async Task LoginAsync(string userName)
    {
        LoginOptions options = new LoginOptions()
        {
            DisplayName = userName,
            ParticipantUpdateFrequency = ParticipantPropertyUpdateFrequency.FivePerSecond
        };

        await VivoxService.Instance.LoginAsync(options);
    }

    public async Task LogoutAsync()
    {
        await VivoxService.Instance.LogoutAsync();
    }

    public async Task JoinChannel(string channelName)
    {
        try
        {
            // AudibleDistance : 들을 수 있는 거리에 대한 최대 거리
            // ConversationalDistance : 목소리가 약해지기 시작하는 거리
            // AudioFadeIntensityByDistance : 오디오 페이드 효과의 강도? 아마 목소리 줄어드는 속도
            // AudioFadeModel : 다양한 거리에서 음성의 크기를 결정하는 모델
            Channel3DProperties channel3DProperties = new Channel3DProperties(
                settings.AudibleDistance,
                settings.ConversationalDistance,
                settings.AudioFadeIntensityByDistance,
                settings.AudioModel
                );

            // 3D 음향(거리에 따른 소리 조절)
            await VivoxService.Instance.JoinPositionalChannelAsync(channelName, ChatCapability.TextAndAudio, channel3DProperties);
            isJoinChannel = true;
            // 2D
            //await VivoxService.Instance.JoinGroupChannelAsync(channelName, ChatCapability.TextAndAudio);
            _channelName = channelName;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public void StartVoice(GameObject myObject)
    {
        _myObject = myObject;
        Managers.Instance.StartCoroutine(Update3DPositionCo(myObject, _channelName));
    }

    public async Task LeaveChannel()
    {
        if (_channelName == "")
            return;

        await VivoxService.Instance.LeaveChannelAsync(_channelName);

        isJoinChannel = false;
        _channelName = "";
    }

    public void AskForPermissions()
    {
        // 앱 권한 요청
        string permissionCode = Permission.Microphone;

        Permission.RequestUserPermission(permissionCode);
    }

    bool IsMicPermissionGranted()
    {
        // 앱 권한 요청
        bool isGranted = Permission.HasUserAuthorizedPermission(Permission.Microphone);

        return isGranted;
    }

    public ReadOnlyCollection<VivoxInputDevice> GetAvailableInputDevices()
    {
        return VivoxService.Instance.AvailableInputDevices;
    }

    public ReadOnlyCollection<VivoxOutputDevice> GetAvailableOutputDevices()
    {
        return VivoxService.Instance.AvailableOutputDevices;
    }

    public void InputDeviceValueChanged(string deviceValue)
    {
        VivoxInputDevice device = GetAvailableInputDevices().Where(device =>
            device.DeviceName == deviceValue).FirstOrDefault();

        VivoxService.Instance.SetActiveInputDeviceAsync(device);
    }

    public void OutputDeviceValueChanged(string deviceValue)
    {
        VivoxOutputDevice device = GetAvailableOutputDevices().Where(device =>
            device.DeviceName == deviceValue).FirstOrDefault();

        VivoxService.Instance.SetActiveOutputDeviceAsync(device);
    }

    public void InputVolumeChanged(float volume)
    {
        VivoxService.Instance.SetInputDeviceVolume((int)volume);
    }

    public void OutputVolumeChanged(float volume)
    {
        VivoxService.Instance.SetOutputDeviceVolume((int)volume);
    }

    private IEnumerator Update3DPositionCo(GameObject speakeObj, string channelName)
    {
        while (isJoinChannel)
        {
            //위치를 업데이트
            VivoxService.Instance.Set3DPosition(speakeObj, channelName);
            yield return new WaitForSeconds(positionUpdateRate);
        }
    }

    // 채팅 보내기
    public async void SendTextMessageAsync(string text)
    {
        await VivoxService.Instance.SendChannelTextMessageAsync(_channelName, text);
    }

    // 채팅 받는 것은 ChannelMessagedReceived에 추가해놔야함.
}