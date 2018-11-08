using System;
using System.Collections.Generic;
using System.Text;

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
            return new Card[] {
                new Card(cardNo1, (CardType)Enum.Parse(typeof(CardType), cardSymbol1)),
                new Card(cardNo2, (CardType)Enum.Parse(typeof(CardType), cardSymbol2)),
                new Card(cardNo3, (CardType)Enum.Parse(typeof(CardType), cardSymbol3)),
            };            
        }

        public ScoreRank GetRank(Card[] cards)
        {
            throw new NotImplementedException();
        }
    }
}
