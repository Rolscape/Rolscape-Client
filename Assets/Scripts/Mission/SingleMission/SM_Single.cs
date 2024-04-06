
using UnityEngine;

public class SM_Single : MonoBehaviour
{
    public void Init()
    {
        Managers.Mission.SMStart -= MissionStart;
        Managers.Mission.SMStart += MissionStart;


        Managers.Mission.SMStop -= MissionStop;
        Managers.Mission.SMStop += MissionStop;
    }

    private void Start()
    {
        Init();
    }

    public virtual void MissionStart()
    {
        
    }

    public virtual void MissionStop(bool isSuccess)
    {

    }

    public void Clear()
    {
        Managers.Mission.SMStart -= MissionStart;
        Managers.Mission.SMStop -= MissionStop;
    }
}