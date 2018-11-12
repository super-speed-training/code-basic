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
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3
            )

        {
            var PlayerPoint = p2CardNo1 + p2CardNo2 + p2CardNo3;
            var DealerPoint = p1CardNo1 + p1CardNo2 + p1CardNo3;

            var Player2Card = p2CardNo1 + p2CardNo2;
            var Dealer2Card = p1CardNo1 + p1CardNo2;



            // Check Player Win
            if (PlayerPoint > DealerPoint)
            {
                PlayerBalance += betAmount;
            }
            // Check Pok 8 and 9 after bet x 2
            else if (DealerPoint >= 8 && DealerPoint <= 9 || PlayerPoint >= 8 && PlayerPoint <= 9)
            {
                PlayerBalance += betAmount * 2;
            }
            //Check player Lose
            else if (PlayerPoint < DealerPoint)
            {
                PlayerBalance -= betAmount;
            }
            //Check Draw
            else if (PlayerPoint == DealerPoint)
            {
                //
            }
        }
    }
}
