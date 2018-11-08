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
            var p1HandCards = new HandCards();
            var p2HandCards = new HandCards();
            p1HandCards.CardNo = new int[] { p1CardNo1, p1CardNo2, p1CardNo3 };
            p2HandCards.CardNo = new int[] { p2CardNo1, p2CardNo2, p2CardNo3 };
            p1HandCards.CardSymbol = new string[] { p1CardSymbol1, p1CardSymbol2, p1CardSymbol3 };
            p2HandCards.CardSymbol = new string[] { p2CardSymbol1, p2CardSymbol2, p2CardSymbol3 };
            var p1SuitCards = CheckSuitCards(p1HandCards);
            var p2SuitCards = CheckSuitCards(p2HandCards);
            PlayerBalance += ReturnResult(betAmount, p1SuitCards, p2SuitCards);
        }
         
        public SuitCards CheckSuitCards(HandCards handCards)
        {
            var suitCards = new SuitCards();
            suitCards.Score = (handCards.CardNo.Where(it => it < 10).Sum()) % 10;
            suitCards.Multiplier = 1;
            // เรียงแต้ม
            handCards.CardNo = handCards.CardNo.OrderByDescending(it => it).ToArray();
            // ไพ่ 2 ใบ
            if (handCards.CardNo[2] == 0)
            {
                // ตรวจ 2 เด้ง
                if (handCards.CardSymbol[0] == handCards.CardSymbol[1] || handCards.CardNo[0] == handCards.CardNo[1])
                {
                    suitCards.Multiplier = 2;
                }

                // ป๊อก 9
                if (suitCards.Score == 9)
                {
                    suitCards.SuitCard = 1;
                }
                // ป๊อก 8
                else if (suitCards.Score == 8)
                {
                    suitCards.SuitCard = 2;
                }
                // ไพ่ธรรมดา
                else
                {
                    suitCards.SuitCard = 6;
                }
            }
            // ไพ่ 3 ใบ
            else
            {
                // ตรวจ 3 เด้ง
                if (handCards.CardSymbol.All(it => it == handCards.CardSymbol[0]))
                {
                    suitCards.Multiplier = 3;
                }

                // ตอง
                if (handCards.CardNo.All(it => it == handCards.CardNo[0]))
                {
                    suitCards.SuitCard = 3;
                    suitCards.Multiplier = 5;
                }
                // ผี
                else if (handCards.CardNo.All(it => it == 11 || it == 12 || it == 13))
                {
                    suitCards.SuitCard = 4;
                    suitCards.Multiplier = 3;
                }
                // เรียง
                else if (handCards.CardNo[0] - handCards.CardNo[1] == 1 && handCards.CardNo[1] - handCards.CardNo[2] == 1)
                {
                    suitCards.SuitCard = 5;
                    suitCards.Multiplier = 3;
                }
                // ไพ่ธรรมดา
                else
                {
                    suitCards.SuitCard = 6;
                }
            }
            
            return suitCards;
        }

        public string IsWinner(SuitCards p1SuitCards, SuitCards p2SuitCards)
        {
            if (p1SuitCards.SuitCard > p2SuitCards.SuitCard)
            {
                return "win";
            }
            else if (p1SuitCards.SuitCard == p2SuitCards.SuitCard)
            {
                if (p1SuitCards.SuitCard == 3 || p1SuitCards.SuitCard == 4 || p1SuitCards.SuitCard == 5)
                {
                    return "draw";
                }
                else
                {
                    if (p1SuitCards.Score < p2SuitCards.Score)
                    {
                        return "win";
                    }
                    else if (p1SuitCards.Score == p2SuitCards.Score)
                    {
                        return "draw";
                    }
                    else
                    {
                        return "lose";
                    }
                }
            }
            else
            {
                return "lose";
            }
        }

        public int ReturnResult(int betAmount, SuitCards p1SuitCards,SuitCards p2SuitCards)
        {
            var result = 0;
            if (IsWinner(p1SuitCards, p2SuitCards) == "win")
            {
                result += betAmount * p2SuitCards.Multiplier;
            }
            else if (IsWinner(p1SuitCards, p2SuitCards) == "lose")
            {
                result -= betAmount * p1SuitCards.Multiplier;
            }
            return result;
        }
    } 
}