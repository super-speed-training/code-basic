using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public void CheckGameResult(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3, 
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
         
        }
        //เช็คว่าเล่นได้ไหม
        public bool Playable(int betAmount)
        {
            if(betAmount > 0)
            {
                if (betAmount * 5 <= PlayerBalance)
                {
                    return true;
                }
            }
            return false;
        }
        //เช็คป็อก
        public bool IsPokdengCheck(int cardNo1,int cardNo2,int cardNo3)
        {
            var Card1 = IsCardZeroPoint(cardNo1);
            var Card2 = IsCardZeroPoint(cardNo2);
            var Card3 = IsCardZeroPoint(cardNo3);

            if((Card1 + Card2 == 8 || Card1 + Card2 == 9) && Card3 == 0)
            {
                return true;
            }
            return false;
        }

        //เช็คตอง
        public bool IsTongCheck(int cardNo1, int cardNo2, int cardNo3)
        {
            if (cardNo1 == cardNo2 && cardNo1 == cardNo3)
            {
                return true;
            }
            return false;
        }

        //เช็คผี
        public bool IsGhostCheck(int cardNo1, int cardNo2, int cardNo3)
        {
            if (cardNo1 > 10 && cardNo2 > 10 && cardNo3 > 10)
            {
                return true;
            }
            return false;
        }

        //เช็คเรียง
        public bool IsStraightCheck(int cardNo1, int cardNo2, int cardNo3)
        {
            List<int> cards = new List<int> { cardNo1, cardNo2, cardNo3 };
            cards = cards.OrderByDescending(it=>it).ToList();
            if (cards[0] - cards[1] == 1 && cards[1] - cards[2] == 1)
            {
                return true;
            }
            return false;
        }

        //เช็คสองเด้ง
        public bool IsTwoDengCheck(int cardNo1, int cardNo2, string cardNo1Symbol, string cardNo2Symbol)
        {           
            if (cardNo1 == cardNo2 || cardNo1Symbol == cardNo2Symbol)
            {
                return true;
            }
            return false;
        }

        //เช็คสามเด้ง
        public bool IsThreeDengCheck(string cardNo1Symbol, string cardNo2Symbol, string cardNo3Symbol)
        {
            if (cardNo1Symbol == cardNo2Symbol && cardNo1Symbol == cardNo3Symbol)
            {
                return true;
            }
            return false;
        }

        //เช็คว่าไพ่มีแต้มเป็นศูนย์ไหม
        public int IsCardZeroPoint(int card)
        {
            //return card >= 10 ?0:card;
            if(card >= 10)
            {
                return 0;
            }
            return card;
        }
    }
}
