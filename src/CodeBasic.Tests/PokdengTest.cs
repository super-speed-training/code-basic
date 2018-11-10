using Xunit;
using static CodeBasic.Pokdeng;

namespace CodeBasic.Tests
{
    public class PokdengTest
    {
        // Normal cases

        [Theory(DisplayName = "เช็คว่าป็อกหรือไม่")]
        [InlineData(4, 4, 0, true)]
        [InlineData(10, 9, 0, true)]
        [InlineData(8, 1, 0, true)]
        [InlineData(3, 7, 5, false)]
        [InlineData(3, 3, 11, false)]
        public void CheckPokgTest(int cardNo1, int cardNo2, int cardNo3, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsPokCheck(cardNo1, cardNo2, cardNo3);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "เช็คว่าตองหรือไม่")]
        [InlineData(4, 4, 0, false)]
        [InlineData(3, 3, 3, true)]
        [InlineData(11, 11, 11, true)]
        [InlineData(5, 6, 7, false)]
        public void CheckTongTest(int cardNo1, int cardNo2, int cardNo3, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsTongCheck(cardNo1, cardNo2, cardNo3);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "เช็คว่าผีหรือไม่")]
        [InlineData(11, 11, 11, true)]
        [InlineData(10, 11, 9, false)]
        [InlineData(1, 2, 11, false)]
        [InlineData(11, 12, 12, true)]
        [InlineData(13, 12, 11, true)]
        public void CheckGhostTest(int cardNo1, int cardNo2, int cardNo3, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsGhostCheck(cardNo1, cardNo2, cardNo3);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "เช็คว่าเรียงหรือไม่")]
        [InlineData(1, 2, 3, true)]
        [InlineData(5, 7, 6, true)]
        [InlineData(11, 12, 13, true)]
        [InlineData(1, 2, 4, false)]
        [InlineData(12, 13, 1, false)]
        [InlineData(1, 12, 7, false)]
        public void CheckStraightTest(int cardNo1, int cardNo2, int cardNo3, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsStraightCheck(cardNo1, cardNo2, cardNo3);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "เช็คคำนวนแต้ม")]
        [InlineData(1, 2, 3, 6)]
        [InlineData(10, 7, 10, 7)]
        [InlineData(11, 4, 3, 7)]
        [InlineData(1, 5, 11, 6)]
        [InlineData(11, 12, 1, 1)]
        [InlineData(8, 1, 1, 0)]
        [InlineData(1, 2, 9, 2)]
        public void CheckCalculatePointTest(int cardNo1, int cardNo2, int cardNo3, int expected)
        {
            var sut = new Pokdeng();
            var result = sut.CalculatePoint(cardNo1, cardNo2, cardNo3);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "เช็คว่าสองเด้งหรือไม่")]
        [InlineData(4, 4, Symbol.Club, Symbol.Heart, true)]
        [InlineData(3, 3, Symbol.Club, Symbol.Heart, true)]
        [InlineData(10, 9, Symbol.Heart, Symbol.Heart, true)]
        [InlineData(1, 3, Symbol.Spade, Symbol.Spade, true)]
        [InlineData(5, 4, Symbol.Heart, Symbol.Heart, true)]
        public void CheckTwoDengTest(int cardNo1, int cardNo2, string cardNo1Symbol, string cardNo2Symbol, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsTwoDengCheck(cardNo1, cardNo2, cardNo1Symbol, cardNo2Symbol);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "เช็คว่าสามเด้งหรือไม่")]
        [InlineData(Symbol.Heart, Symbol.Heart, Symbol.Heart, true)]
        [InlineData(Symbol.Club, Symbol.Club, Symbol.Club, true)]
        [InlineData(Symbol.Club, Symbol.Heart, Symbol.Heart, false)]
        public void CheckThreeDengTest(string cardNo1Symbol, string cardNo2Symbol, string cardNo3Symbol, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsThreeDengCheck(cardNo1Symbol, cardNo2Symbol, cardNo3Symbol);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "คำนวนเงินเมื่อเจ้ามือหรือผู้เล่นป็อกหรือป็อกเด้ง")]
        [InlineData(10, 11, 9, 0, Symbol.Heart, Symbol.Club, "", 13, 8, 0, Symbol.Heart, Symbol.Heart, "", 190)]
        [InlineData(10, 11, 9, 0, Symbol.Heart, Symbol.Heart, "", 13, 8, 0, Symbol.Heart, Symbol.Heart, "", 180)]
        [InlineData(10, 8, 8, 0, Symbol.Heart, Symbol.Club, "", 10, 9, 0, Symbol.Heart, Symbol.Heart, "", 220)]
        [InlineData(10, 8, 8, 0, Symbol.Heart, Symbol.Club, "", 10, 9, 0, Symbol.Heart, Symbol.Club, "", 210)]
        [InlineData(10, 10, 9, 0, Symbol.Heart, Symbol.Club, "", 9, 10, 0, Symbol.Heart, Symbol.Heart, "", 200)]
        [InlineData(10, 10, 9, 0, Symbol.Heart, Symbol.Club, "", 4, 4, 4, Symbol.Heart, Symbol.Heart, Symbol.Diamond, 190)]
        public void Player1OrPlayer2Pokdeng(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3,
            int remainBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = 200;
            sut.CheckGameResult(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3, p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            Assert.Equal(sut.PlayerBalance, remainBalance);
        }

        [Theory(DisplayName = "คำนวนเงินเมื่อเจ้ามือหรือผู้เล่นได้ตอง")]
        [InlineData(10, 4, 4, 4, Symbol.Heart, Symbol.Club, Symbol.Spade, 2, 9, 3, Symbol.Heart, Symbol.Heart, Symbol.Heart, 150)]
        [InlineData(10, 4, 4, 4, Symbol.Heart, Symbol.Club, Symbol.Spade, 3, 3, 3, Symbol.Heart, Symbol.Heart, Symbol.Heart, 200)]
        [InlineData(10, 5, 4, 4, Symbol.Heart, Symbol.Club, Symbol.Spade, 11, 11, 11, Symbol.Heart, Symbol.Heart, Symbol.Heart, 250)]
        public void Player1OrPlayer2Tong(
        int betAmount,
        int p1CardNo1, int p1CardNo2, int p1CardNo3,
        string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
        int p2CardNo1, int p2CardNo2, int p2CardNo3,
        string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3,
        int remainBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = 200;
            sut.CheckGameResult(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3, p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            Assert.Equal(sut.PlayerBalance, remainBalance);
        }

        [Theory(DisplayName = "คำนวนเงินเมื่อเจ้ามือหรือผู้เล่นได้ผี")]
        [InlineData(10, 11, 12, 13, Symbol.Heart, Symbol.Club, Symbol.Spade, 2, 9, 3, Symbol.Heart, Symbol.Heart, Symbol.Heart, 170)]
        [InlineData(10, 11, 12, 13, Symbol.Heart, Symbol.Heart, Symbol.Heart, 2, 9, 3, Symbol.Heart, Symbol.Heart, Symbol.Heart, 150)]
        [InlineData(10, 10, 10, 1, Symbol.Heart, Symbol.Heart, Symbol.Heart, 11, 13, 13, Symbol.Heart, Symbol.Heart, Symbol.Spade, 230)]
        [InlineData(10, 1, 3, 1, Symbol.Spade, Symbol.Spade, Symbol.Spade, 11, 12, 13, Symbol.Heart, Symbol.Heart, Symbol.Heart, 250)]
        [InlineData(10, 11, 12, 13, Symbol.Spade, Symbol.Spade, Symbol.Spade, 11, 12, 13, Symbol.Heart, Symbol.Heart, Symbol.Heart, 200)]
        [InlineData(10, 11, 12, 13, Symbol.Spade, Symbol.Spade, Symbol.Spade, 13, 12, 13, Symbol.Spade, Symbol.Heart, Symbol.Heart, 200)]
        public void Player1OrPlayer2Ghost(
        int betAmount,
        int p1CardNo1, int p1CardNo2, int p1CardNo3,
        string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
        int p2CardNo1, int p2CardNo2, int p2CardNo3,
        string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3,
        int remainBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = 200;
            sut.CheckGameResult(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3, p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            Assert.Equal(sut.PlayerBalance, remainBalance);
        }

        [Theory(DisplayName = "คำนวนเงินเมื่อเจ้ามือหรือผู้เล่นได้เรียง")]
        [InlineData(10, 1, 2, 3, Symbol.Heart, Symbol.Club, Symbol.Spade, 2, 9, 3, Symbol.Heart, Symbol.Heart, Symbol.Heart, 170)]
        [InlineData(10, 5, 2, 3, Symbol.Heart, Symbol.Club, Symbol.Spade, 5, 6, 7, Symbol.Heart, Symbol.Heart, Symbol.Spade, 230)]
        [InlineData(10, 5, 2, 3, Symbol.Heart, Symbol.Club, Symbol.Spade, 5, 6, 7, Symbol.Heart, Symbol.Heart, Symbol.Heart, 250)]
        [InlineData(10, 1, 2, 3, Symbol.Heart, Symbol.Club, Symbol.Spade, 5, 6, 7, Symbol.Heart, Symbol.Heart, Symbol.Heart, 200)]
        public void Player1OrPlayer2Straight(
        int betAmount,
        int p1CardNo1, int p1CardNo2, int p1CardNo3,
        string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
        int p2CardNo1, int p2CardNo2, int p2CardNo3,
        string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3,
        int remainBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = 200;
            sut.CheckGameResult(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3, p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            Assert.Equal(sut.PlayerBalance, remainBalance);
        }

        [Theory(DisplayName = "คำนวนเงินจากการนับแต้ม")]
        [InlineData(10, 5, 5, 9, Symbol.Heart, Symbol.Club, Symbol.Spade, 2, 9, 3, Symbol.Heart, Symbol.Club, Symbol.Heart, 190)]
        [InlineData(10, 4, 6, 9, Symbol.Club, Symbol.Club, Symbol.Club, 2, 9, 3, Symbol.Club, Symbol.Heart, Symbol.Heart, 170)]
        [InlineData(10, 4, 6, 9, Symbol.Club, Symbol.Club, Symbol.Club, 10, 10, 9, Symbol.Club, Symbol.Heart, Symbol.Heart, 200)]
        [InlineData(10, 4, 6, 7, Symbol.Club, Symbol.Club, Symbol.Club, 1, 9, 8, Symbol.Club, Symbol.Heart, Symbol.Heart, 210)]
        [InlineData(10, 4, 6, 7, Symbol.Club, Symbol.Heart, Symbol.Club, 1, 9, 8, Symbol.Spade, Symbol.Spade, Symbol.Spade, 230)]
        public void Player1PointAndPlayer2Point(
        int betAmount,
        int p1CardNo1, int p1CardNo2, int p1CardNo3,
        string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
        int p2CardNo1, int p2CardNo2, int p2CardNo3,
        string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3,
        int remainBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = 200;
            sut.CheckGameResult(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3, p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            Assert.Equal(sut.PlayerBalance, remainBalance);
        }

        //Exeption Case
        [Theory(DisplayName = "ตรวจสอบไพ่ว่าตัวเลขหรือสัญลักษณ์ถูกต้องหรือไม่")]
        [InlineData(10, 14, 5, 9, Symbol.Heart, Symbol.Club, Symbol.Spade, 2, 9, 3, Symbol.Heart, Symbol.Club, Symbol.Heart, 200)]
        [InlineData(10, 1, 5, -1, Symbol.Heart, Symbol.Club, Symbol.Spade, 2, 9, 3, Symbol.Heart, Symbol.Club, Symbol.Heart, 200)]
        [InlineData(10, 1, 2, 3, Symbol.Heart, Symbol.Club, Symbol.Spade, 1, 2, 4, Symbol.Heart, Symbol.Club, Symbol.Spade, 200)]
        public void WrongInputTest(
        int betAmount,
        int p1CardNo1, int p1CardNo2, int p1CardNo3,
        string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
        int p2CardNo1, int p2CardNo2, int p2CardNo3,
        string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3,
        int remainBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = 200;
            sut.CheckGameResult(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3, p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            Assert.Equal(sut.PlayerBalance, remainBalance);
        }
        //เหลือไพ่ซ้ำ เช่น 4 Heart & 4 Heart

    }
}
