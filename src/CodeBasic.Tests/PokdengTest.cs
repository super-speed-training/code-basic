using System;
using Xunit;

namespace CodeBasic.Tests
{
    public class PokdengTest
    {
        [Theory(DisplayName = "เจ้ามือชนะ")]
        [InlineData(100, new int[] { 1, 4, 0 }, new string[] { "Club", "Diamond", null }, new int[] { 1, 2, 0 }, new string[] { "Club", "Diamond", null }, 1000, 900)]
        [InlineData(100, new int[] { 1, 5, 0 }, new string[] { "Diamond", "Club", null }, new int[] { 1, 13, 0 }, new string[] { "Club", "Diamond", null }, 1000, 900)]
        [InlineData(100, new int[] { 1, 6, 0 }, new string[] { "Club", "Diamond", null }, new int[] { 1, 4, 0 }, new string[] { "Club", "Diamond", null }, 1000, 900)]
        [InlineData(100, new int[] { 4, 4, 0 }, new string[] { "Club", "Club", null }, new int[] { 1, 4, 0 }, new string[] { "Club", "Diamond", null }, 1000, 800)]
        [InlineData(100, new int[] { 4, 5, 0 }, new string[] { "Club", "Diamond", null }, new int[] { 1, 4, 0 }, new string[] { "Club", "Diamond", null }, 1000, 900)]
        [InlineData(100, new int[] { 3, 6, 0 }, new string[] { "Club", "Club", null }, new int[] { 1, 4, 0 }, new string[] { "Club", "Diamond", null }, 1000, 800)]
        [InlineData(100, new int[] { 1, 6, 10 }, new string[] { "Club", "Club", "Diamond" }, new int[] { 1, 4, 1 }, new string[] { "Club", "Diamond", "Diamond" }, 1000, 900)]
        [InlineData(100, new int[] { 3, 6, 13 }, new string[] { "Diamond", "Diamond", "Diamond" }, new int[] { 1, 4, 1 }, new string[] { "Club", "Diamond", "Diamond" }, 1000, 700)]
        [InlineData(100, new int[] { 1, 6, 1 }, new string[] { "Club", "Club", "Club" }, new int[] { 1, 4, 1 }, new string[] { "Club", "Diamond", "Diamond" }, 1000, 700)]
        public void CheckPlayer1Win(int betAmount, int[] Player1CardNos, string[] Player1CardSymbol, int[] Player2CardNos, string[] Player2CardSymbol, int Balance, int Excepted)
        {
            var Pok = new Pokdeng();
            var P = Pok.Checkwin(betAmount, Player1CardNos, Player1CardSymbol, Player2CardNos, Player2CardSymbol, Balance);
            Assert.Equal(Excepted, P);
        }

        [Theory(DisplayName = "ผู้เล่นชนะ")]
        [InlineData(100, new int[] { 1, 4, 0 }, new string[] { "Club", "Diamond", null }, new int[] { 5, 2, 0 }, new string[] { "Club", "Diamond", null }, 1000, 1100)]
        [InlineData(100, new int[] { 1, 4, 0 }, new string[] { "Club", "Diamond", null }, new int[] { 10, 8, 0 }, new string[] { "Club", "Diamond", null }, 1000, 1100)]
        [InlineData(100, new int[] { 1, 3, 0 }, new string[] { "Club", "Diamond", null }, new int[] { 6, 2, 0 }, new string[] { "Diamond", "Diamond", null }, 1000, 1200)]
        [InlineData(100, new int[] { 1, 3, 0 }, new string[] { "Club", "Diamond", null }, new int[] { 5, 4, 0 }, new string[] { "Diamond", "Diamond", null }, 1000, 1200)]
        [InlineData(100, new int[] { 1, 2, 5 }, new string[] { "Club", "Diamond", "Diamond" }, new int[] { 5, 4, 0 }, new string[] { "Diamond", "Diamond", null }, 1000, 1200)]
        [InlineData(100, new int[] { 2, 2, 1 }, new string[] { "Club", "Diamond", "Diamond" }, new int[] { 4, 3, 1 }, new string[] { "Diamond", "Diamond", "Diamond" }, 1000, 1300)]
        [InlineData(100, new int[] { 2, 3, 1 }, new string[] { "Club", "Diamond", "Diamond" }, new int[] { 5, 3, 1 }, new string[] { "Club", "Club", "Club" }, 1000, 1300)]
        public void CheckPlayer2Win(int betAmount, int[] Player1CardNos, string[] Player1CardSymbol, int[] Player2CardNos, string[] Player2CardSymbol, int Balance, int Excepted)
        {
            var Pok = new Pokdeng();
            var P = Pok.Checkwin(betAmount, Player1CardNos, Player1CardSymbol, Player2CardNos, Player2CardSymbol, Balance);
            Assert.Equal(Excepted, P);
        }

        [Theory(DisplayName = "ผู้เล่นเสมอ")]
        [InlineData(100, new int[] { 4, 4, 0 }, new string[] { "Club", "Diamond", null }, new int[] { 5, 3, 0 }, new string[] { "Club", "Diamond", null }, 1000, 1000)]
        [InlineData(100, new int[] { 1, 4, 0 }, new string[] { "Club", "Diamond", null }, new int[] { 5, 13, 0 }, new string[] { "Club", "Diamond", null }, 1000, 1000)]
        [InlineData(100, new int[] { 6, 1, 0 }, new string[] { "Club", "Diamond", null }, new int[] { 7, 12, 0 }, new string[] { "Diamond", "Diamond", null }, 1000, 1000)]
        [InlineData(100, new int[] { 1, 3, 0 }, new string[] { "Club", "Diamond", null }, new int[] { 2, 2, 0 }, new string[] { "Diamond", "Diamond", null }, 1000, 1000)]
        [InlineData(100, new int[] { 1, 3, 1 }, new string[] { "Club", "Diamond", "Club" }, new int[] { 2, 2, 1 }, new string[] { "Diamond", "Diamond", "Diamond" }, 1000, 1000)]
        public void CheckDraw(int betAmount, int[] Player1CardNos, string[] Player1CardSymbol, int[] Player2CardNos, string[] Player2CardSymbol, int Balance, int Excepted)
        {
            var Pok = new Pokdeng();
            var P = Pok.Checkwin(betAmount, Player1CardNos, Player1CardSymbol, Player2CardNos, Player2CardSymbol, Balance);
            Assert.Equal(Excepted, P);
        }
    }
}
