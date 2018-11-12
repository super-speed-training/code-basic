using System;
using Xunit;

namespace CodeBasic.Tests
{
    public class TestPokdeng
    {
        private const string Club = "Club";
        private const string Diamond = "Diamond";
        private const string Heart = "Heart";
        private const string Spade = "Spade";


        [Theory(DisplayName = "ผู้เล่นชนะเจ้ามือด้วยแต้มที่สูงกว่า")]
        [InlineData(100, 1, 1, Club, Club, 1, 2, Club, Club, 1000, 1100)]
        [InlineData(100, 1, 1, Club, Club, 1, 3, Club, Club, 1000, 1100)]
        [InlineData(100, 1, 1, Club, Club, 1, 4, Club, Club, 1000, 1100)]
        public void PlayerWinDealer(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "ผู้เล่นแพ้เจ้ามือ")]
        [InlineData(100, 1, 2, Club, Club, 1, 1, Club, Club, 1000, 900)]
        [InlineData(100, 1, 3, Club, Club, 1, 1, Club, Club, 1000, 900)]
        [InlineData(100, 1, 4, Club, Club, 1, 1, Club, Club, 1000, 900)]
        public void PlayerLoseDealer(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "ผู้เล่นเสมอเจ้ามือ")]
        [InlineData(100, 1, 1, Club, Club, 1, 1, Club, Club, 1000, 1000)]
        [InlineData(100, 2, 2, Club, Club, 2, 2, Club, Club, 1000, 1000)]
        [InlineData(100, 3, 3, Club, Club, 3, 3, Club, Club, 1000, 1000)]
        public void PlayerDrawDealer(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "ผู้เล่นชนะด้วยป๊อก 9 และได้เงิน x 2")]
        [InlineData(100, 1, 1, Club, Club, 8, 1, Club, Club, 1000, 1100)]
        [InlineData(100, 3, 2, Club, Club, 7, 2, Club, Club, 1000, 1100)]
        [InlineData(100, 1, 4, Club, Club, 5, 4, Club, Club, 1000, 1100)]
        public void PlayerWinWithPok9(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "ผู้เล่นชนะด้วยป๊อก 8 และได้เงิน x 2")]
        [InlineData(100, 1, 1, Club, Club, 7, 1, Club, Club, 1000, 1100)]
        [InlineData(100, 3, 2, Club, Club, 7, 1, Club, Club, 1000, 1100)]
        [InlineData(100, 1, 4, Club, Club, 5, 3, Club, Club, 1000, 1100)]
        public void PlayerWinWithPok8(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "เจ้ามือชนะด้วยป๊อก 9 และได้เงิน x 2")]
        [InlineData(100, 7, 2, Club, Club, 1, 1, Club, Club, 1000, 1200)]
        [InlineData(100, 8, 1, Club, Club, 3, 1, Club, Club, 1000, 1200)]
        [InlineData(100, 5, 4, Club, Club, 2, 3, Club, Club, 1000, 1200)]
        public void DealerWinWithPok9(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "เจ้ามือชนะด้วยป๊อก 8 และได้เงิน x 2")]
        [InlineData(100, 7, 1, Club, Club, 1, 1, Club, Club, 1000, 1200)]
        [InlineData(100, 6, 2, Club, Club, 3, 1, Club, Club, 1000, 1200)]
        [InlineData(100, 5, 3, Club, Club, 2, 3, Club, Club, 1000, 1200)]
        public void DealerWinWithPok8(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "ผู้เล่นชนะด้วยไพ่เด้ง 3 ใบ สามเด้ง")]
        [InlineData(100, 1, 1, 1, Club, Diamond, Club, 2, 2, 1, Club, Club, Club, 1000, 1300)]
        public void PlayerWin3Card(int bet, int p1cn1, int p1cn2, int p1cn3, string p1cs1, string p1cs2, string p1cs3, int p2cn1, int p2cn2, int p2cn3, string p2cs1, string p2cs2, string p2cs3, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, p1cn3, p1cs1, p1cs2, p1cs3, p2cn1, p2cn2, p2cn3, p2cs1, p2cs2, p2cs3);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "เจ้ามือแพ้ด้วยไพ่เด้ง 3 ใบ สามเด้ง")]
        [InlineData(100, 1, 1, 1, Club, Diamond, Club, 2, 2, 1, Club, Club, Club, 1000, 1300)]
        public void PlayerLose3Card(int bet, int p1cn1, int p1cn2, int p1cn3, string p1cs1, string p1cs2, string p1cs3, int p2cn1, int p2cn2, int p2cn3, string p2cs1, string p2cs2, string p2cs3, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, p1cn3, p1cs1, p1cs2, p1cs3, p2cn1, p2cn2, p2cn3, p2cs1, p2cs2, p2cs3);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }



        // Normal cases
        // Alternative cases
        // Exception cases


    }
}
