using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TM1 : UI_Popup
{
   public int _gridSizeX = 9;
   public int _gridSizeY = 6;
   protected Color _color = Color.red;
   protected float _cellSize = 50f;
   protected float _cellSpacing = 5f;

   public int _curPos;
   protected Image[] _grid;
   protected Image _CurrentTile;
       
   public override void Init()
   { 
      base.Init();
      _grid = new Image[_gridSizeX * _gridSizeY];
      CreateGrid();
      _CurrentTile = _grid[0];

      Managers.Mission.MoveTile -= MoveTile;
      Managers.Mission.MoveTile += MoveTile;
   }
   private void Start() 
   { 
      Init();
   }
    
   protected void CreateGrid()
   {
      gameObject.transform.position = Vector3.zero;
      GameObject gridGo = new GameObject { name = "Grid" };
      gridGo.transform.SetParent(transform);
      GridLayoutGroup gridLayoutGroup = gridGo.GetOrAddComponent<GridLayoutGroup>();
      gridLayoutGroup.cellSize = new Vector2(_cellSize, _cellSize);
      gridLayoutGroup.spacing = new Vector2(_cellSpacing, _cellSpacing);
      gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
      gridLayoutGroup.constraintCount = _gridSizeX;
      
      for (int i = 0; i < _gridSizeX * _gridSizeY; i++)
      { 
         GameObject cellGO = new GameObject("Cell");
         cellGO.transform.SetParent(gridGo.transform);
         Image image = cellGO.AddComponent<Image>();
         image.color = Color.white;
             
         _grid[i] = image;
      }
    
      // Grid Layout Group의 크기 설정
      RectTransform gridRect = gameObject.GetComponent<RectTransform>();
      float gridWidth = _gridSizeX * (_cellSize + _cellSpacing) - _cellSpacing;
      float gridHeight = _gridSizeY * (_cellSize + _cellSpacing) - _cellSpacing;
      gridRect.sizeDelta = new Vector2(gridWidth, gridHeight);
   }

   public virtual void MoveTile(int nextPos)
   {
      _grid[_curPos].color = Color.white;
      _grid[nextPos].color = _color;
      _curPos = nextPos;
   }
}
