using Protocol;
using UnityEngine;

public class SM_DefaultTrigger : MonoBehaviour
{
    protected SingleMissionType _missionType;

    public virtual void Init()
    {

    }

    private void Start()
    {
        Init();
    }


    private void OnTriggerEnter(Collider other)
    {
        TriggerEnterEvent(other);
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerExitEvent(other);
    }

    protected virtual void TriggerEnterEvent(Collider other)
    {
        if (Managers.Mission.bStudentCal)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject != Managers.Player.MyPlayer)
            return;

        // TODO 미션 했는지 안했는지 여부 및 직업 체크 
        Student student = other.GetComponent<Student>();
        if (student == null)
            return;

        C_SINGLE_MISSION_JOIN joinPkt = new C_SINGLE_MISSION_JOIN();
        joinPkt.PlayerInfo = Managers.Player.MyPlayerController.Info;
        joinPkt.MissionType = _missionType;

        // TODO 암산 미션 시작하기 창 띄우기
        Managers.UI.ShowPopupUI<UI_Start>();
    }

    protected virtual void TriggerExitEvent(Collider other)
    {

    }
}