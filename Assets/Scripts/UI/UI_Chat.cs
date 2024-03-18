using System.Collections;
using System.Collections.Generic;
using Unity.Services.Vivox;
using UnityEngine;
using UnityEngine.UI;

public class UI_Chat : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private InputField messageInputField;
    private ScrollRect textChatScrollRect;
    private 
    void Start()
    {
        VivoxService.Instance.ChannelJoined += GetMessageHistory;
        // VivoxService.Instance.ChannelMessageReceived += OnMessageReceived;   
        messageInputField.onSubmit.AddListener((string message) => MessageSend(message));
    }
    
    public void OnMessageReceived(VivoxMessage message)
    {
        // TODO
    }

    public void GetMessageHistory(string channelName)
    {
        // TODO
    }

    public void MessageSend(string message)
    {
        if(string.IsNullOrEmpty(message))
        {
            return;
        }

        Managers.Vivox.SendTextMessageAsync(message);
    }
}
