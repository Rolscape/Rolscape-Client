using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_StudentCal : MonoBehaviour
{

   public void Init()
   {
      Managers.Mission.SMStart -= MissionStart;
      Managers.Mission.SMStart += MissionStart;
   }

   private void Start()
   {
      Init();
   }

   public void MissionStart()
   {
      Managers.UI.ShowPopupUI<UI_SMStudentCal>();
   }

   public void Clear()
   {
      Managers.Mission.SMStart -= MissionStart;
      
   }
}
