using Protocol;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class SM_StudentCalTrigger : SM_DefaultTrigger
{
    public override void Init()
    {
        _missionType = SingleMissionType.StudentMath;
    }

    protected override void TriggerEnterEvent(Collider other)
    {
        base.TriggerEnterEvent(other);
    }

    protected override void TriggerExitEvent(Collider other)
    {
        base.TriggerExitEvent(other);
    }


    public void Clear()
    {
        
    }
}
