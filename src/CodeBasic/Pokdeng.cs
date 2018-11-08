using System.Collections.Generic;
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
            if (Playable(betAmount))
            {
                var playerBalance = PlayerBalance;
                var IsPlayer1Pok = IsPokCheck(p1CardNo1, p1CardNo2, p1CardNo3);
                var IsPlayer2Pok = IsPokCheck(p2CardNo1, p2CardNo2, p2CardNo3);
                var IsPlayer1TwoDeng = IsTwoDengCheck(p1CardNo1, p1CardNo2, p1CardSymbol1, p1CardSymbol2);
                var IsPlayer2TwoDeng = IsTwoDengCheck(p2CardNo1, p2CardNo2, p2CardSymbol1, p2CardSymbol2);
                var IsPlayer1ThreeDeng = IsThreeDengCheck(p1CardSymbol1, p1CardSymbol2, p1CardSymbol3);
                var IsPlayer2ThreeDeng = IsThreeDengCheck(p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
                var IsPlayer1Tong = IsTongCheck(p1CardNo1, p1CardNo2, p1CardNo3);
                var IsPlayer2Tong = IsTongCheck(p2CardNo1, p2CardNo2, p2CardNo3);
                var IsPlayer1Ghost = IsGhostCheck(p1CardNo1, p1CardNo2, p1CardNo3);
                var IsPlayer2Ghost = IsGhostCheck(p2CardNo1, p2CardNo2, p2CardNo3);
                var IsPlayer1Straight = IsStraightCheck(p1CardNo1, p1CardNo2, p1CardNo3);
                var IsPlayer2Straight = IsStraightCheck(p2CardNo1, p2CardNo2, p2CardNo3);
                var Player1Point = CalculatePoint(p1CardNo1, p1CardNo2, p1CardNo3);
                var Player2point = CalculatePoint(p2CardNo1, p2CardNo2, p2CardNo3);

                //มีคนป็อกมั้ย
                if (IsPlayer1Pok || IsPlayer2Pok)
                {
                    if (Player1Point > Player2point)
                    {
                        if (IsPlayer1TwoDeng)
                        {
                            playerBalance -= betAmount * 2;
                        }
                        else
                        {
                            playerBalance -= betAmount;
                        }

                    }
                    else if (Player1Point < Player2point)
                    {
                        if (IsPlayer2TwoDeng)
                        {
                            playerBalance += betAmount * 2;
                        }
                        else
                        {
                            playerBalance += betAmount;
                        }
                    }
                }//มีคนตองไหม
                else if (IsPlayer1Tong || IsPlayer2Tong)
                {
                    if (IsPlayer1Tong != IsPlayer2Tong)
                    {
                        if (IsPlayer1Tong)
                        {
                            playerBalance -= betAmount * 5;
                        }
                        else
                        {
                            playerBalance += betAmount * 5;
                        }
                    }
                }//มีคนได้ผีไหม
                else if (IsPlayer1Ghost || IsPlayer2Ghost)
                {
                    if (IsPlayer1Ghost != IsPlayer2Ghost)
                    {
                        if (IsPlayer1Ghost)
                        {
                            if (IsPlayer1ThreeDeng)
                            {
                                playerBalance -= betAmount * 5;
                            }
                            else
                            {
                                playerBalance -= betAmount * 3;
                            }
                        }
                        else
                        {
                            if (IsPlayer2ThreeDeng)
                            {
                                playerBalance += betAmount * 5;
                            }
                            else
                            {
                                playerBalance += betAmount * 3;
                            }
                        }
                    }
                }//มีคนเรียงไหมเรียง
                else if (IsPlayer1Straight || IsPlayer2Straight)
                {
                    if (IsPlayer1Straight != IsPlayer2Straight)
                    {
                        if (IsPlayer1Straight)
                        {
                            if (IsPlayer1ThreeDeng)
                            {
                                playerBalance -= betAmount * 5;
                            }
                            else
                            {
                                playerBalance -= betAmount * 3;
                            }
                        }
                        else
                        {
                            if (IsPlayer2ThreeDeng)
                            {
                                playerBalance += betAmount * 5;
                            }
                            else
                            {
                                playerBalance += betAmount * 3;
                            }
                        }
                    }
                }
                else
                {
                    if (Player1Point > Player2point)
                    {
                        if (IsPlayer1ThreeDeng)
                        {
                            playerBalance -= betAmount * 3;
                        }
                        else
                        {
                            playerBalance -= betAmount;
                        }
                    }
                    else if(Player1Point < Player2point)
                    {
                        if (IsPlayer2ThreeDeng)
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
        //เช็คว่าเล่นได้ไหม
        public bool Playable(int betAmount)
        {
            if (betAmount > 0)
            {
                if (betAmount * 5 <= PlayerBalance)
                {
                    return true;
                }
            }
            return false;
        }
        //เช็คป็อก
        public bool IsPokCheck(int cardNo1, int cardNo2, int cardNo3)
        {
            var Card1 = IsCardZeroPoint(cardNo1);
            var Card2 = IsCardZeroPoint(cardNo2);
            var Card3 = IsCardZeroPoint(cardNo3);

            if ((Card1 + Card2 == 8 || Card1 + Card2 == 9) && Card3 == 0)
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
            cards = cards.OrderByDescending(it => it).ToList();
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
            if (card >= 10)
            {
                return 0;
            }
            return card;
        }

        //คำนวนแต้ม
        public int CalculatePoint(int cardNo1, int cardNo2, int cardNo3)
        {
            var Card1 = IsCardZeroPoint(cardNo1);
            var Card2 = IsCardZeroPoint(cardNo2);
            var Card3 = IsCardZeroPoint(cardNo3);
            return (Card1 + Card2 + Card3) % 10;
        }
    }
}
