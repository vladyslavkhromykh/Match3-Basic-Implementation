using System.Collections;
using System.Collections.Generic;
using Match3;
using UnityEngine;

namespace Match3
{
    public class GameSession
    {
        public enum State
        {
            Created,
            Playing,
            Finished
        }

        private State state;
        private Board board;

        public GameSession(Settings settings)
        {
            state = State.Created;
            board = new Board(settings, new GemDistributionAlgorithm(settings));
            
            EventManager.RaiseSessionCreated(this);
        }

        public Board GetBoard()
        {
            return board;
        }

        public State GetState()
        {
            return state;
        }
    }
}