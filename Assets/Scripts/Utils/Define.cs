using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }
    public enum UIEvent
    {
        Click,
        Drag,   // 이후 드래그 시작, 끝 추가
        
    }
    public enum MouseEvent
    {
        Press,              // 마우스로 클릭 중
        Click,              // 마우스 클릭 
    }
    public enum CameraMode
    {
        QuarterView,
    }
}
