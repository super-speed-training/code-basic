using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodeBasic
{
    public class Poker
    {
        public int PlayerBalance { get; set; }
        public int sumScoreP1, sumScoreP2;
        // Club, Diamond, Heart, Spade (case sensitive)
        public void CheckGameResult(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            var cardP1No = new List<int>(new int[] { p1CardNo1, p1CardNo2, p1CardNo3 });
            var cardP1Symbol = new List<string>(new string[] { p1CardSymbol1, p1CardSymbol2, p1CardSymbol3 });
            var cardP2No = new List<int>(new int[] { p2CardNo1, p2CardNo2, p2CardNo3 });
            var cardP2Symbol = new List<string>(new string[] { p2CardSymbol1, p2CardSymbol2, p2CardSymbol3 });

            if (playAble(PlayerBalance, betAmount))
            {
                CheckWin(cardP1No, cardP1Symbol, cardP2No, cardP2Symbol, betAmount);
            }
            else
            {
                // p1
                p1CardNo1 = 0;
                p1CardSymbol1 = "";
                p1CardNo2 = 0;
                p1CardSymbol2 = "";
                p1CardNo3 = 0;
                p1CardSymbol3 = "";
                //p2
                p2CardNo1 = 0;
                p2CardSymbol1 = "";
                p2CardNo2 = 0;
                p2CardSymbol2 = "";
                p2CardNo3 = 0;
                p2CardSymbol3 = "";
                // ไม่เล่น ตังค์เท่าเดิม
                PlayerBalance += 0;
            }
        }

        public int CheckWin(List<int> cardP1No, List<string> cardP1Symbol, List<int> cardP2No, List<string> cardP2Symbol, int betAmount)
        {
            sumScoreP1 = IsScore(cardP1No[0] + cardP1No[1] + cardP1No[2]);
            sumScoreP2 = IsScore(cardP2No[0] + cardP2No[1] + cardP2No[2]);
            // Pokdeng
            if (IsPokdeng(cardP1No) && IsPokdeng(cardP2No))
            {
                if (sumScoreP1 > sumScoreP2)
                {
                    if (IsCheck2Deng(cardP1No, cardP1Symbol))
                    {
                        PlayerBalance -= betAmount * 2;
                    }
                    else if (IsCheck3Deng(cardP1No, cardP1Symbol))
                    {
                        PlayerBalance -= betAmount * 3;
                    }
                    else
                    {
                        PlayerBalance -= betAmount;
                    }
                }
                else if (sumScoreP1 < sumScoreP2)
                {
                    if (IsCheck2Deng(cardP2No, cardP2Symbol))
                    {
                        PlayerBalance += betAmount * 2;
                    }
                    else if (IsCheck3Deng(cardP2No, cardP2Symbol))
                    {
                        PlayerBalance += betAmount * 3;
                    }
                    else
                    {
                        PlayerBalance += betAmount;
                    }
                }
                else
                {
                    PlayerBalance += 0;
                }
            }
            else if (IsPokdeng(cardP1No))
            {
                if (IsCheck2Deng(cardP1No, cardP1Symbol))
                {
                    PlayerBalance -= betAmount * 2;
                }
                else if (IsCheck3Deng(cardP1No, cardP1Symbol))
                {
                    PlayerBalance -= betAmount * 3;
                }
                else
                {
                    PlayerBalance -= betAmount;
                }
            }
            else if (IsPokdeng(cardP2No))
            {
                if (IsCheck2Deng(cardP2No, cardP2Symbol))
                {
                    PlayerBalance += betAmount * 2;
                }
                else if (IsCheck3Deng(cardP2No, cardP2Symbol))
                {
                    PlayerBalance += betAmount * 3;
                }
                else
                {
                    PlayerBalance += betAmount;
                }
            }
            // แต้มมากกว่า win
            else if (sumScoreP1 > sumScoreP2)
            {
                if (IsCheck2Deng(cardP1No, cardP1Symbol))
                {
                    PlayerBalance -= betAmount * 2;
                }
                else if (IsCheck3Deng(cardP1No, cardP1Symbol))
                {
                    PlayerBalance -= betAmount * 3;
                }
                else
                {
                    PlayerBalance -= betAmount;
                }
            }
            else if (sumScoreP1 < sumScoreP2)
            {
                if (IsCheck2Deng(cardP2No, cardP2Symbol))
                {
                    PlayerBalance += betAmount * 2;
                }
                else if (IsCheck3Deng(cardP2No, cardP2Symbol))
                {
                    PlayerBalance += betAmount * 3;
                }
                else
                {
                    PlayerBalance += betAmount;
                }
            }
            else
            {
                PlayerBalance += 0;
            }

            return PlayerBalance;
        }

        public bool IsCheck2Deng(List<int> cardNo, List<string> cardSymbol)
        {

            return (cardNo[0] == cardNo[1] || cardSymbol[0] == cardSymbol[1]) && cardNo[2] == 0 && cardSymbol[2] == "";
        }

        public bool IsCheck3Deng(List<int> cardNo, List<string> cardSymbol)
        {

            return cardSymbol[0] == cardSymbol[1] && cardSymbol[1] == cardSymbol[2];
        }

        public bool playAble(int playerBalance, int betAmount)
        {
            return playerBalance >= 5 * betAmount;
        }

        public bool IsPokdeng(List<int> cardPlayerNo)
        {
            return (cardPlayerNo[0] + cardPlayerNo[1] == 8 || cardPlayerNo[0] + cardPlayerNo[1] == 9) && cardPlayerNo[2] == 0;

        }
        public int IsScore(int sumScore)
        {
            if (sumScore >= 10)
            {
                sumScore = sumScore & 10;
                return sumScore;
            }
            return sumScore;
        }
    }
}
