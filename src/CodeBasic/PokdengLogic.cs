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
            var DealerPoint3 = p1CardNo1 + p1CardNo2 + p1CardNo3;
            var PlayerPoint3 = p2CardNo1 + p2CardNo2 + p2CardNo3;
            var DealerPoint3Card = DealerPoint3 % 10;
            var PlayerPoint3Card = PlayerPoint3 % 10;

            var DealerPoint2 = p1CardNo1 + p1CardNo2;
            var PlayerPoint2 = p2CardNo1 + p2CardNo2;
            var DealerPoint2Card = DealerPoint2 % 10;
            var PlayerPoint2Card = PlayerPoint2 % 10;

            var DealerSame2Symbol = p1CardSymbol1 == p1CardSymbol2;
            var PlayerSame2Symbol = p2CardSymbol1 == p2CardSymbol2;

            var DealerSame3Symbol = p1CardSymbol1 == p1CardSymbol2 && p1CardSymbol2 == p1CardSymbol3;
            var PlayerSame3Symbol = p2CardSymbol1 == p2CardSymbol2 && p2CardSymbol2 == p2CardSymbol3;

            var DealerSame2Card = p1CardNo1 == p1CardNo2;
            var PlayerSame2Card = p2CardNo1 == p2CardNo2;

            var DealerSame3Card = p1CardNo1 == p1CardNo2 && p1CardNo2 == p1CardNo3;
            var PlayerSame3Card = p2CardNo1 == p2CardNo2 && p2CardNo2 == p2CardNo3;


            //ผู้เล่น'เสมอ'เจ้ามือ
            var isgamedraw = DealerPoint3Card == PlayerPoint3Card;

            //ผู้เล่น'ชนะ'เจ้ามือ
            var isplayerwin = PlayerPoint3Card > DealerPoint3Card;

            //ผู้เล่น'แพ้'เจ้ามือ
            var isplayerlose = DealerPoint3Card > PlayerPoint3Card;

            if (isgamedraw) return;
            else if (isplayerwin && PlayerSame3Card) //3เด้ง-เลขเดียวกัน(เล่นจริงคือตอง)
            {
                PlayerBalance += (betAmount * 3);
            }
            else if (PlayerPoint2Card >= 8 && PlayerSame2Symbol || PlayerSame2Card) //ป๊อกเด้ง
            {
                PlayerBalance += (betAmount * 2);
            }
            else if (PlayerPoint2Card >= 8) //ป๊อก
            {
                PlayerBalance += betAmount;
            }
            else if (DealerPoint2Card >= 8 && DealerSame2Symbol || DealerSame2Card) //ป๊อกเด้ง
            {
                PlayerBalance -= (betAmount * 2);
            }
            else if (DealerPoint2Card >= 8 && PlayerPoint2Card <8
             || DealerPoint2Card >= 8 && PlayerPoint3 <=9 ) //ป๊อก)
            {
                PlayerBalance -= betAmount;
            }
            else if (isplayerwin && PlayerSame3Symbol)
            {
                PlayerBalance += (betAmount * 3);
            }
            else if (isplayerwin && PlayerSame2Symbol)
            {
                PlayerBalance += (betAmount * 2);
            }
            else if (isplayerwin && PlayerSame2Card)
            {
                PlayerBalance += (betAmount * 2);
            }
            else if (isplayerwin)
            {
                PlayerBalance += betAmount;
            }
            else if (isplayerlose && DealerSame3Symbol)
            {
                PlayerBalance -= (betAmount * 3);
            }
            else if (isplayerlose && DealerSame2Symbol)
            {
                PlayerBalance -= (betAmount * 2);
            }
            else if (isplayerlose && DealerSame2Card)
            {
                PlayerBalance -= (betAmount * 2);
            }
            else if (isplayerlose)
            {
                PlayerBalance -= betAmount;
            }



        }
    }
}
