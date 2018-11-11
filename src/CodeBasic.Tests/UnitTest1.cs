using System;
using Xunit;

namespace CodeBasic.Tests
{
    public class UnitTest1
    {
        // Normal Case
        //ผู้เล่นชนะ เจ้ามือ ผู้เล่นได้เงินเท่าที่ลงเงิน
        //ผู้เล่นแพ้เจ้ามือ ชนะ ผู้เล่นเสียเงินที่ลงไป
        //ผู้เล่นและเจ้ามือ เสมอกัน ทั้งสองฝ่ายไม่เสียอะไร
        // Alternative cases
        // Exception cases
        [Fact(DisplayName = "ผู้เล่นชนะ เจ้ามือ ผู้เล่นได้เงินเท่าที่ลงเงิน")]
        public void CheckGameResultIsPlayerWin()
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = 500;
            sut.CheckGameResult(100,5,2,0, "Club", "Club","",7,2,0, "Club", "Club","");
            Assert.Equal(600,sut.PlayerBalance);
        }
    }
}
