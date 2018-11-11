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
            var Banker = CreateCards(p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3);
            var Player = CreateCards(p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
        }

        public Card[] CreateCards(
            int cardNo1,
            int cardNo2,
            int cardNo3,
            string cardSymbol1,
            string cardSymbol2,
            string cardSymbol3)
        {
            var card = new List<Card>();
            int[] Point = new int[] { cardNo1, cardNo2, cardNo3 };
            string[] Sym = new String[] { cardSymbol1, cardSymbol2, cardSymbol3 };

            for (int i = 0; i < Point.Length; i++)
            {
                if (Point[i] != 0 && Sym[i] != "")
                {
                    if (Sym[i] == "Club")
                    {
                        card.Add(new Card(Point[i], CardType.Club));
                    }
                    else if (Sym[i] == "Diamond")
                    {
                        card.Add(new Card(Point[i], CardType.Diamond));
                    }
                    else if (Sym[i] == "Heart")
                    {
                        card.Add(new Card(Point[i], CardType.Heart));
                    }
                    else
                    {
                        card.Add(new Card(Point[i], CardType.Spade));
                    }
                }
            }
            return card.ToArray();
        }

        public ScoreRank GetRank(Card[] Card)
        {
            if (Card.Length == 2)
            {
                if (Card[0].Point + Card[1].Point >= 8)
                {
                    return ScoreRank.Pok;
                }
                if(Card[0].Point == Card[1].Point || Card[0].CardType == Card[1].CardType){
                    return ScoreRank.Double;
                }
                return ScoreRank.Score;
            }
            else
            {
                if (Card[0].Point == Card[1].Point && Card[1].Point == Card[2].Point)
                {
                    return ScoreRank.Three;
                }
                if (Card[0].Point > 10 && Card[1].Point > 10 && Card[2].Point > 10)
                {
                    return ScoreRank.Ghost;
                }

                Card = Card.OrderBy(it =>it.Point).ToArray();
                if (Card[0].Point == Card[1].Point - 1 && Card[1].Point == Card[2].Point - 1)
                {
                    return ScoreRank.Sequence;
                }
                if(Card[0].CardType == Card[1].CardType && Card[1].CardType == Card[2].CardType){
                    return ScoreRank.Tripple;
                }
                return ScoreRank.Score;
            }
        }
    }
}
