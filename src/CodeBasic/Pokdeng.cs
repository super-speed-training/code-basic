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
            throw new NotImplementedException();
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

        public ScoreRank GetRank(Card[] cards)
        {
            // Check for Pok first
            var sumScore = cards.Where(it => it.Number <= 10).Sum(it => it.Number) % 10;
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
                else {
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

                    if (allMatched)
                    {
                        return ScoreRank.Sequence;
                    }
                }

                if (cards.Select(it => it.CardType).Distinct().Count() == 1)
                {
                    return ScoreRank.Tripple;
                }
            }
            else if (cards.Select(it => it.Number).Distinct().Count() == 1
                || cards.Select(it => it.CardType).Distinct().Count() == 1)
            {
                return ScoreRank.Double;
            }

            return ScoreRank.Score;
        }
    }
}
