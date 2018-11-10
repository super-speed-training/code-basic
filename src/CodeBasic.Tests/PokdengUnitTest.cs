using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static CodeBasic.Pokdeng;

namespace CodeBasic.Tests
{
    public class PokdengUnitTest
    {
        // Normal cases
        // Alternative cases
        // Exception cases

        [Fact]
        public void DeckHave52CardAnd4Type()
        {
            var pokdeng = new Pokdeng();
            var deck = pokdeng.GetNewDeck();
            var type = new List<string> { "Club", "Diamond", "Heart", "Spade" };
            Assert.Equal(52, deck.Count());
            foreach (var item in type)
            {
                Assert.Equal(13, deck.Where(it => it.Symbol == item).Count());
            }
        }

        [Theory]
        [InlineData(8)]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(30)]
        public void GetRandomCardShouldDownMaxOfDeck(int getCardTime)
        {
            var pokdeng = new Pokdeng();
            var deck = pokdeng.GetNewDeck();
            var AllCard = deck.Count();
            for (int i = 0; i < getCardTime; i++)
            {
                pokdeng.GetRandomCard(deck);
            }
            var CardCount = deck.Count();
            Assert.Equal(AllCard, CardCount + getCardTime);
        }

        [Theory]
        [InlineData(4, 4, 0, "Club", "Diamond", "", HandType.ป๊อก, 8, 2)]
        [InlineData(4, 5, 0, "Club", "Diamond", "", HandType.ป๊อก, 9, 1)]
        [InlineData(4, 3, 0, "Club", "Diamond", "", HandType.ไม่มี, 7, 1)]
        [InlineData(4, 3, 0, "Club", "Club", "", HandType.ไม่มี, 7, 2)]
        [InlineData(3, 3, 3, "Club", "Diamond", "Heart", HandType.ตอง, 9, 5)]
        [InlineData(13, 12, 11, "Club", "Diamond", "Heart", HandType.ผี, 0, 3)]
        [InlineData(2, 3, 4, "Club", "Diamond", "Heart", HandType.เรียง, 9, 3)]
        [InlineData(4, 5, 3, "Club", "Diamond", "Heart", HandType.เรียง, 2, 3)]
        public void HandCalculatorShouldWork(int CardNo1, int CardNo2, int CardNo3, string CardSymbol1, string CardSymbol2, string CardSymbol3, HandType expectedHandType, int expectedPoint, int expectedBetRate)
        {
            var pokdeng = new Pokdeng();
            var Result = pokdeng.CalculateCardInHand(CardNo1, CardNo2, CardNo3, CardSymbol1, CardSymbol2, CardSymbol3);
            Assert.Equal(expectedHandType, Result.Hand);
            Assert.Equal(expectedPoint, Result.Point);
            Assert.Equal(expectedBetRate, Result.BetReturnRate);
        }

        [Theory]
        [InlineData(4, "Club", false)]
        [InlineData(99, "Club", true)]
        [InlineData(0, "Club", true)]
        public void CheckCardNoCheat(int CardNo, string CardSymbol, bool expected)
        {
            var pokdeng = new Pokdeng();
            var deck = pokdeng.GetNewDeck();
            var haveCheat = pokdeng.CheckCard(CardNo, CardSymbol, deck);
        }

        [Theory]
        [InlineData(HandType.ป๊อก, 8, 2, HandType.ไม่มี, 7, 1, 5, -10)]
        [InlineData(HandType.ป๊อก, 8, 2, HandType.ตอง, 9, 5, 5, -10)]
        [InlineData(HandType.ไม่มี, 3, 3, HandType.ผี, 0, 3, 5, 15)]
        [InlineData(HandType.ไม่มี, 3, 3, HandType.ตอง, 9, 5, 5, 25)]
        [InlineData(HandType.ไม่มี, 7, 2, HandType.ไม่มี, 7, 3, 5, 0)]
        [InlineData(HandType.ตอง, 9, 5, HandType.ตอง, 6, 5, 5, 0)]
        [InlineData(HandType.ป๊อก, 8, 2, HandType.ป๊อก, 9, 2, 5, 10)]
        public void WinnerCalculatorShouldWork(HandType p1HandType, int p1Point, int p1BetRate, HandType p2HandType, int p2Point, int p2BetRate, int betAmount, int expectedReturnAmount)
        {
            var p1Hand = new HandResult { Point = p1Point, Hand = p1HandType, BetReturnRate = p1BetRate };
            var p2Hand = new HandResult { Point = p2Point, Hand = p2HandType, BetReturnRate = p2BetRate };
            var pokdeng = new Pokdeng();
            var ReturnAmount = pokdeng.WinnerCalculator(p1Hand, p2Hand, betAmount);
            Assert.Equal(expectedReturnAmount, ReturnAmount);
        }

        [Theory]
        [InlineData(140, 125, 5, 4, 3, 0, "Diamond", "Diamond", "", 4, 5, 3, "Club", "Club", "Heart")]
        [InlineData(115, 125, 5, 4, 4, 0, "Heart", "Diamond", "", 4, 5, 3, "Club", "Diamond", "Heart")]
        [InlineData(125, 125, 5, 4, 4, 0, "Club", "Diamond", "", 4, 4, 0, "Club", "Diamond", "")]
        [InlineData(125, 125, 5, 0, 4, 0, "Club", "Diamond", "", 4, 4, 0, "Club", "Diamond", "")]
        [InlineData(125, 125, 5, 99, 4, 0, "Club", "Diamond", "", 4, 4, 0, "Club", "Diamond", "")]
        [InlineData(100, 125, 5, 13, 13, 13, "Club", "Diamond", "Heart", 3, 4, 0, "Club", "Diamond", "")]
        [InlineData(135, 125, 5, 13, 13, 13, "Club", "Diamond", "Heart", 4, 4, 0, "Club", "Diamond", "")]
        [InlineData(100, 125, 5, 13, 13, 13, "Club", "Diamond", "Heart", 12, 11, 10, "Club", "Diamond", "Diamond")]
        [InlineData(110, 125, 5, 6, 7, 8, "Club", "Diamond", "Heart", 1, 1, 2, "Club", "Diamond", "Diamond")]
        [InlineData(140, 125, 5, 1, 1, 2, "Club", "Diamond", "Diamond", 6, 7, 8, "Club", "Diamond", "Heart")]
        [InlineData(40, 25, 5, 1, 1, 2, "Club", "Diamond", "Diamond", 6, 7, 8, "Club", "Diamond", "Heart")]
        [InlineData(15, 15, 5, 1, 1, 2, "Club", "Diamond", "Diamond", 6, 7, 8, "Club", "Diamond", "Heart")]
        [InlineData(0, 25, 5, 13, 13, 13, "Club", "Diamond", "Heart", 12, 11, 10, "Club", "Diamond", "Diamond")]
        public void CheckGameResultShouldWork(int expected, int playerBalance, int betAmount, int p1CardNo1, int p1CardNo2, int p1CardNo3, string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3, int p2CardNo1, int p2CardNo2, int p2CardNo3, string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            var pokdeng = new Pokdeng();
            pokdeng.PlayerBalance = playerBalance;
            pokdeng.CheckGameResult(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3, p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            Assert.Equal(expected, pokdeng.PlayerBalance);
        }
    }
}
