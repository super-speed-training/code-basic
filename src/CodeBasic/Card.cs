using System;

namespace CodeBasic
{
    public class Card
    {
        public Card(int Number, CardType Type)
        {
            CardType = Type;
            Point = Number;
        }
        public CardType CardType{ get; set; }
        public int Point { get; set; }
    }

    public enum CardType { 
        Club,
        Diamond,
        Heart,
        Spade,
    }

    public enum ScoreRank{
        Pok,
        Three,
        Ghost,
        Sequence,
        Score,
        Double,
        Tripple,
    }
}
