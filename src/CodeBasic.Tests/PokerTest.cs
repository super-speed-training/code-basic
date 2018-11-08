using System;
using Xunit;

namespace CodeBasic.Tests
{
    public class PokerTest
    {
        // Normal cases
        // Alternative cases
        // Exception cases

        [Theory]
        [InlineData(50,10,2,4,0,"Club", "Club", "Club", 3, 4, 0, "Club", "Club", "Club",60)]
        [InlineData(100,20, 2, 4, 3, "Club", "Club", "Club", 3, 4, 5, "Club", "Club", "Club",80)]
        [InlineData(50,20, 0, 0, 0, "", "", "", 0, 0, 0, "", "", "",50)]
        [InlineData(200,30, 3, 5, 0, "Club", "Diamond", "Heart", 3, 2, 0, "Diamond", "Heart", "Club",170)]
        [InlineData(200,30, 3, 7, 0, "Club", "Diamond", "Heart", 3, 6, 0, "Diamond", "Heart", "Club",230)]
        [InlineData(300,50, 3, 5, 0, "Club", "Diamond", "Heart", 3, 6, 0, "Diamond", "Heart", "Club",350)]
        public void Pokdeng(int playerBalance,int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3,int expectedPlayerBalance)
        {
            var poker = new Poker();
            poker.PlayerBalance = playerBalance;
            poker.CheckGameResult(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2,p1CardSymbol3, p2CardNo1, p2CardNo2,p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            Assert.Equal(expectedPlayerBalance, poker.PlayerBalance);
        }
    }
}
