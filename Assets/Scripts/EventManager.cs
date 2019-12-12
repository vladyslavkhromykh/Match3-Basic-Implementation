using System;
using Match3;

namespace Match3
{
    public static class EventManager
    {
        public static event Action NewGameRequest = delegate {};

        public static void RaiseNewGameRequest()
        {
            NewGameRequest();
        }
        
        public static event Action<Board> BoardCreated = delegate { };

        public static void RaiseBoardCreated(Board board)
        {
            BoardCreated(board);
        }

        public static event Action<GameSession> SessionCreated = delegate { };

        public static void RaiseSessionCreated(GameSession gameSession)
        {
            SessionCreated(gameSession);
        }
    }

}
