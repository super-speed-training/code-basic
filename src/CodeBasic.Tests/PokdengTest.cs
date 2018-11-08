using System;
using Xunit;
using static CodeBasic.Pokdeng;

namespace CodeBasic.Tests
{
    public class PokdengTest
    {
        // Normal cases
        // Alternative cases
        // Exception cases

        [Theory(DisplayName ="เช็คว่าเล่นได้หรือไม่")]
        [InlineData(50,10,true)]
        [InlineData(200, 10, true)]
        [InlineData(0, 10, false)]
        [InlineData(200, 0, false)]
        [InlineData(200, 60, false)]
        public void PlayableTest(int playerBalance,int betAmount,bool expected)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = playerBalance;
            var result = sut.Playable(betAmount);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "เช็คว่าป็อกหรือไม่")]
        [InlineData(4, 4, 0, true)]
        [InlineData(10, 9, 0, true)]
        [InlineData(8, 1, 0, true)]
        [InlineData(3, 7, 5, false)]
        [InlineData(3, 3, 11, false)]
        public void CheckPokgTest(int cardNo1, int cardNo2,int cardNo3, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsPokdengCheck(cardNo1,cardNo2,cardNo3);
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

        [Theory(DisplayName = "เช็คว่าสองเด้งหรือไม่")]
        [InlineData(4, 4, Symbol.Club, Symbol.Heart, true)]
        [InlineData(3, 3, Symbol.Club, Symbol.Heart, true)]
        [InlineData(10, 9, Symbol.Heart, Symbol.Heart, true)]
        [InlineData(1, 3, Symbol.Spade, Symbol.Spade, true)]
        [InlineData(5, 4, Symbol.Heart, Symbol.Heart, true)]
        public void CheckTwoDengTest(int cardNo1, int cardNo2,string cardNo1Symbol,string cardNo2Symbol, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsTwoDengCheck(cardNo1, cardNo2,cardNo1Symbol,cardNo2Symbol);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "เช็คว่าสามเด้งหรือไม่")]
        [InlineData(Symbol.Heart, Symbol.Heart, Symbol.Heart, true)]
        [InlineData(Symbol.Club, Symbol.Club, Symbol.Club, true)]
        [InlineData(Symbol.Club, Symbol.Heart, Symbol.Heart, false)]
        public void CheckThreeDengTest(string cardNo1Symbol, string cardNo2Symbol, string cardNo3Symbol, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsThreeDengCheck(cardNo1Symbol, cardNo2Symbol,cardNo3Symbol);
            Assert.Equal(expected, result);
        }


        //[Theory]
        //[InlineData(10,
        //    4, 9, 0,
        //    "Heart", "Spade", "",
        //    3, 3, 4,
        //    "Heart", "Heart", "Spade",
        //    190)]
        //public void Player1WinPlayer2ByPokdeng(
        //    int betAmount,
        //    int p1CardNo1, int p1CardNo2, int p1CardNo3,
        //    string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
        //    int p2CardNo1, int p2CardNo2, int p2CardNo3,
        //    string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3,
        //    int remainBalance)
        //{
        //    var sut = new Pokdeng();
        //    sut.PlayerBalance = 200;
        //    sut.CheckGameResult(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3, p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
        //    Assert.Equal(sut.PlayerBalance, remainBalance);
        //}

        //Exeption Case
        //ตัวเลขไม่ถูกต้อง < 1 และ > 13
        //ไพ่ไม่มีอยู่จริง เช่น 4 heart & 4 heart
    }
}
