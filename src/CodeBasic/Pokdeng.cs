using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBasic
{
    public class Pokdeng
    {
        public int PlayerBalance { get; set; }
        public class Symbol
        {
            public const string Club = "Club";
            public const string Diamond = "Diamond";
            public const string Heart = "Heart";
            public const string Spade = "Spade";
        }
        // Club, Diamond, Heart, Spade (case sensitive)
        public void CheckGameResult(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {

        }
        public int SumCard(int cardNo1, int cardNo2, int cardNo3)
        {
            if (cardNo1 >= 10)
            {
                cardNo1 = 0;
            }
            if (cardNo2 >= 10)
            {
                cardNo2 = 0;

            }
            if (cardNo3 >= 10)
            {
                cardNo3 = 0;

            }
            return (cardNo1 + cardNo2 + cardNo3) % 10;
        }
        //เช็คป็อก
        public bool IsPokCheck(int cardNo1, int cardNo2, int cardNo3)
        {
            var Card1 = cardNo1;
            var Card2 = cardNo2;
            var Card3 = cardNo3;
            if (Card1 >= 10)
            {
                Card1 = 0;
            }
            else if (Card2 >= 10)
            {
                Card2 = 0;
            }

            if ((Card1 + Card2 == 8 || Card1 + Card2 == 9) && Card3 == 0)
            {
                return true;
            }
            return false;
        }

        public bool IsTwoDengCheck(int cardNo1, int cardNo2, string cardNo1Symbol, string cardNo2Symbol)
        {
            if (cardNo1 == cardNo2 || cardNo1Symbol == cardNo2Symbol)
            {
                return true;
            }
            return false;
        }

        public bool IsThreeDengCheck(int cardNo1, int cardNo2, int cardNo3, string cardNo1Symbol, string cardNo2Symbol, string cardNo3Symbol)
        {
            if (cardNo1Symbol == cardNo2Symbol && cardNo2Symbol == cardNo3Symbol)
            {
                return true;
            }
            return false;
        }

        public bool IsGhostCheck(int cardNo1, int cardNo2, int cardNo3, string cardNo1Symbol, string cardNo2Symbol, string cardNo3Symbol)
        {
            if (cardNo1 > 10 && cardNo2 > 10 && cardNo3 > 10)
            {
                return true;
            }
            return false;
        }
    }
}
