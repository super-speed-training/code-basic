using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBasic
{
    public class Pokdeng
    {
        public int PlayerBalance { get; set; }
        

        // Club, Diamond, Heart, Spade (case sensitive)
        public int CheckGameResult(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            int SumCardP1 = p1CardNo1+p1CardNo2;
            int SumCardP2 = p2CardNo1+p2CardNo2;

            if(SumCardP1 == 8 || SumCardP1 == 9 && SumCardP1 > SumCardP2)
            {
                return PlayerBalance+betAmount;
            }
           return 0;
        }
    }
}