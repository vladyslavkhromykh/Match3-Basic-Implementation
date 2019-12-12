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
            this.cells = new Cell[settings.BoardSize, settings.BoardSize];
            this.distribution = distribution;

            FillCells();
        }

        private void FillCells()
        {
            for (int row = 0; row < this.cells.GetLength(0); row++)
            {
                for (int column = 0; column < this.cells.GetLength(1); column++)
                {
                    GemType type = this.distribution.GetNext();
                    this.cells[row, column] = new Cell(type);
                }
            } 
        }
    }
}
