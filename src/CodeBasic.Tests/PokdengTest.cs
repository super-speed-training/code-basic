using System;
using Xunit;

namespace CodeBasic.Tests
{
    public class PokdengTest
    {
        [Theory(DisplayName = "ส่งข้อมูล ระบบตรวจหน้าไพ่ได้ถูกต้อง")]
        [InlineData(new int[] { 4, 5, 0 }, new string[] { "Club", "Diamond", "" }, 9, 1, 1)]
        [InlineData(new int[] { 3, 5, 0 }, new string[] { "Club", "Diamond", "" }, 8, 2, 1)]
        [InlineData(new int[] { 4, 4, 4 }, new string[] { "Club", "Diamond", "Heart" }, 2, 3, 5)]
        [InlineData(new int[] { 11, 12, 13 }, new string[] { "Club", "Diamond", "Heart" }, 0, 4, 3)]
        [InlineData(new int[] { 9, 11, 10 }, new string[] { "Club", "Diamond", "Heart" }, 9, 5, 3)]
        [InlineData(new int[] { 4, 3, 0 }, new string[] { "Club", "Diamond", "" }, 7, 6, 1)]
        [InlineData(new int[] { 3, 3, 0 }, new string[] { "Club", "Diamond", "" }, 6, 6, 2)]
        [InlineData(new int[] { 3, 4, 0 }, new string[] { "Club", "Club", "" }, 7, 6, 2)]
        [InlineData(new int[] { 3, 4, 1 }, new string[] { "Club", "Club", "Diamond" }, 8, 6, 1)]
        [InlineData(new int[] { 3, 4, 1 }, new string[] { "Club", "Club", "Club" }, 8, 6, 3)]
        public void CheckSuitCards(int[] cardNo, string[] cardSymbol, int expectScore, int expectSuitCards, int expectMultiplier)
        {
            var sut = new Pokdeng();
            var handCards = new HandCards();
            handCards.CardNo = cardNo;
            handCards.CardSymbol = cardSymbol;
            var result = sut.CheckSuitCards(handCards);
            Assert.Equal(expectScore, result.Score);
            Assert.Equal(expectSuitCards, result.SuitCard);
            Assert.Equal(expectMultiplier, result.Multiplier);
        }

        [Theory(DisplayName = "ส่งข้อมูล ระบบตรวจผู้ชนะได้ถูกต้อง")]
        [InlineData(new int[] { 3, 5, 0 }, new string[] { "Club", "Diamond", "" }, new int[] { 5, 4, 0 }, new string[] { "Club", "Diamond", "" }, "win")]
        [InlineData(new int[] { 4, 5, 0 }, new string[] { "Club", "Diamond", "" }, new int[] { 5, 3, 0 }, new string[] { "Club", "Diamond", "" }, "lose")]
        [InlineData(new int[] { 4, 5, 0 }, new string[] { "Club", "Diamond", "" }, new int[] { 3, 6, 0 }, new string[] { "Club", "Diamond", "" }, "draw")]
        [InlineData(new int[] { 4, 4, 4 }, new string[] { "Club", "Diamond", "Heart" }, new int[] { 3, 3, 3 }, new string[] { "Club", "Diamond", "Heart" }, "draw")]
        [InlineData(new int[] { 11, 12, 13 }, new string[] { "Club", "Diamond", "Heart" }, new int[] { 13, 11, 11 }, new string[] { "Club", "Diamond", "Heart" }, "draw")]
        [InlineData(new int[] { 1, 2, 3 }, new string[] { "Club", "Diamond", "Heart" }, new int[] { 6, 7, 8 }, new string[] { "Club", "Diamond", "Heart" }, "draw")]
        public void CheckWinner(int[] p1CardNo, string[] p1CardSymbol, int[] p2CardNo, string[] p2CardSymbol, string expectWinner)
        {
            var sut = new Pokdeng();
            var p1HandCards = new HandCards();
            var p2HandCards = new HandCards();
            p1HandCards.CardNo = p1CardNo;
            p2HandCards.CardNo = p2CardNo;
            p1HandCards.CardSymbol = p1CardSymbol;
            p2HandCards.CardSymbol = p2CardSymbol;
            var p1SuitCards = sut.CheckSuitCards(p1HandCards);
            var p2SuitCards = sut.CheckSuitCards(p2HandCards);
            var result = sut.IsWinner(p1SuitCards, p2SuitCards);
            Assert.Equal(expectWinner, result);
        }

