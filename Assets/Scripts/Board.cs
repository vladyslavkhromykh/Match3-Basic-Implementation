using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3
{
    public sealed class Board
    {
        private Cell[,] cells;
        private GemDistributionAlgorithm distribution;
        
        public Board(Settings settings, GemDistributionAlgorithm distribution)
        {
            this.cells = new Cell[settings.RowsCount, settings.ColumnsCount];
            this.distribution = distribution;

            FillCells();
            
            EventManager.RaiseBoardCreated(this);
        }

        public Cell this[int row, int column]
        {
            get
            {
                return this.cells[row, column];
            }
        }

        public int Rows()
        {
            return cells.GetLength(0);
        }
        
        public int Columns()
        {
            return cells.GetLength(1);
        }

        private void FillCells()
        {
            for (int row = 0; row < this.cells.GetLength(0); row++)
            {
                for (int column = 0; column < this.cells.GetLength(1); column++)
                {
                    Cell leftCell = column > 0 ? this.cells[row, column - 1] : null;
                    Cell topCell = row > 0 ? this.cells[row - 1, column] : null;
                    
                    GemType cellType = GemType.None;
                    
                    GemType type;
                    do
                    {
                        type = this.distribution.GetNext();
                    } while (GemTypeSameAsOneOfNeighborCells(type, leftCell, topCell));

                    this.cells[row, column] = new Cell(type);
                }
            } 
        }

        private bool GemTypeSameAsOneOfNeighborCells(GemType type, Cell leftCell, Cell topCell)
        {
            if (leftCell != null && topCell != null)
            {
                return type == leftCell.Type || type == topCell.Type;
            }
            
            if (leftCell != null)
            {
                return type == leftCell.Type;
            }
            
            if (topCell != null)
            {
                return type == topCell.Type;
            }

            return false;
        }
    }
}
