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
            int[] Player1CardNos = new int[] { p1CardNo1, p1CardNo2, p1CardNo3 };
            string[] Player1CardSymbol = new string[] { p1CardSymbol1, p1CardSymbol2, p1CardSymbol3 };
            int[] Player2CardNos = new int[] { p1CardNo1, p1CardNo2, p1CardNo3 };
            string[] Player2CardSymbol = new string[] { p1CardSymbol1, p1CardSymbol2, p1CardSymbol3 };
            Checkwin(betAmount, Player1CardNos, Player1CardSymbol, Player2CardNos, Player2CardSymbol, PlayerBalance);
        }

        public int Checkwin(int betAmount, int[] Player1CardNos, string[] Player1CardSymbol, int[] Player2CardNos, string[] Player2CardSymbol, int PlayerBalance)
        {
            int Balance = PlayerBalance;
            int Result = 0;
            int p1sum = 0;
            int p2sum = 0;

            if (PlayerBalance > 0 && betAmount > 0)
            {
                for (int i = 0; i <= 2; i++)
                {
                    if (Player1CardNos[i] > 9)
                    {
                        Player1CardNos[i] = 0;
                    }
                    else if (Player2CardNos[i] > 9)
                    {
                        Player2CardNos[i] = 0;
                    }
                }
                p1sum = Player1CardNos[0] + Player1CardNos[1] + Player1CardNos[2];
                p2sum = Player2CardNos[0] + Player2CardNos[1] + Player2CardNos[2];
                p1sum = p1sum % 10;
                p2sum = p2sum % 10;

                //ป๊อก 9 
                if (p1sum == 9 || p2sum == 9)
                {
                    //ป๊อก 9 2 เด้ง เจ้ามือชนะ
                    if (p1sum > p2sum && Player1CardNos[0] == Player1CardNos[1] && Player1CardNos[2] == 0 && Player1CardSymbol[2] == null || p1sum > p2sum && Player1CardSymbol[0] == Player1CardSymbol[1] && Player1CardSymbol[2] == null)
                    {
                        Result = (Balance - (betAmount * 2));
                    }
                    //ป๊อก 9 เจ้ามือชนะ
                    else if (p1sum == 9 && p1sum > p2sum)
                    {
                        Result = Balance - betAmount;
                    }
                    //ป๊อก 9 2 เด้ง ผู้เล่นชนะ
                    else if (p1sum < p2sum && Player2CardNos[0] == Player2CardNos[1] && Player2CardNos[2] == 0 && Player2CardSymbol[2] == null || p1sum < p2sum && Player2CardSymbol[0] == Player2CardSymbol[1] && Player2CardSymbol[2] == null)
                    {
                        Result = (Balance + (betAmount * 2));
                    }
                    //ป๊อก 9 ผู้เล่นชนะ
                    else if (p2sum == 9 && p1sum < p2sum)
                    {
                        Result = Balance + betAmount;
                    }
                }
                //ป๊อก 8
                if (p1sum == 8 && p1sum > p2sum)
                {
                    //ป๊อก 8 2 เด้ง เจ้ามือชนะ
                    if (p1sum > p2sum && Player1CardNos[0] == Player1CardNos[1] && Player1CardNos[2] == 0 && Player1CardSymbol[2] == null || p1sum > p2sum && Player1CardSymbol[0] == Player1CardSymbol[1] && Player1CardSymbol[2] == null)
                    {
                        Result = (Balance - (betAmount * 2));
                    }
                    //ป๊อก 8 เจ้ามือชนะ
                    else if (p1sum == 8 && p1sum > p2sum)
                    {
                        Result = Balance - betAmount;
                    }
                    //ป๊อก 8 2 เด้ง ผู้เล่นชนะ
                    else if (p1sum < p2sum && Player2CardNos[0] == Player2CardNos[1] && Player2CardNos[2] == 0 && Player2CardSymbol[2] == null || p1sum < p2sum && Player2CardSymbol[0] == Player2CardSymbol[1] && Player2CardSymbol[2] == null)
                    {
                        Result = (Balance + (betAmount * 2));
                    }
                    //ป๊อก 8 ผู้เล่นชนะ
                    else if (p2sum == 8 && p1sum < p2sum)
                    {
                        Result = Balance + betAmount;
                    }
                }
                //ธรรมดา เจ้ามือชนะ
                if (p1sum > p2sum)
                {
                    //ธรรมดา 2 เด้ง เจ้ามือชนะ
                    if (Player1CardNos[0] == Player1CardNos[1] && Player1CardNos[2] == 0 && Player1CardSymbol[2] == null || Player1CardSymbol[0] == Player1CardSymbol[1] && Player1CardSymbol[2] == null)
                    {
                        Result = (Balance - (betAmount * 2));
                    }
                    //ธรรมดา 3 เด้ง เจ้ามือชนะ
                    else if (Player1CardSymbol[0] == Player1CardSymbol[1] && Player1CardSymbol[0] == Player1CardSymbol[2] && Player1CardSymbol[1] == Player1CardSymbol[2])
                    {
                        Result = (Balance - (betAmount * 3));
                    }
                    //ธรรมดา เจ้ามือชนะ
                    else if (p1sum > p2sum)
                    {
                        Result = Balance - betAmount;
                    }
                }
                if (p1sum < p2sum)
                {
                    //ธรรมดา 2 เด้ง ผู้เล่นชนะ
                    if (Player2CardNos[0] == Player2CardNos[1] && Player2CardNos[2] == 0 || Player2CardSymbol[0] == Player2CardSymbol[1] && Player2CardSymbol[2] == null)
                    {
                        Result = (Balance + (betAmount * 2));
                    }
                    //ธรรมดา 3 เด้ง ผู้เล่นชนะ
                    else if (Player2CardSymbol[0] == Player2CardSymbol[1] && Player2CardSymbol[0] == Player2CardSymbol[2] && Player2CardSymbol[1] == Player2CardSymbol[2])
                    {
                        Result = (Balance + (betAmount * 3));
                    }
                    //ธรรมดา ผู้เล่นชนะ
                    else if (p1sum < p2sum)
                    {
                        Result = Balance + betAmount;
                    }
                }
                else if (p1sum == p2sum)
                {
                    Result = Balance;
                }
            }
            return Result;
        }
    }
}
