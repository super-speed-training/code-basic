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

            var dealerPoints = p1CardNo1 + p1CardNo2 + p1CardNo3;
            var playerPoints = p2CardNo1 + p2CardNo2 + p2CardNo3;
            var isGameDraw = dealerPoints == playerPoints;
            var isPlayerTheWinner = playerPoints > dealerPoints;
            if (isGameDraw) return;

            if( ){

            }

            if (dealerPoints >= 8 && dealerPoints <= 9 || playerPoints >= 8 && playerPoints <= 9)
            {
                p2CardNo3 = 0;
                p1CardNo3 = 0;
                dealerPoints = p1CardNo1 + p1CardNo2;
                playerPoints = p2CardNo1 + p2CardNo2;

                if (isPlayerTheWinner)
                {
                    if (p2CardNo1 == p2CardNo2 || p2CardSymbol1 == p2CardSymbol2)
                    {
                        PlayerBalance += betAmount * 2;
                    }
                    else
                    {
                        PlayerBalance += betAmount;
                    }
                }
                else
                {
                    if (p1CardNo1 == p1CardNo2 || p1CardSymbol1 == p1CardSymbol2)
                    {
                        PlayerBalance -= betAmount * 2;
                    }
                    else
                    {
                        PlayerBalance -= betAmount;
                    }
                }

                // if (p1CardSymbol1 == p1CardSymbol2 || p2CardSymbol1 == p2CardSymbol2 ||
                //  p1CardNo1 == p1CardNo2 || p2CardNo1 == p2CardNo2)

                // {
                //     if (isPlayerTheWinner)
                //     {
                //         PlayerBalance += betAmount * 2;
                //     }
                //     else
                //     {
                //         PlayerBalance -= betAmount * 2;
                //     }
                // }
                // else
                // {
                //     if (isPlayerTheWinner)
                //     {
                //         PlayerBalance += betAmount;
                //     }
                //     else
                //     {
                //         PlayerBalance -= betAmount;
                //     }
                // }
            }
            else
            {
                if (p1CardSymbol1 == p1CardSymbol2 || p2CardSymbol1 == p2CardSymbol2 ||
                 p1CardNo1 == p1CardNo2 || p2CardNo1 == p2CardNo2)

                {
                    if (isPlayerTheWinner)
                    {
                        PlayerBalance += betAmount * 2;
                    }
                    else
                    {
                        PlayerBalance -= betAmount * 2;
                    }
                }
                else
                {
                    if (isPlayerTheWinner)
                    {
                        PlayerBalance += betAmount;
                    }
                    else
                    {
                        PlayerBalance -= betAmount;
                    }

                }


            }

        }
    }
}
