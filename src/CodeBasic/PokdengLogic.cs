using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBasic
{
    public class PokdengLogic
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
            var DealerPoint = p1CardNo1 + p1CardNo2 + p1CardNo3;
            var PlayerPoint = p2CardNo1 + p2CardNo2 + p2CardNo3;

            var isgamedraw = DealerPoint == PlayerPoint;
            if (isgamedraw) return;

            var playerwin = PlayerPoint > DealerPoint;
            if (playerwin)
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
