using System;
using Xunit;

namespace CodeBasic.Tests
{
    public class PokdengTest
    {
        // Normal cases
        // Alternative cases
        // Exception cases

        [Theory]
        //house pok 
        [InlineData(100, 5, 8, "Club", 1, "Heart", 0, "", 1, "Diamond", 5, "Heart", 0, "", 95)]
        ////player pok
        [InlineData(100, 5, 5, "Club", 1, "Heart", 0, "", 4, "Diamond", 5, "Heart", 0, "", 105)]
        ////both pok house win
        [InlineData(100, 5, 8, "Club", 1, "Heart", 0, "", 3, "Diamond", 5, "Diamond", 0, "", 95)]
        ////both pok player win
        [InlineData(100, 5, 7, "Club", 1, "Heart", 0, "", 4, "Diamond", 5, "Heart", 0, "", 105)]

        ////player threesame
        [InlineData(100, 5, 3, "Club", 1, "Heart", 0, "", 3, "Diamond", 3, "Heart", 3, "Club", 125)]
        ////house threesame
        [InlineData(100, 5, 1, "Club", 1, "Heart", 1, "Spade", 2, "Diamond", 3, "Heart", 3, "Club", 75)]
        ////both threesame player win
        [InlineData(100, 5, 1, "Club", 1, "Heart", 1, "Spade", 3, "Diamond", 3, "Heart", 3, "Club", 125)]
        ////both threesame house win
        [InlineData(100, 5, 5, "Club", 5, "Heart", 5, "Spade", 3, "Diamond", 3, "Heart", 3, "Club", 75)]

        //player ghost
        [InlineData(100, 5, 3, "Club", 1, "Heart", 0, "", 10, "Diamond", 11, "Heart", 10, "Club", 115)]
        //house ghost
        [InlineData(100, 5, 10, "Club", 11, "Heart", 10, "Heart", 10, "Diamond", 3, "Heart", 10, "Club", 85)]
        //both ghost player win
        [InlineData(100, 5, 10, "Club", 11, "Heart", 10, "Heart", 10, "Diamond", 12, "Heart", 11, "Club", 115)]
        //both ghost house win
        [InlineData(100, 5, 10, "Club", 12, "Heart", 12, "Heart", 10, "Diamond", 10, "Heart", 11, "Club", 85)]

        //house straight
        [InlineData(100, 5, 2, "Club", 3, "Heart", 4, "Club", 1, "Diamond", 5, "Heart", 0, "", 85)]
        //player straight
        [InlineData(100, 5, 2, "Club", 2, "Heart", 4, "Club", 4, "Diamond", 5, "Heart", 6, "Heart", 115)]
        //both straight player win
        [InlineData(100, 5, 2, "Club", 3, "Heart", 4, "Club", 4, "Diamond", 5, "Heart", 6, "Heart", 115)]
        //both straight house win
        [InlineData(100, 5, 8, "Club", 9, "Heart", 10, "Club", 4, "Diamond", 5, "Heart", 6, "Heart", 85)]

        //No one pok
        [InlineData(100, 5, 3, "Club", 1, "Heart", 0, "", 1, "Diamond", 5, "Heart", 0, "", 105)]
        [InlineData(100, 5, 3, "Club", 1, "Heart", 0, "", 1, "Diamond", 5, "Diamond", 0, "", 110)]
        [InlineData(100, 5, 3, "Club", 1, "Heart", 1, "Club", 1, "Diamond", 3, "Diamond", 0, "", 90)]
        public void NormalScoreNo(
            int playerBalance,
            int betAmount,
            int p1CardNo1, 
            string p1CardSymbol1, 
            int p1CardNo2, 
            string p1CardSymbol2, 
            int p1CardNo3,
            string p1CardSymbol3,
            int p2CardNo1, 
            string p2CardSymbol1, 
            int p2CardNo2, 
            string p2CardSymbol2, 
            int p2CardNo3,
            string p2CardSymbol3,
            int expected)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = playerBalance;

            sut.CheckGameResult(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3, p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            
            Assert.Equal(expected, sut.PlayerBalance);
        }
    }
}
