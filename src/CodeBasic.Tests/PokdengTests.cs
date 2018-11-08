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
        };
    }
}
