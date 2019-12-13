using System;
using Match3;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class BoardTests
    {
        [Test]
        public void BoardHasNoCombinationsOnStart()
        {
            Settings settings = Resources.Load<Settings>("Settings");
            Board board = new Board(settings, new GemDistributionAlgorithm(settings));
            board.Create();
            ValueTuple <bool, bool[,]> matchingData = board.GetHorizontalMatchingMatrix();
            Assert.False(matchingData.Item1);
        }
    }
}
