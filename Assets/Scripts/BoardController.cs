using System.Collections.Generic;
using System.Linq;
using Match3.View;
using UnityEngine;

namespace  Match3
{
    public class BoardController : MonoBehaviour
    {
        [SerializeField]
        private Settings settings;
        private BoardView view;
        private Board board;

        private void Awake()
        {
            this.view = GetComponent<BoardView>();
            this.board = new Board(settings, new GemDistributionAlgorithm(settings));
            
            this.view.ApplyBoard(this.board);
            this.board.Create();
            
            EventManager.CellViewClicked += OnCellViewClicked;
        }

        public void Dispose()
        {
            EventManager.CellViewClicked -= OnCellViewClicked;
            this.view.Dispose();
            this.board.Dispose();
            Destroy(gameObject);
        }
        
        private void OnCellViewClicked(Cell clickedCell)
        {
            IEnumerable<Cell> selectedCells = board.Where(cell => cell.IsSelected);
            if (!selectedCells.Any())
            {
                clickedCell.Select();
                board.RaiseChanged();
                return;
            }

            if (selectedCells.Count() == 1)
            {
                var alreadySelectedCell = selectedCells.Single(cell => cell.IsSelected);

                if (clickedCell == alreadySelectedCell)
                {
                    return;
                }
                
                alreadySelectedCell.Deselect();
                if (clickedCell.IsNeighbor(alreadySelectedCell))
                {
                    board.SwapCells(alreadySelectedCell, clickedCell);
                    board.CheckMatching();
                }
                else
                {
                    clickedCell.Select();
                }
                board.RaiseChanged();
            }
        }

        private void SwapCells(Cell cell1, Cell cell2)
        {
            Cell tempCell1 = cell1;
            board[cell1.Row, cell2.Column] = cell2;
        }
    }

}
