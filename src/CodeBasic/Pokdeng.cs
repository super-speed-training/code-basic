using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodeBasic
{
    public class Pokdeng
    {
        public int PlayerBalance { get; set; }

        // Club, Diamond, Heart, Spade (case sensitive)
        public void CheckGameResult(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            var p1Cards = CreateCards(p1CardNo1, p1CardNo2, p1CardNo3,
                p1CardSymbol1, p1CardSymbol2, p1CardSymbol3);
            var p2Cards = CreateCards(p2CardNo1, p2CardNo2, p2CardNo3,
                p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);

            var p1Rank = GetRank(p1Cards);
            var p2Rank = GetRank(p2Cards);

            if (p1Rank != p2Rank)
            {
                if (IsDoubleOrTrippleRank(p1Rank) && IsDoubleOrTrippleRank(p2Rank))
                {
                    UpdateBalanceByComparingScore(betAmount, p1Cards, p2Cards);
                }
                else if (p1Rank > p2Rank)
                {
                    PlayerBalance -= betAmount * YieldFactor(p1Cards);
                }
                else // p1Rank < p2Rank
                {
                    PlayerBalance += betAmount * YieldFactor(p1Cards);
                }
            }
            else
            {
                if (true != DrawIfSameRank(p1Rank))
                {
                    UpdateBalanceByComparingScore(betAmount, p1Cards, p2Cards);
                }
            }
        }

        private void UpdateBalanceByComparingScore(int betAmount, Card[] p1Cards, Card[] p2Cards)
        {
            var p1Score = SumScore(p1Cards);
            var p2Score = SumScore(p2Cards);

            if (p1Score > p2Score)
            {
                PlayerBalance -= betAmount * YieldFactor(p1Cards);
            }
            else if (p1Score < p2Score)
            {
                PlayerBalance += betAmount * YieldFactor(p2Cards);
            }
        }

        public Card[] CreateCards(int cardNo1, int cardNo2, int cardNo3,
                string cardSymbol1, string cardSymbol2, string cardSymbol3)
        {
            if (cardNo3 == 0)
            {
                return new Card[] {
                    new Card(cardNo1, (CardType)Enum.Parse(typeof(CardType), cardSymbol1)),
                    new Card(cardNo2, (CardType)Enum.Parse(typeof(CardType), cardSymbol2)),
                };
            }
            return new Card[] {
                new Card(cardNo1, (CardType)Enum.Parse(typeof(CardType), cardSymbol1)),
                new Card(cardNo2, (CardType)Enum.Parse(typeof(CardType), cardSymbol2)),
                new Card(cardNo3, (CardType)Enum.Parse(typeof(CardType), cardSymbol3)),
            };
        }

        public static ScoreRank GetRank(Card[] cards)
        {
            int sumScore = SumScore(cards);
            var cardCount = cards.Length;

            if (sumScore >= 8 && cardCount == 2)
            {
                return ScoreRank.Pok;
            }
            else if (cardCount == 3)
            {
                if (cards.Select(it => it.Number).Distinct().Count() == 1)
                {
                    return ScoreRank.Three;
                }
                else if (cards.All(it => it.Number > 10))
                {
                    return ScoreRank.Ghost;
                }
                else if (IsSequenceCards(cards))
                {
                    return ScoreRank.Sequence;
                }
                else if (cards.Select(it => it.CardType).Distinct().Count() == 1)
                {
                    return ScoreRank.Tripple;
                }
            }
            else if (IsDoubleCards(cards))
            {
                return ScoreRank.Double;
            }

            return ScoreRank.Score;
        }

        private static int SumScore(Card[] cards)
        {
            return cards.Where(it => it.Number <= 10).Sum(it => it.Number) % 10;
        }

        private static bool IsSequenceCards(Card[] cards)
        {
            var orderedCardNos = cards.Select(it => it.Number).OrderBy(it => it);
            var minNo = orderedCardNos.First();
            var allMatched = true;

            foreach (var cardNo in orderedCardNos)
            {
                if (cardNo != minNo)
                {
                    allMatched = false;
                    break;
                }
                ++minNo;
            }

            return allMatched;
        }

        private static bool IsDoubleCards(Card[] cards)
        {
            return cards.Length == 2 && (
                cards.Select(it => it.Number).Distinct().Count() == 1
                || cards.Select(it => it.CardType).Distinct().Count() == 1
            );
        }

        private static bool IsDoubleOrTrippleRank(ScoreRank rank) {
            return rank == ScoreRank.Double
                || rank == ScoreRank.Tripple;
        }

        private static bool DrawIfSameRank(ScoreRank rank)
        {
            return rank == ScoreRank.Three
                || rank == ScoreRank.Ghost
                || rank == ScoreRank.Sequence;
        }

        private static int YieldFactor(Card[] cards)
        {
            ScoreRank rank = GetRank(cards);

            switch (rank)
            {
                case ScoreRank.Pok:
                    return (cards[0].Number == cards[1].Number || cards[0].CardType == cards[1].CardType)
                        ? 2 : 1;
                case ScoreRank.Three:
                    return 5;
                case ScoreRank.Ghost:
                case ScoreRank.Sequence:
                case ScoreRank.Tripple:
                    return 3;
                case ScoreRank.Double:
                    return 2;
                default:
                    return 1;
            }
        }
    }
}
