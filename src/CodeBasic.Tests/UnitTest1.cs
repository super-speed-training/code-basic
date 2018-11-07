using System;
using Xunit;

namespace CodeBasic.Tests
{
    public class UnitTest1
    {
        // Normal cases
        // Alternative cases
        // Exception cases

        [Fact(DisplayName = "ไพ่ในมือมี 2 ใบ และผลรวมคือ 8 หรือ 9 (ไพ่ป๊อกจะชนะไพ่ 3 ใบเสมอ)")]
        public void Test1()
        {
            var sut = new Pokdeng();
            var result = sut.Check(4,5);
            Assert.Equal(9,result);
        }


        [Fact(DisplayName = "ไพ่ในมือมี 3 ใบและเป็น เลขเดียวกัน ถ้าชนะจะได้เงิน 5 เท่า")]
        public void Same3CardwithWinGet5()
        {
            var sut = new Pokdeng();
            var result = sut.Check3card(3,3,3);
            Assert.True(result);
        }
    }
}

//ป๊อก - ไพ่ในมือมี 2 ใบ และผลรวมคือ 8 หรือ 9 (ไพ่ป๊อกจะชนะไพ่ 3 ใบเสมอ)
//ตอง - ไพ่ในมือมี 3 ใบและเป็น เลขเดียวกัน ถ้าชนะจะได้เงิน 5 เท่า
//ผี - ไพ่ในมือมี 3 ใบและเป็นไพ่ในกลุ่ม J, Q, K ถ้าชนะจะได้เงิน 3 เท่า
//เรียง - ไพ่ในมือมี 3 ใบและเป็น เลขเรียงกัน ถ้าชนะจะได้เงิน 3 เท่า(Q, K, A ไม่ถือว่าเรียง)
//สองเด้ง - ไพ่ในมือมี 2 ใบและเป็น ดอกเดียวกัน หรือ ตัวเลขเดียวกัน ถ้าชนะจะได้เงิน 2 เท่า
//สามเด้ง - ไพ่ในมือมี 3 ใบและเป็น ดอกเดียวกัน ถ้าชนะจะได้เงิน 3 เท่า
//สองเด้ง กับ สามเด้ง ความสำคัญเท่ากัน แต้มที่เยอะกว่าเป็นฝ่ายชนะ