using System;
using Match3;

namespace Match3
{
    public static class EventManager
    {
        public static event Action NewGameRequest = delegate {};

        public static event Action<Cell> CellViewClicked = delegate { };

        
        public static void RaiseNewGameRequest()
        {
            NewGameRequest();
        }

        
        public static void RaiseCellViewClicked(Cell cell)
        {
            CellViewClicked(cell);
        }
    }

}
