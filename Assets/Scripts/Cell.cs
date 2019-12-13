using System;
using UnityEngine;

namespace Match3
{
    public class Cell
    {
        private GemType type;

        private bool isSelected;

        private int row;
        private int column;

        public int Row
        {
            get { return row; }
        }

        public int Column
        {
            get { return column; }
        }

        public GemType Type
        {
            get { return type; }
        }
        
        public bool IsSelected
        {
            get { return isSelected; }
        }

        public void SetAddress(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
        
        public Cell(int row, int column, GemType gemType)
        {
            SetAddress(row, column);
            
            if (gemType == GemType.None)
            {
                throw new ArgumentException(string.Format("Cell should not be initialized with {0}.", GemType.None));
            }
            
            this.type = gemType;
        }

        public void Select()
        {
            if (this.isSelected)
            {
                return;
            }

            isSelected = true;
        }
        
        public void Deselect()
        {
            if (!this.isSelected)
            {
                return;
            }

            isSelected = false;
        }

        public void Clear()
        {
            this.type = GemType.None;
        }

        public bool IsNeighbor(Cell other)
        {
            return (Mathf.Abs(row - other.row) == 1 && Mathf.Abs(column - other.column) == 1) ||
                   (Mathf.Abs(row - other.row) == 0 && Mathf.Abs(column - other.column) == 1) ||
                   (Mathf.Abs(row - other.row) == 1 && Mathf.Abs(column - other.column) == 0);
        }

        public override string ToString()
        {
            return string.Format("Cell - Type: {0}; Row:{1}; Column:{2}; Selected:{3}.", type, row, column, isSelected);
        }
    }
}