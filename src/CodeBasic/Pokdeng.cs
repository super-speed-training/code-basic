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
        // Club, Diamond, Heart, Spade (case sensitive)
        public void CheckGameResult(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            var playable = Playable(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3, p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            if (playable)
            {
                var playerBalance = PlayerBalance;
                var isP1Pok = IsPokCheck(p1CardNo1, p1CardNo2, p1CardNo3);
                var isP2Pok = IsPokCheck(p2CardNo1, p2CardNo2, p2CardNo3);
                var isP1TwoDeng = IsTwoDengCheck(p1CardNo1, p1CardNo2, p1CardSymbol1, p1CardSymbol2);
                var isP2TwoDeng = IsTwoDengCheck(p2CardNo1, p2CardNo2, p2CardSymbol1, p2CardSymbol2);
                var isP1ThreeDeng = IsThreeDengCheck(p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3);
                var isP2ThreeDeng = IsThreeDengCheck(p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
                var p1Point = SumCard(p1CardNo1, p1CardNo2, p1CardNo3);
                var p2Point = SumCard(p2CardNo1, p2CardNo2, p2CardNo3);

                if (isP1Pok || isP2Pok)
                {
                    if (p1Point > p2Point)
                    {
                        if (isP1TwoDeng)
                        {
                            playerBalance -= betAmount * 2;
                        }
                        else
                        {
                            playerBalance -= betAmount;
                        }
                    }
                    else if (p1Point < p2Point)
                    {
                        if (isP2TwoDeng)
                        {
                            playerBalance += betAmount * 2;
                        }
                        else
                        {
                            playerBalance += betAmount;
                        }

                    }

                }
                else
                {
                    if (p1Point > p2Point)
                    {
                        if (isP1ThreeDeng)
                        {
                            playerBalance -= betAmount * 3;
                        }
                        else
                        {
                            playerBalance -= betAmount;
                        }
                    }
                    else if (p1Point < p2Point)
                    {
                        if (isP2ThreeDeng)
                        {
                            playerBalance += betAmount * 3;
                        }
                        else
                        {
                            playerBalance += betAmount;
                        }
                    }

                }

                PlayerBalance = playerBalance;
            }

        }
        public bool Playable(int betAmount, int p1CardNo1, int p1CardNo2, int p1CardNo3, string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3, int p2CardNo1, int p2CardNo2, int p2CardNo3, string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            var BetAmountEnough = ((betAmount > 0) && (betAmount * 5 <= PlayerBalance));
            var IsRealCards = ((p1CardNo1 > 0 && p1CardNo1 <= 13) && (p1CardNo2 > 0 && p1CardNo2 <= 13) && (p1CardNo3 >= 0 && p1CardNo3 <= 13)) && ((p2CardNo1 > 0 && p2CardNo1 <= 13) && (p2CardNo2 > 0 && p2CardNo2 <= 13) && (p1CardNo3 >= 0 && p1CardNo3 <= 13));

            if (BetAmountEnough && IsRealCards)
            {
                if (betAmount * 5 <= PlayerBalance)
                {
                    return true;
                }
            }
            return false;
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

        public bool IsSortCheck(int cardNo1, int cardNo2, int cardNo3, string cardNo1Symbol, string cardNo2Symbol, string cardNo3Symbol)
        {
            int[] cardSort = { cardNo1, cardNo2, cardNo3 };
            cardSort = cardSort.OrderBy(x => x).ToArray();
            // 1 2 3 
            if (cardSort[0] == cardSort[1] - 1 && cardSort[1] == cardSort[2] - 1)
            {
                return true;
            }
            return false;
        }

        public bool IsTongCheck(int cardNo1, int cardNo2, int cardNo3, string cardNo1Symbol, string cardNo2Symbol, string cardNo3Symbol)
        {
            if (cardNo1 == cardNo2 && cardNo2 == cardNo3)
            {
                return true;
            }
            return false;
        }

    }
}
