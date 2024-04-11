using Protocol;
using System.Diagnostics;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SMStart : UI_Popup
{
    enum Buttons
    {
        PointButton,
    }
    
    enum Texts
    {
        PointText,
    }
    public override void Init()
    {
        base.Init();
        
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));

        GetText((int)Texts.PointText).text = "Mission Start";
        
        GetButton((int)Buttons.PointButton).gameObject.BindEvent(OnButtonClicked);
    }

    void Start()
    {
        Init();
    }

    public void OnButtonClicked(PointerEventData data)
    {
        UnityEngine.Debug.Log("OnButtonClicked");

        Managers.UI.ClosePopupUI();
        //Managers.Mission.SMStart.Invoke();
        
        Managers.Player.MyPlayerController.SendSingleMssionStart();
    }
}
