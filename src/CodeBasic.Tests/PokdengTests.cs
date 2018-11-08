using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace CodeBasic.Tests
{
    public class PokdengTests
    {
        [Theory]
        [MemberData(nameof(CardCreationCases))]
        public void Create3CardsCorrectly(int cardNo1, int cardNo2, int cardNo3,
                string cardSymbol1, string cardSymbol2, string cardSymbol3,
                Card[] expected)
        {
            var sut = new Pokdeng();
            var result = sut.CreateCards(cardNo1, cardNo2, cardNo3, cardSymbol1, cardSymbol2, cardSymbol3);

            result.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> CardCreationCases = new List<object[]>
        {
            new object [] {
                1, 2, 3,
                "Club", "Heart", "Spade",
                new Card[] { new Card(1, CardType.Club), new Card(2, CardType.Heart), new Card(3, CardType.Spade) },
            },
            new object [] {
                7, 4, 12,
                "Diamond", "Spade", "Heart",
                new Card[] { new Card(7, CardType.Diamond), new Card(4, CardType.Spade), new Card(12, CardType.Heart) },
            },
            new object [] {
                7, 4, 0,
                "Diamond", "Spade", "",
                new Card[] { new Card(7, CardType.Diamond), new Card(4, CardType.Spade) },
            },
        };

        [Theory]
        [MemberData(nameof(GetRankCases))]
        public void GetRankWorksCorrectly(Card[] cards, ScoreRank expected)
        {
            var result = Pokdeng.GetRank(cards);
            result.Should().Be(expected);
        }

        public static IEnumerable<object[]> GetRankCases = new List<object[]>
        {
            new object[] {
                new Card[] { new Card(4, CardType.Club), new Card(5, CardType.Diamond) },
                ScoreRank.Pok,
            },
            new object[] {
                new Card[] { new Card(4, CardType.Club), new Card(4, CardType.Heart) },
                ScoreRank.Pok,
            },
            new object[] {
                new Card[] { new Card(9, CardType.Club), new Card(9, CardType.Heart) },
                ScoreRank.Pok,
            },
            new object[] {
                new Card[] { new Card(9, CardType.Club), new Card(11, CardType.Heart) },
                ScoreRank.Pok,
            },
            new object[] {
                new Card[] { new Card(3, CardType.Club), new Card(3, CardType.Heart), new Card(3, CardType.Diamond) },
                ScoreRank.Three,
            },
            new object[] {
                new Card[] { new Card(2, CardType.Club), new Card(2, CardType.Heart), new Card(2, CardType.Diamond) },
                ScoreRank.Three,
            },
            new object[] {
                new Card[] { new Card(11, CardType.Club), new Card(12, CardType.Heart), new Card(13, CardType.Diamond) },
                ScoreRank.Ghost,
            },
            new object[] {
                new Card[] { new Card(1, CardType.Club), new Card(2, CardType.Heart), new Card(3, CardType.Diamond) },
                ScoreRank.Sequence,
            },
            new object[] {
                new Card[] { new Card(4, CardType.Club), new Card(5, CardType.Heart), new Card(6, CardType.Diamond) },
                ScoreRank.Sequence,
            },
            new object[] {
                new Card[] { new Card(9, CardType.Club), new Card(10, CardType.Heart), new Card(11, CardType.Diamond) },
                ScoreRank.Sequence,
            },
            new object[] {
                new Card[] { new Card(3, CardType.Heart), new Card(4, CardType.Heart), new Card(2, CardType.Heart) },
                ScoreRank.Sequence,
            },
            new object[] {
                new Card[] { new Card(1, CardType.Club), new Card(12, CardType.Heart), new Card(13, CardType.Diamond) },
                ScoreRank.Score,
            },
            new object[] {
                new Card[] { new Card(3, CardType.Club), new Card(3, CardType.Heart) },
                ScoreRank.Double,
            },
            new object[] {
                new Card[] { new Card(2, CardType.Club), new Card(3, CardType.Club) },
                ScoreRank.Double,
            },
            new object[] {
                new Card[] { new Card(1, CardType.Club), new Card(1, CardType.Heart), new Card(1, CardType.Diamond) },
                ScoreRank.Three,
            },
            new object[] {
                new Card[] { new Card(1, CardType.Heart), new Card(12, CardType.Heart), new Card(13, CardType.Heart) },
                ScoreRank.Tripple,
            },
            new object[] {
                new Card[] { new Card(10, CardType.Heart), new Card(2, CardType.Heart), new Card(3, CardType.Diamond) },
                ScoreRank.Score,
            },
        };

        [Theory]
        [InlineData(1,
            1, 2, 3,
            "Heart", "Heart", "Diamond",
            3, 4, 0,
            "Heart", "Diamond", "",
            -3)]
        [InlineData(1,
            5, 4, 0,
            "Heart", "Heart", "",
            3, 4, 0,
            "Heart", "Diamond", "",
            -2)]
        [InlineData(1,
            1, 2, 3,
            "Heart", "Heart", "Diamond",
            4, 4, 0,
            "Heart", "Diamond", "",
            2)]
        [InlineData(1,
            4, 2, 3,
            "Heart", "Heart", "Diamond",
            5, 4, 0,
            "Heart", "Heart", "",
            2)]
        [InlineData(1,
            4, 2, 3,
            "Heart", "Heart", "Diamond",
            5, 4, 0,
            "Heart", "Diamond", "",
            1)]
        [InlineData(1,
            2, 2, 2,
            "Heart", "Spade", "Diamond",
            3, 4, 0,
            "Heart", "Diamond", "",
            -5)]
        [InlineData(1,
            11, 12, 13,
            "Heart", "Heart", "Diamond",
            3, 4, 0,
            "Heart", "Diamond", "",
            -3)]
        [InlineData(1,
            1, 2, 3,
            "Heart", "Heart", "Diamond",
            3, 4, 5,
            "Heart", "Diamond", "Spade",
            0)]
        [InlineData(1,
            5, 2, 3,
            "Heart", "Heart", "Heart",
            3, 4, 0,
            "Diamond", "Diamond", "",
            2)]
        [InlineData(1,
            10, 2, 3,
            "Heart", "Heart", "Diamond",
            3, 4, 2,
            "Heart", "Heart", "Heart",
            3)]
        public void CheckGameResultUpdateBalanceCorrectly(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3,
            int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.CheckGameResult(betAmount,
                p1CardNo1, p1CardNo2, p1CardNo3,
                p1CardSymbol1, p1CardSymbol2, p1CardSymbol3,
                p2CardNo1, p2CardNo2, p2CardNo3,
                p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);

            sut.PlayerBalance.Should().Be(expectedBalance);
        }
    }
}
