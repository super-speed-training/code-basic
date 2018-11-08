using System;
using Xunit;

namespace CodeBasic.Tests
{
    public class PokdengTest
    {
        [Theory(DisplayName = "ผู้เล่นลงไพ่ชนะผู้เล่นต้องได้เงินเพิ่มอย่างถูกต้อง")]
        [InlineData(110, 100, 10,
            1, 1, 2, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade,
            2, 3, 10, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade)]
        [InlineData(110, 100, 10,
            2, 3, 4, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade,
            1, 8, 0, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, "")]
        [InlineData(110, 100, 10,
            11, 12, 12, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade,
            5, 3, 0, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, "")]
        [InlineData(150, 100, 10,
            11, 12, 12, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade,
            3, 3, 3, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade)]
        [InlineData(130, 100, 10,
            1, 2, 3, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade,
            13, 12, 11, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade)]
        [InlineData(130, 100, 10,
            2, 2, 3, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade,
            7, 8, 9, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade)]
        [InlineData(120, 100, 10,
            2, 2, 1, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade,
            8, 8, 0, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, "")]
        [InlineData(120, 100, 10,
            9, 9, 0, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade, "",
            8, 1, 0, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Club, "")]
        [InlineData(150, 100, 10,
            9, 1, 3, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade,
            13, 11, 12, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Club)]
        [InlineData(150, 100, 10,
            9, 1, 3, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade,
            1, 2, 3, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Club)]
        public void Player2WinAGameHisBalanceMustBeIncreasCorrectly(int expected, int balance, int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3, string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3, string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            var player = new Pokdeng();
            player.PlayerBalance = balance;
            player.CheckGameResult(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3,
            p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            Assert.Equal(expected, player.PlayerBalance);
        }

        [Theory(DisplayName = "ผู้เล่นลงไพ่แพ้เงินผู้เล่นต้องลดลงอย่างถูกต้อง")]
        [InlineData(90, 100, 10,
            2, 3, 10, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade,
            1, 1, 2, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade)]
        [InlineData(90, 100, 10,
            1, 8, 0, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, "",
            2, 3, 4, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade)]
        [InlineData(90, 100, 10,
            5, 3, 0, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, "",
            11, 12, 12, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade)]
        [InlineData(50, 100, 10,
            3, 3, 3, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade,
            11, 12, 12, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade)]
        [InlineData(70, 100, 10,
            13, 12, 11, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade,
            1, 2, 3, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade)]
        [InlineData(70, 100, 10,
            7, 8, 9, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade,
            2, 2, 3, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade)]
        [InlineData(80, 100, 10,
            8, 8, 0, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, "",
            2, 2, 1, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade)]
        [InlineData(80, 100, 10,
            8, 1, 0, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Club, "",
            9, 9, 0, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade, "")]
        [InlineData(50, 100, 10,
            13, 11, 12, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Club,
            9, 1, 3, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade)]
        [InlineData(50, 100, 10,
            1, 2, 3, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Club,
            9, 1, 3, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade, PokdengInfo.Symbol.Spade)]
        public void Player2LoseAGameHisBalanceMustBeDecreasCorrectly(int expected, int balance, int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3, string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3, string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            var player = new Pokdeng();
            player.PlayerBalance = balance;
            player.CheckGameResult(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3,
            p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            Assert.Equal(expected, player.PlayerBalance);
        }

        [Theory(DisplayName = "ผู้ทั้งสองคนเสมอกันเงินต้องไม่ลดหรือเพิ่ม")]
        [InlineData(100, 100, 10,
            1, 1, 2, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade,
            1, 1, 2, PokdengInfo.Symbol.Club, PokdengInfo.Symbol.Heart, PokdengInfo.Symbol.Spade)]
        public void ResultGameIsWitdrawPlayer2BalanceMustNotChange(int expected, int balance, int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3, string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3, string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            var player = new Pokdeng();
            player.PlayerBalance = balance;
            player.CheckGameResult(betAmount, p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3,
            p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            Assert.Equal(expected, player.PlayerBalance);
        }

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
        [InlineData(PokdengInfo.GameResult.Draw, PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.Pok9)]
        [InlineData(PokdengInfo.GameResult.Draw, PokdengInfo.PlayerResult.Pok8, PokdengInfo.PlayerResult.Pok8)]
        [InlineData(PokdengInfo.GameResult.Draw, PokdengInfo.PlayerResult.Ghost, PokdengInfo.PlayerResult.Ghost)]
        [InlineData(PokdengInfo.GameResult.Draw, PokdengInfo.PlayerResult.Set, PokdengInfo.PlayerResult.Set)]
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
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.Set)]
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
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.Set, PokdengInfo.PlayerResult.Pok8)]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.Normal, PokdengInfo.PlayerResult.Pok8)]
        public void PlayersGetPog8HeMustBeWinThePlayerThatHeGetLowerResult(string expected, PokdengInfo.PlayerResult p1Result, PokdengInfo.PlayerResult p2Result)
        {
            var player = new Pokdeng();
            var result = player.GetWinnerBySpecialResult(p1Result, p2Result);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นได้ตองจะชนะคนที่ได้ไพ่แบบต่ำกว่า")]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Tong, PokdengInfo.PlayerResult.Ghost)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Tong, PokdengInfo.PlayerResult.Set)]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Tong, PokdengInfo.PlayerResult.Normal)]
        public void PlayersGetTongHeMustBeWinThePlayerThatHeGetLowerResult(string expected, PokdengInfo.PlayerResult p1Result, PokdengInfo.PlayerResult p2Result)
        {
            var player = new Pokdeng();
            var result = player.GetWinnerBySpecialResult(p1Result, p2Result);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นได้ผีจะชนะคนที่ได้ไพ่แบบต่ำกว่า")]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.Set, PokdengInfo.PlayerResult.Ghost)]
        [InlineData(PokdengInfo.GameResult.Player2Win, PokdengInfo.PlayerResult.Normal, PokdengInfo.PlayerResult.Ghost)]
        public void PlayersGhostHeMustBeWinThePlayerThatHeGetLowerResult(string expected, PokdengInfo.PlayerResult p1Result, PokdengInfo.PlayerResult p2Result)
        {
            var player = new Pokdeng();
            var result = player.GetWinnerBySpecialResult(p1Result, p2Result);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นได้เรียงจะชนะคนที่ได้ไพ่แบบต่ำกว่า")]
        [InlineData(PokdengInfo.GameResult.Player1Win, PokdengInfo.PlayerResult.Set, PokdengInfo.PlayerResult.Normal)]
        public void PlayersSetHeMustBeWinThePlayerThatHeGetLowerResult(string expected, PokdengInfo.PlayerResult p1Result, PokdengInfo.PlayerResult p2Result)
        {
            var player = new Pokdeng();
            var result = player.GetWinnerBySpecialResult(p1Result, p2Result);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นที่ได้ไพ่เด้งต้องเปลี่ยนให้เป็นแบบธรรมดาก่อนที่จะเทียบผลลัพธ์กัน")]
        [InlineData(PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.Pok9)]
        [InlineData(PokdengInfo.PlayerResult.Ghost, PokdengInfo.PlayerResult.Ghost)]
        [InlineData(PokdengInfo.PlayerResult.Normal, PokdengInfo.PlayerResult.Normal)]
        [InlineData(PokdengInfo.PlayerResult.Normal, PokdengInfo.PlayerResult.Twobounce)]
        [InlineData(PokdengInfo.PlayerResult.Normal, PokdengInfo.PlayerResult.ThreeBounce)]
        [InlineData(PokdengInfo.PlayerResult.Pok9, PokdengInfo.PlayerResult.Pok9Twobounce)]
        [InlineData(PokdengInfo.PlayerResult.Pok8, PokdengInfo.PlayerResult.Pok8Twobounce)]
        [InlineData(PokdengInfo.PlayerResult.Set, PokdengInfo.PlayerResult.SetThreeBounce)]
        [InlineData(PokdengInfo.PlayerResult.Ghost, PokdengInfo.PlayerResult.GhostThreeBounce)]
        public void PlayerThatHasbounceHisResultMustBeUnbounceResultBeforeCompare(PokdengInfo.PlayerResult expected, PokdengInfo.PlayerResult pResult)
        {
            var player = new Pokdeng();
            var result = player.ConvertToUnbounceResult(pResult);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นที่ได้แต้มมากกว่าจะชนะ")]
        [InlineData(PokdengInfo.GameResult.Player1Win, 10, 9, 5, 1, 11, 1)]
        [InlineData(PokdengInfo.GameResult.Player1Win, 7, 11, 13, 1, 3, 10)]
        [InlineData(PokdengInfo.GameResult.Player2Win, 10, 11, 12, 1, 10, 10)]
        [InlineData(PokdengInfo.GameResult.Player2Win, 1, 11, 1, 1, 10, 2)]
        public void PlayerThatHasGreaterPointMustBeWin(string expected, int p1CardNo1, int p1CardNo2, int p1CardNo3, int p2CardNo1, int p2CardNo2, int p2CardNo3)
        {
            var player = new Pokdeng();
            var result = player.GetWinnerByNormalResult(p1CardNo1, p1CardNo2, p1CardNo3, p2CardNo1, p2CardNo2, p2CardNo3);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ผู้เล่นได้แต้มเท่ากันจะเสมอ")]
        [InlineData(PokdengInfo.GameResult.Draw, 10, 4, 1, 1, 2, 2)]
        [InlineData(PokdengInfo.GameResult.Draw, 1, 11, 13, 10, 8, 3)]
        [InlineData(PokdengInfo.GameResult.Draw, 10, 8, 2, 10, 10, 10)]
        public void PlayersThatHasSamePointResultMustBeDraws(string expected, int p1CardNo1, int p1CardNo2, int p1CardNo3, int p2CardNo1, int p2CardNo2, int p2CardNo3)
        {
            var player = new Pokdeng();
            var result = player.GetWinnerByNormalResult(p1CardNo1, p1CardNo2, p1CardNo3, p2CardNo1, p2CardNo2, p2CardNo3);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "คำนวณเงินที่ผู้เล่นได้หรือลดตามผลลัพธ์ได้ถูกต้อง")]
        [InlineData(5, 5, PokdengInfo.PlayerResult.Normal)]
        [InlineData(60, 60, PokdengInfo.PlayerResult.Pok9)]
        [InlineData(800, 800, PokdengInfo.PlayerResult.Pok8)]
        [InlineData(300, 60, PokdengInfo.PlayerResult.Tong)]
        [InlineData(24, 8, PokdengInfo.PlayerResult.Ghost)]
        [InlineData(24, 8, PokdengInfo.PlayerResult.Set)]
        [InlineData(16, 8, PokdengInfo.PlayerResult.Twobounce)]
        [InlineData(24, 8, PokdengInfo.PlayerResult.ThreeBounce)]
        [InlineData(16, 8, PokdengInfo.PlayerResult.Pok8Twobounce)]
        [InlineData(16, 8, PokdengInfo.PlayerResult.Pok9Twobounce)]
        [InlineData(30, 6, PokdengInfo.PlayerResult.GhostThreeBounce)]
        [InlineData(30, 6, PokdengInfo.PlayerResult.SetThreeBounce)]
        public void GetRewardCorrectly(int expected, int bet, PokdengInfo.PlayerResult presult)
        {
            var player = new Pokdeng();
            var result = player.GetReward(bet, presult);
            Assert.Equal(expected, result);
        }
    }
}