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

        private void Awake()
        {
            grid = GetComponent<GridLayoutGroup>();
            
            EventManager.BoardCreated += OnBoardCreated;
        }

        private void OnBoardCreated(Board board)
        {
            Create(board);
        }

        private void Create(Board board)
        {
            grid.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            grid.constraintCount = board.Rows();

            for (int row = 0; row < board.Rows(); row++)
            {
                for (int column = 0; column < board.Columns(); column++)
                {
                    CellView cellView = Instantiate<CellView>(cellViewPrefab);
                    cellView.transform.SetParent(this.transform, false);
                    GemType type = board[row, column].Type;
                    cellView.SetIcon(settings.GemsData.Single(data => data.type == type).sprite);
                }
            }
        }

    }

}
