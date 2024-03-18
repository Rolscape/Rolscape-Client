using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

public class UI_TM1Police : UI_Popup
{
   private int gridSizeX = 9;
   private int gridSizeY = 6;
   private float cellSize = 50f;
   private float cellSpacing = 5f;
   
   public override void Init()
   {
      base.Init();
      
      Managers.Mission._grid = new Image[gridSizeX * gridSizeY];
      CreateGrid();
      Managers.Mission._CurrentTile = Managers.Mission._grid[0];
   }

   private void Start()
   {
      Init();
   }

   void CreateGrid()
   {
      
      gameObject.transform.position = Vector3.zero;
      GameObject gridGo = new GameObject { name = "Grid" };
      gridGo.transform.SetParent(transform);
      GridLayoutGroup gridLayoutGroup = gridGo.GetOrAddComponent<GridLayoutGroup>();
      gridLayoutGroup.cellSize = new Vector2(cellSize, cellSize);
      gridLayoutGroup.spacing = new Vector2(cellSpacing, cellSpacing);
      gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
      gridLayoutGroup.constraintCount = gridSizeX;
      
      for (int i = 0; i < gridSizeX * gridSizeY; i++)
      {
         GameObject cellGO = new GameObject("Cell");
         cellGO.transform.SetParent(gridGo.transform);
         Image image = cellGO.AddComponent<Image>();
         image.color = Color.white;
         if(i==Managers.Mission._destPos1)
            image.color = Color.blue;   
         if(i==Managers.Mission._destPos2)
            image.color = Color.black;
         
         Managers.Mission._grid[i] = image;
      }

      // Grid Layout Group의 크기 설정
      RectTransform gridRect = gameObject.GetComponent<RectTransform>();
      float gridWidth = gridSizeX * (cellSize + cellSpacing) - cellSpacing;
      float gridHeight = gridSizeY * (cellSize + cellSpacing) - cellSpacing;
      gridRect.sizeDelta = new Vector2(gridWidth, gridHeight);
   }
   
}
