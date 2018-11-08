using System;
using Xunit;

namespace CodeBasic.Tests
{
    public class PokdengTest
    {
        // Normal cases
        // Alternative cases
        // Exception cases Wrong Card

        [Fact]
        public void CheckGameResultByNormalCardTest()
        {

        }

        [Fact]
        public void CheckGameResultByWrongCardTest()
        {

        }

        [Theory]
        [InlineData(100, 10, true)]
        [InlineData(500, 100, true)]
        [InlineData(0, 0, false)]
        [InlineData(0, 10, false)]
        [InlineData(10, 0, false)]
        [InlineData(50, 11, false)]
        public void PlayableTest(int playerBalance, int playerBet, bool expected)
        {
            var player = new Pokdeng();
            player.PlayerBalance = playerBalance;
            var result = player.Playable(playerBet);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetRewardType()
        {

        }

        [Fact]
        public void GetRewardTest()
        {

        }
    }
}