        [Theory(DisplayName = "ส่งข้อมูล ระบบคำนวณเงินได้ถูกต้อง")]
        [InlineData(20, new int[] { 3, 5, 0 }, new string[] { "Club", "Diamond", "" }, new int[] { 5, 4, 0 }, new string[] { "Club", "Diamond", "" }, 20)]
        [InlineData(20, new int[] { 3, 5, 0 }, new string[] { "Club", "Club", "" }, new int[] { 5, 4, 0 }, new string[] { "Diamond", "Diamond", "" }, 40)]
        [InlineData(20, new int[] { 1, 5, 0 }, new string[] { "Club", "Club", "" }, new int[] { 1, 4, 3 }, new string[] { "Diamond", "Diamond", "Diamond" }, 60)]
        [InlineData(20, new int[] { 1, 5, 0 }, new string[] { "Club", "Club", "" }, new int[] { 3, 3, 3 }, new string[] { "Club", "Diamond", "Heart" }, 100)]
        [InlineData(20, new int[] { 4, 5, 0 }, new string[] { "Club", "Diamond", "" }, new int[] { 5, 3, 0 }, new string[] { "Club", "Diamond", "" }, -20)]
        [InlineData(20, new int[] { 4, 5, 0 }, new string[] { "Club", "Club", "" }, new int[] { 5, 3, 0 }, new string[] { "Diamond", "Diamond", "" }, -40)]
        [InlineData(20, new int[] { 1, 2, 3 }, new string[] { "Club", "Club", "Diamond" }, new int[] { 1, 4, 3 }, new string[] { "Diamond", "Diamond", "Club" }, -60)]
        [InlineData(20, new int[] { 11, 11, 11 }, new string[] { "Club", "Diamond", "Heart" }, new int[] { 3, 3, 0 }, new string[] { "Club", "Diamond", "" }, -100)]
        [InlineData(20, new int[] { 11, 11, 11 }, new string[] { "Club", "Diamond", "Heart" }, new int[] { 13, 13, 13 }, new string[] { "Club", "Diamond", "Heart" }, 0)]
        public void CheckGameResult(int betAmount, int[] p1CardNo, string[] p1CardSymbol, int[] p2CardNo, string[] p2CardSymbol, int expectResult)
        {
            var sut = new Pokdeng();
            var p1HandCards = new HandCards();
            var p2HandCards = new HandCards();
            p1HandCards.CardNo = p1CardNo;
            p2HandCards.CardNo = p2CardNo;
            p1HandCards.CardSymbol = p1CardSymbol;
            p2HandCards.CardSymbol = p2CardSymbol;
            var p1SuitCards = sut.CheckSuitCards(p1HandCards);
            var p2SuitCards = sut.CheckSuitCards(p2HandCards);
            var result = sut.ReturnResult(betAmount, p1SuitCards, p2SuitCards);
            Assert.Equal(expectResult, result);
        }

        [Theory(DisplayName = "แต้มผู้เล่นชนะเจ้ามือ ผู้เล่นได้รับเงินเพิ่มเท่ากับเงินที่ลงพนัน")]
        [InlineData(100, 1, 1, "Club", "Club", 1, 2, "Club", "Diamond", 1000, 1100)]
        [InlineData(100, 1, 1, "Club", "Club", 1, 3, "Club", "Diamond", 1000, 1100)]
        [InlineData(100, 1, 1, "Club", "Club", 1, 4, "Club", "Diamond", 1000, 1100)]
        public void PlayerWinThenGainX1FromBet(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "แต้มผู้เล่นแพ้เจ้ามือ ผู้เล่นเสียเงินเท่ากับเงินที่ลงพนัน")]
        [InlineData(100, 1, 2, "Club", "Diamond", 1, 1, "Club", "Club", 1000, 900)]
        [InlineData(100, 1, 3, "Club", "Diamond", 1, 1, "Club", "Club", 1000, 900)]
        [InlineData(100, 1, 4, "Club", "Diamond", 1, 1, "Club", "Club", 1000, 900)]
        public void PlayerLoseThenLoseX1FromBet(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "แต้มผู้เล่นเสมอกับเจ้ามือ ผู้เล่นไม่เสียเงิน")]
        [InlineData(100, 1, 2, "Club", "Club", 1, 2, "Club", "Club", 1000, 1000)]
        [InlineData(100, 1, 3, "Club", "Club", 1, 3, "Club", "Club", 1000, 1000)]
        [InlineData(100, 1, 4, "Club", "Club", 1, 4, "Club", "Club", 1000, 1000)]
        public void PlayerDrawThenDoNothing(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }
    }
}
