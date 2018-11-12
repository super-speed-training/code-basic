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
        [Theory(DisplayName = "ผู้เล่นชนะเจ้ามือ ผู้เล่นได้เงินเท่าที่ลงเงิน")]
        [InlineData(100, 5, 2, 0, "Club", "Spade", "", 7, 2, 0, "Club", "Spade", "", 500, 600)]
        [InlineData(500, 3, 2, 0, "Club", "Spade", "", 5, 2, 0, "Club", "Spade", "", 1000, 1500)]
        public void CheckGameResultIsPlayerWin(int bet, int p1CN1, int p1CN2, int p1CN3, string p1CS1, string p1CS2, string p1CS3, int p2CN1, int p2CN2, int p2CN3, string p2CS1, string p2CS2, string p2CS3, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1CN1, p1CN2, p1CN3, p1CS1, p1CS2, p1CS3, p2CN1, p2CN2, p2CN3, p2CS1, p2CS2, p2CS3);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "ผู้เล่นแพ้เจ้ามือ ผู้เล่นเสียเงินที่ลงไป")]
        [InlineData(100, 7, 2, 0, "Club", "Spade", "", 5, 2, 0, "Club", "Spade", "", 500, 400)]
        public void CheckGameResultIsHostrWin(int bet, int p1CN1, int p1CN2, int p1CN3, string p1CS1, string p1CS2, string p1CS3, int p2CN1, int p2CN2, int p2CN3, string p2CS1, string p2CS2, string p2CS3, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1CN1, p1CN2, p1CN3, p1CS1, p1CS2, p1CS3, p2CN1, p2CN2, p2CN3, p2CS1, p2CS2, p2CS3);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "ผู้เล่นและเจ้ามือ เสมอกัน ทั้งสองฝ่ายไม่เสียอะไร")]
        [InlineData(100, 7, 2, 0, "Club", "Spade", "", 7, 2, 0, "Club", "Spade", "", 500, 500)]
        public void CheckGameResultIsDraw(int bet, int p1CN1, int p1CN2, int p1CN3, string p1CS1, string p1CS2, string p1CS3, int p2CN1, int p2CN2, int p2CN3, string p2CS1, string p2CS2, string p2CS3, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1CN1, p1CN2, p1CN3, p1CS1, p1CS2, p1CS3, p2CN1, p2CN2, p2CN3, p2CS1, p2CS2, p2CS3);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "ผู้เล่นได้เด้งและชนะเจ้ามือ ผู้เล่นได้เงินเพิ่ม2เท่าจากที่ลง")]
        [InlineData(100, 6, 2, 0, "Club", "Club", "", 7, 2, 0, "Club", "Club", "", 500, 700)]
        public void CheckGameResultIsPlayerHasDeng(int bet, int p1CN1, int p1CN2, int p1CN3, string p1CS1, string p1CS2, string p1CS3, int p2CN1, int p2CN2, int p2CN3, string p2CS1, string p2CS2, string p2CS3, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1CN1, p1CN2, p1CN3, p1CS1, p1CS2, p1CS3, p2CN1, p2CN2, p2CN3, p2CS1, p2CS2, p2CS3);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "เจ้ามือได้เด้ง เจ้ามือชนะ ผู้เล่นเสียเงินเพิ่ม2เท่าจากที่ลง")]
        [InlineData(200, 4, 4, 0, "Club", "Heart", "", 2, 3, 0, "Club", "Heart", "", 500, 100)]
        public void CheckGameResultIsHostHasDeng(int bet, int p1CN1, int p1CN2, int p1CN3, string p1CS1, string p1CS2, string p1CS3, int p2CN1, int p2CN2, int p2CN3, string p2CS1, string p2CS2, string p2CS3, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1CN1, p1CN2, p1CN3, p1CS1, p1CS2, p1CS3, p2CN1, p2CN2, p2CN3, p2CS1, p2CS2, p2CS3);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }
    }
}
