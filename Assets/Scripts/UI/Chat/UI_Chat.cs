using Protocol;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Chat : UI_Scene
{
    // Start is called before the first frame update
    [SerializeField]
    private TMP_InputField  messageInputField;

    [SerializeField]
    private GameObject      messagePrefab;

    [SerializeField]
    private Transform       parentContent;

    public void Start()
    {
        Init();
    }

    public void Update()
    {
        if(messageInputField.isFocused == false)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                FocusInputField(true);
            }
            else
            {
                Managers.Input.IsChatting = false;
            }
        }
        else
        {
            Managers.Input.IsChatting = true;
        }
    }

    public override void Init()
    {
        base.Init();

        messageInputField.onSubmit.AddListener((string message) => MessageSend(message));
    }

    public void MessageSend(string message)
    {
        if(!string.IsNullOrEmpty(message))
        {
            Debug.Log("MessageSend " + message);

            Managers.Player.MyPlayerController.SendChat(message);
            messageInputField.text = "";
        }
    }

    public void ReceiveMessage(Protocol.Message message)
    {
        string messageText = $"{message.PlayerInfo.UserName} : {message.Messae}";

        GameObject clone = Instantiate(messagePrefab, parentContent);
        clone.GetComponent<TextMeshProUGUI>().text = messageText;
    }

    public void ReceiveAllMessage(Protocol.S_CHAT chat)
    {
        foreach(Protocol.Message message in chat.Messages)
        {
            ReceiveMessage(message);
        }
    }

    public void FocusInputField(bool isFocus)
    {
        if(isFocus)
            messageInputField.ActivateInputField();
        else
            messageInputField.DeactivateInputField();
    }
}
