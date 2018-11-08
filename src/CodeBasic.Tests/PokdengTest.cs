using System;
using Xunit;

namespace CodeBasic.Tests
{
    public class PokdengTest
    {
        const string Club = "Club";
        const string Diamond = "Diamond";
        const string Heart = "Heart";
        const string Spade = "Spade";

        [Theory(DisplayName = "ตรสจสอบว่าผู้เล่นสามารถเล่นได้หรือไม่จากจำรวนเงินที่ผู้เล่นเดิมพันกับจำนวนเงินที่ผู้เล่นมี")]
        [InlineData(100, 10, true)]
        [InlineData(500, 100, true)]
        [InlineData(0, 0, false)]
        [InlineData(0, 10, false)]
        [InlineData(10, 0, false)]
        [InlineData(50, 11, false)]
        public void PlayableTest(int playerBalance, int playerBet, bool expected)
        {
            var player = new Pokdeng();
            player.PlayerBalance = playerBalance;
            var result = player.Playable(playerBet);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ดึงผลลัพธ์จากไพ่ของผู้เล่นกรณีปกติ")]
        [InlineData(PokdengInfo.PlayerResult.Normal, 1, 4, 5, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Diamond)]
        [InlineData(PokdengInfo.PlayerResult.Normal, 10, 11, 5, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Diamond)]
        [InlineData(PokdengInfo.PlayerResult.Pok9, 9, 11, 0, PokdengInfo.Symbol.Diamond, PokdengInfo.Symbol.Club, "")]
        [InlineData(PokdengInfo.PlayerResult.Pok9, 8, 1, 0, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Diamond, "")]
        [InlineData(PokdengInfo.PlayerResult.Pok8, 10, 8, 0, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Diamond, "")]
        [InlineData(PokdengInfo.PlayerResult.Pok8, 2, 6, 0, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Heart, "")]
        [InlineData(PokdengInfo.PlayerResult.Tong, 3, 3, 3, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Diamond, PokdengInfo.Symbol.Spade)]
        [InlineData(PokdengInfo.PlayerResult.Tong, 11, 11, 11, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Diamond, PokdengInfo.Symbol.Spade)]
        [InlineData(PokdengInfo.PlayerResult.Ghost, 11, 12, 13, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Diamond, PokdengInfo.Symbol.Spade)]
        [InlineData(PokdengInfo.PlayerResult.Ghost, 12, 12, 13, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Diamond, PokdengInfo.Symbol.Spade)]
        [InlineData(PokdengInfo.PlayerResult.Set, 1, 2, 3, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Diamond, PokdengInfo.Symbol.Spade)]
        [InlineData(PokdengInfo.PlayerResult.Set, 9, 10, 8, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Diamond, PokdengInfo.Symbol.Spade)]
        [InlineData(PokdengInfo.PlayerResult.Twobounce, 2, 2, 0, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Diamond, "")]
        [InlineData(PokdengInfo.PlayerResult.Twobounce, 1, 2, 0, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, "")]
        [InlineData(PokdengInfo.PlayerResult.ThreeBounce, 2, 2, 2, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade)]
        [InlineData(PokdengInfo.PlayerResult.ThreeBounce, 1, 2, 5, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart)]
        public void GetResultTypeTest(PokdengInfo.PlayerResult expected, int p1CardNo1, int p1CardNo2, int p1CardNo3, string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3)
        {
            var player = new Pokdeng();
            var result = player.GetRewardType(p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ดึงผลลัพธ์จากไพ่ของผู้เล่นกรณีมีหลายผลลัพธ์")]
        [InlineData(PokdengInfo.PlayerResult.Pok8Twobounce, 10, 8, 0, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, "")]
        [InlineData(PokdengInfo.PlayerResult.Pok8Twobounce, 5, 3, 0, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, "")]
        [InlineData(PokdengInfo.PlayerResult.Pok9Twobounce, 8, 1, 0, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Club, "")]
        [InlineData(PokdengInfo.PlayerResult.Pok9Twobounce, 10, 9, 0, PokdengInfo.Symbol.Diamond, PokdengInfo.Symbol.Diamond, "")]
        [InlineData(PokdengInfo.PlayerResult.SetThreeBounce, 2, 4, 3, PokdengInfo.Symbol.Diamond, PokdengInfo.Symbol.Diamond, PokdengInfo.Symbol.Diamond)]
        [InlineData(PokdengInfo.PlayerResult.SetThreeBounce, 4, 5, 6, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade)]
        [InlineData(PokdengInfo.PlayerResult.GhostThreeBounce, 11, 12, 13, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade)]
        [InlineData(PokdengInfo.PlayerResult.GhostThreeBounce, 12, 13, 11, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade)]
        public void GetMultipleResultTypeTest(PokdengInfo.PlayerResult expected, int p1CardNo1, int p1CardNo2, int p1CardNo3, string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3)
        {
            var player = new Pokdeng();
            var result = player.GetRewardType(p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3);
            Assert.Equal(expected, result);
        }
    }
}