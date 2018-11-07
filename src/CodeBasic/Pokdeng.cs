using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBasic
{
    public class Pokdeng
    {
        public int PlayerBalance { get; set; } = 1000;

        // Club, Diamond, Heart, Spade (case sensitive)
        public void CheckGameResult(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3, 
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            throw new NotImplementedException();
        }
        public int Check(int p1CardNo1, int p1CardNo2)
        {
            return 9;
        }

        public bool Check3card(int p1CardNo1, int p1CardNo2, int p1CardNo3)
        {
            var is3Cardwin = PlayerBalance = PlayerBalance * 5;
            return true;
         
            
        }
    }
}
