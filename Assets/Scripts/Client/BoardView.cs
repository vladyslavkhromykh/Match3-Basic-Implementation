using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Match3;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.View
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public sealed class BoardView : MonoBehaviour
    {
        [SerializeField]
        private CellView cellViewPrefab;
        [SerializeField]
        private Settings settings;
        private GridLayoutGroup grid;

        private Board board;
        private CellView[,] cellViews;

        public void ApplyBoard(Board board)
        {
            this.board = board;
            this.board.Created += OnBoardCreated;
            this.board.Changed += OnBoardChanged;
        }

        public void Dispose()
        {
            this.board.Created -= OnBoardCreated;
            this.board.Changed -= OnBoardChanged;
        }

        private void OnBoardChanged(Board board)
        {
            for (int row = 0; row < board.Rows(); row++)
            {
                for (int column = 0; column < board.Columns(); column++)
                {
                    CellView cellView = this.cellViews[row, column];
                    cellView.UpdateView(board[row, column], settings);
                }
            }
        }

        private void OnBoardCreated(Board board)
        {
            Create(board);
        }

        private void Create(Board board)
        {
            this.grid= GetComponent<GridLayoutGroup>();
            grid.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            grid.constraintCount = board.Rows();
            this.cellViews = new CellView[board.Rows(), board.Columns()];
            
            for (int row = 0; row < board.Rows(); row++)
            {
                for (int column = 0; column < board.Columns(); column++)
                {
                    CellView cellView = Instantiate<CellView>(cellViewPrefab);
                    cellView.transform.SetParent(this.transform, false);
                    GemType type = board[row, column].Type;
                    cellView.UpdateView(board[row, column], settings);
                    this.cellViews[row, column] = cellView;
                }
            }
        }

    }

}
