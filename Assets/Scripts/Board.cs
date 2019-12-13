using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3
{
    public sealed class Board : IEnumerable<Cell>
    {
        private Cell[,] cells;
        private GemDistributionAlgorithm distribution;

        public event Action<Board> Created = delegate { }; 
        public event Action<Board> Changed = delegate { };
        
        public Board(Settings settings, GemDistributionAlgorithm distribution)
        {
            this.cells = new Cell[settings.RowsCount, settings.ColumnsCount];
            this.distribution = distribution;
        }

        public void Dispose()
        {
            this.cells = null;
            this.distribution = null;
        }

        public void Create()
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

                    this.cells[row, column] = new Cell(row, column, type);
                }
            }

            this.Created(this);
        }

        public Cell this[int row, int column]
        {
            get
            {
                return this.cells[row, column];
            }
            set { this.cells[row, column] = value; }
        }

        public int Rows()
        {
            return cells.GetLength(0);
        }
        
        public int Columns()
        {
            return cells.GetLength(1);
        }

        public void SwapCells(Cell cell1, Cell cell2)
        {
            var cell1Address = new ValueTuple<int, int>(cell1.Row, cell1.Column);
            var cell2Address = new ValueTuple<int, int>(cell2.Row, cell2.Column);
            
            this.cells[cell1Address.Item1, cell1Address.Item2] = cell2;
            this.cells[cell2Address.Item1, cell2Address.Item2] = cell1;

            this.cells[cell1Address.Item1, cell1Address.Item2].SetAddress(cell1Address.Item1, cell1Address.Item2);
            this.cells[cell2Address.Item1, cell2Address.Item2].SetAddress(cell2Address.Item1, cell2Address.Item2);
        }

        public void RaiseChanged()
        {
            Changed(this);
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

        public IEnumerator<Cell> GetEnumerator()
        {
            foreach (var cell in cells)
            {
                yield return cell;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
