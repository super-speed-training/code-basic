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

        [Theory(DisplayName = "ผู้เล่นสามารถเล่นเกมได้หากเข้ามีเงินมากพอ")]
        [InlineData(100, 10, true)]
        [InlineData(500, 100, true)]
        [InlineData(0, 0, false)]
        [InlineData(0, 10, false)]
        [InlineData(10, 0, false)]
        [InlineData(50, 11, false)]
        public void Player2CanPlayIfHeHasEnoughtBalance(int playerBalance, int playerBet, bool expected)
        {
            var player = new Pokdeng();
            player.PlayerBalance = playerBalance;
            var result = player.Playable(playerBet);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นได้ผลลัพธ์ตามแบบปกติ")]
        [InlineData(PokdengInfo.PlayerResult.Normal, 7, 13, 0, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Spade, "")]
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
        [InlineData(PokdengInfo.PlayerResult.ThreeBounce, 2, 2, 8, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart)]
        [InlineData(PokdengInfo.PlayerResult.ThreeBounce, 1, 2, 5, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart)]
        public void PlayerGetResultByNormalCase(PokdengInfo.PlayerResult expected, int p1CardNo1, int p1CardNo2, int p1CardNo3, string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3)
        {
            var player = new Pokdeng();
            var result = player.GetRewardType(p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นได้ผลลัพธ์มากกว่าหนึ่งแบบ")]
        [InlineData(PokdengInfo.PlayerResult.Pok8Twobounce, 10, 8, 0, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, "")]
        [InlineData(PokdengInfo.PlayerResult.Pok8Twobounce, 5, 3, 0, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, "")]
        [InlineData(PokdengInfo.PlayerResult.Pok9Twobounce, 8, 1, 0, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Club, "")]
        [InlineData(PokdengInfo.PlayerResult.Pok9Twobounce, 10, 9, 0, PokdengInfo.Symbol.Diamond, PokdengInfo.Symbol.Diamond, "")]
        [InlineData(PokdengInfo.PlayerResult.SetThreeBounce, 2, 4, 3, PokdengInfo.Symbol.Diamond, PokdengInfo.Symbol.Diamond, PokdengInfo.Symbol.Diamond)]
        [InlineData(PokdengInfo.PlayerResult.SetThreeBounce, 4, 5, 6, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade)]
        [InlineData(PokdengInfo.PlayerResult.GhostThreeBounce, 11, 12, 13, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade)]
        [InlineData(PokdengInfo.PlayerResult.GhostThreeBounce, 12, 13, 11, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade)]
        public void PlayerGetMultipleResult(PokdengInfo.PlayerResult expected, int p1CardNo1, int p1CardNo2, int p1CardNo3, string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3)
        {
            var player = new Pokdeng();
            var result = player.GetRewardType(p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นได้ผลลัพธ์แบบพิเศษการแข่งขันจะเสมอ")]
        [InlineData(PokdengInfo.GameResult.Draw, PokdengInfo.PlayerResult.Pok8, PokdengInfo.PlayerResult.Pok8)]
        [InlineData(PokdengInfo.GameResult.Draw, PokdengInfo.PlayerResult.Pok8Twobounce, PokdengInfo.PlayerResult.Pok8Twobounce)]
        [InlineData(PokdengInfo.GameResult.Draw, PokdengInfo.PlayerResult.Pok8, PokdengInfo.PlayerResult.Pok8Twobounce)]
        [InlineData(PokdengInfo.GameResult.Draw, PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.Pok9)]
        [InlineData(PokdengInfo.GameResult.Draw, PokdengInfo.PlayerResult.Pok9Twobounce, PokdengInfo.PlayerResult.Pok9Twobounce)]
        [InlineData(PokdengInfo.GameResult.Draw, PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.Pok9Twobounce)]
        [InlineData(PokdengInfo.GameResult.Draw, PokdengInfo.PlayerResult.Ghost, PokdengInfo.PlayerResult.Ghost)]
        [InlineData(PokdengInfo.GameResult.Draw, PokdengInfo.PlayerResult.SetThreeBounce, PokdengInfo.PlayerResult.Set)]
        public void PlayersGetSameResultGameResultMustBeDraw(string expected, PokdengInfo.PlayerResult p1Result, PokdengInfo.PlayerResult p2Result)
        {
            var player = new Pokdeng();
            var result = player.GetWinnerBySpecialResult(p1Result, p2Result);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นได้ป๊อกเก้าจะชนะคนที่ได้ไพ่แบบต่ำกว่า")]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.Pok8)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.Tong)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.Ghost)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.GhostThreeBounce)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.Set)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.SetThreeBounce)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.Twobounce)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.ThreeBounce)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.Normal)]
        public void PlayersGetPog9HeMustBeWinThePlayerThatHeGetLowerResult(string expected, PokdengInfo.PlayerResult p1Result, PokdengInfo.PlayerResult p2Result)
        {
            var player = new Pokdeng();
            var result = player.GetWinnerBySpecialResult(p1Result, p2Result);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นได้ป๊อกแปดจะชนะคนที่ได้ไพ่แบบต่ำกว่า")]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.Tong, PokdengInfo.PlayerResult.Pok8)]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.Ghost, PokdengInfo.PlayerResult.Pok8)]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.GhostThreeBounce, PokdengInfo.PlayerResult.Pok8)]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.Set, PokdengInfo.PlayerResult.Pok8)]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.SetThreeBounce, PokdengInfo.PlayerResult.Pok8)]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.Twobounce, PokdengInfo.PlayerResult.Pok8)]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.ThreeBounce, PokdengInfo.PlayerResult.Pok8)]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.Normal, PokdengInfo.PlayerResult.Pok8)]
        public void PlayersGetPog8HeMustBeWinThePlayerThatHeGetLowerResult(string expected, PokdengInfo.PlayerResult p1Result, PokdengInfo.PlayerResult p2Result)
        {
            var player = new Pokdeng();
            var result = player.GetWinnerBySpecialResult(p1Result, p2Result);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นได้ตองจะชนะคนที่ได้ไพ่แบบต่ำกว่า")]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Tong, PokdengInfo.PlayerResult.Ghost)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Tong, PokdengInfo.PlayerResult.GhostThreeBounce)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Tong, PokdengInfo.PlayerResult.Set)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Tong, PokdengInfo.PlayerResult.SetThreeBounce)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Tong, PokdengInfo.PlayerResult.Twobounce)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Tong, PokdengInfo.PlayerResult.ThreeBounce)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Tong, PokdengInfo.PlayerResult.Normal)]
        public void PlayersGetTongHeMustBeWinThePlayerThatHeGetLowerResult(string expected, PokdengInfo.PlayerResult p1Result, PokdengInfo.PlayerResult p2Result)
        {
            var player = new Pokdeng();
            var result = player.GetWinnerBySpecialResult(p1Result, p2Result);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นได้ผีจะชนะคนที่ได้ไพ่แบบต่ำกว่า")]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.Set, PokdengInfo.PlayerResult.Ghost)]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.SetThreeBounce, PokdengInfo.PlayerResult.Ghost)]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.Twobounce, PokdengInfo.PlayerResult.GhostThreeBounce)]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.ThreeBounce, PokdengInfo.PlayerResult.GhostThreeBounce)]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.Normal, PokdengInfo.PlayerResult.Ghost)]
        public void PlayersGhostHeMustBeWinThePlayerThatHeGetLowerResult(string expected, PokdengInfo.PlayerResult p1Result, PokdengInfo.PlayerResult p2Result)
        {
            var player = new Pokdeng();
            var result = player.GetWinnerBySpecialResult(p1Result, p2Result);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นได้เรียงจะชนะคนที่ได้ไพ่แบบต่ำกว่า")]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Set, PokdengInfo.PlayerResult.Twobounce)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.SetThreeBounce, PokdengInfo.PlayerResult.ThreeBounce)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Set, PokdengInfo.PlayerResult.Normal)]
        public void PlayersSetHeMustBeWinThePlayerThatHeGetLowerResult(string expected, PokdengInfo.PlayerResult p1Result, PokdengInfo.PlayerResult p2Result)
        {
            var player = new Pokdeng();
            var result = player.GetWinnerBySpecialResult(p1Result, p2Result);
            Assert.Equal(expected, result);
        }
    }
}