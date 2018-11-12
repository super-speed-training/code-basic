using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBasic
{
    public class Pokdeng
    {
        // PlayerBalance คือเงินของผู้เล่น
        public int PlayerBalance { get; set; }

        // Club, Diamond, Heart, Spade (case sensitive)
        public void CheckGameResult(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {

            // ถ้าป๊อกจะได้ไพ่สองใบ
            int SumTwoP1 = p1CardNo1 + p1CardNo2;
            int SumTwoP2 = p2CardNo1 + p2CardNo2;

            // ถ้าไม่ป๊อกจะได้ไพ่ สองหรือสามใบ
            int SumthreeP1 = p1CardNo1 + p1CardNo2 + p1CardNo3;
            int SumthreeP2 = p2CardNo1 + p2CardNo2 + p2CardNo3;

            // P1 ชนะจะได้เงินหนึ่งเท่าของที่ลง ในกรณีที่ได้ 9 หรือ 8
            var SumP1Pok = SumTwoP1 > SumTwoP2;
            // P2 ชนะจะได้เงินหนึ่งเท่าของที่ลง ในกรณีที่ได้ 9 หรือ 8
            var SumP2Pok = SumTwoP2 > SumTwoP1;

            //  P1 ชนะจะได้เงินหนึ่งเท่าของที่ลง ในกรณีที่ได้การ์ด 3 ใบ
            var SumP1Win = SumthreeP1 > SumthreeP2;
            // P2 ชนะจะได้เงินหนึ่งเท่าของที่ลง ในกรณีที่ SumthreeP2 > SumthreeP1
            var SumP2Win = SumthreeP2 > SumthreeP1;

            //ในกรณีที่ P1 ชนะ และได้เงินสองเท่า
            var SumTwoSymbolP1 = p1CardSymbol1 == p1CardSymbol2;
            var SumTwoCardP1 = p1CardNo1 == p1CardNo2;
            // ในกรณีที่ P2 ชนะ และได้เงินสองเท่า
            var SumTwoSymbolP2 = p2CardSymbol1 == p2CardSymbol2;
            var SumTwoCardP2 = p2CardNo1 == p2CardNo2;

            // ในกรณีที่ P1 ชนะ และได้เงินสามเท่า
            var SumThreeSymbolP1 = p1CardSymbol1 == p1CardSymbol2 && p1CardSymbol2 == p1CardSymbol3
            && SumthreeP1 > SumthreeP2;
            var SumThreeCardP1 = p1CardNo1 == p1CardNo2 && p1CardNo2 == p1CardNo3
            && SumthreeP1 > SumthreeP2;

            // ในกรณีที่ P2 ชนะ และได้เงินสามเท่า
            var SumThreeSymbolP2 = p2CardSymbol1 == p2CardSymbol2 && p2CardSymbol2 == p2CardSymbol3
            && SumthreeP1 < SumthreeP2;
            var SumThreeCardP2 = p1CardNo1 == p1CardNo2 && p1CardNo2 == p1CardNo3
            && SumthreeP1 < SumthreeP2;

            // เสมอ
            if (SumTwoP1 % 10 == SumTwoP2 % 10 || SumthreeP1 % 10 == SumthreeP2 % 10)
            {
               
            }
             // P2 pok *2
            else if (((SumTwoP2 % 10 > SumTwoP1 % 10 && SumTwoP2 == 8 || SumTwoP2 == 9) && SumTwoCardP2)
            || (SumTwoP2 % 10 > SumTwoP1 % 10 && SumTwoP2 == 8 || SumTwoP2 == 9) && SumTwoSymbolP2)

            {

                PlayerBalance += betAmount * 2;

            }
             // P1 pok *2
            else if (((SumTwoP1 % 10 > SumTwoP2 % 10 && SumTwoP1 == 8 || SumTwoP1 == 9) && SumTwoCardP1)
            || (SumTwoP1 % 10 > SumTwoP2 % 10 && SumTwoP1 == 8 || SumTwoP1 == 9) && SumTwoSymbolP1)

            {

                PlayerBalance -= betAmount * 2;

            }
            //P2 Win *1
            else if ((SumTwoP2 % 10 > SumTwoP1 % 10) && SumTwoP2 == 8 || SumTwoP2 == 9)
            {

                PlayerBalance += betAmount;

            }

            //P1 Win *1
            else if ((SumTwoP2 % 10 < SumTwoP1 % 10) && SumTwoP1 == 8 || SumTwoP1 == 9)
            {

                PlayerBalance -= betAmount;

            }

            //P2 Win *3
            else if ((SumthreeP1 % 10 < SumthreeP2 % 10) && SumThreeSymbolP2 || (SumthreeP2 % 10 > SumthreeP1 % 10) && SumThreeCardP2)
            {
                PlayerBalance += betAmount * 3;

            }
            //P1 Win *3
            else if ((SumthreeP1 % 10 > SumthreeP2 % 10) && SumThreeSymbolP1 || (SumthreeP2 % 10 < SumthreeP1 % 10) && SumThreeCardP1)
            {
                PlayerBalance -= betAmount * 3;

            }

            //P2 Win *2
            else if ((SumTwoP2 % 10 > SumTwoP1 % 10) && SumTwoSymbolP2 || (SumTwoP2 % 10 > SumTwoP1 % 10) && SumTwoCardP2)
            {
                PlayerBalance += betAmount * 2;

            }
            //P1 Win *2
            else if ((SumTwoP2 % 10 < SumTwoP1 % 10) && SumTwoSymbolP1 || (SumTwoP2 % 10 < SumTwoP1 % 10) && SumTwoCardP1)
            {
                PlayerBalance -= betAmount * 2;

            }

            //P2 Win *1
            else if (SumTwoP2 % 10 > SumTwoP1 % 10)
            {

                PlayerBalance += betAmount;

            }

            //P1 Win *1
            else if (SumTwoP1 % 10 > SumTwoP2 % 10)
            {
                PlayerBalance -= betAmount;

            }


        }
    }
}