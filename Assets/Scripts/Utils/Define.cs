using System.Collections;
using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;
using UnityEngine;

public class Define 
{
    public enum PlayerJob
    {
        Student,
        Teacher,
        Police,
    }

    public struct PathMissionPos
    {
        public Pos StudentPos;
        public Pos TeacherPos;
    }
    
    public struct Pos
    {
        public int X;
        public int Y;
    }
    public enum SingleMissionType
    {
        SingleIdle,
        StudentMath,
        StudentAlpha,
        TeacherSudoku,
        TeacherErase,
        PoliceCatch,
    }
    
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
