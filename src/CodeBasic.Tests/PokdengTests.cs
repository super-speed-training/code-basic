using System;
using Xunit;

namespace CodeBasic.Tests
{
    public class PokdengTests
    {
        private const string Club = "Club";
        private const string Diamond = "Diamond";
        private const string Heart = "Heart";
        private const string Spade = "Spade";


        [Theory(DisplayName = "แต้มผู้เล่นชนะเจ้ามือ ผู้เล่นได้รับเงินเพิ่มเท่ากับเงินที่ลงพนัน")]
        [InlineData(100, 1, 2, Club, Diamond, 5, 2, Club, Diamond, 1000, 1100)]
        [InlineData(100, 1, 3, Club, Diamond, 2, 3, Club, Diamond, 1000, 1100)]
        [InlineData(100, 2, 1, Club, Diamond, 1, 4, Club, Diamond, 1000, 1100)]
        public void PlayerWinThenGainX1FromBet(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "แต้มผู้เล่นแพ้เจ้ามือ ผู้เล่นเสียเงินเท่ากับเงินที่ลงพนัน")]
        [InlineData(100, 4, 2, Club, Diamond, 2, 1, Club, Diamond, 1000, 900)]
        [InlineData(100, 4, 3, Club, Diamond, 1, 3, Club, Diamond, 1000, 900)]
        [InlineData(100, 1, 4, Club, Diamond, 1, 3, Club, Diamond, 1000, 900)]
        public void PlayerLoseThenLoseX1FromBet(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "แต้มผู้เล่นเสมอกับเจ้ามือ ผู้เล่นไม่เสียเงิน")]
        [InlineData(100, 1, 2, Club, Diamond, 1, 2, Club, Diamond, 1000, 1000)]
        [InlineData(100, 1, 3, Club, Diamond, 1, 3, Club, Diamond, 1000, 1000)]
        [InlineData(100, 1, 4, Club, Diamond, 1, 4, Club, Diamond, 1000, 1000)]

        [InlineData(100, 1, 5, Heart, Heart, 4, 2, Club, Club, 1000, 1000)]
        [InlineData(200, 1, 6, Heart, Heart, 4, 3, Club, Club, 1000, 1000)]
        [InlineData(300, 1, 4, Heart, Heart, 3, 2, Club, Club, 1000, 1000)]

        [InlineData(100, 1, 3, Heart, Club, 2, 2, Club, Heart, 1000, 1000)]
        [InlineData(200, 2, 2, Heart, Club, 2, 2, Club, Heart, 1000, 1000)]
        [InlineData(300, 5, 1, Heart, Club, 3, 3, Club, Heart, 1000, 1000)]
        public void PlayerDrawThenDoNothing(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "แต้มผู้เล่นชนะเจ้ามือ2เด้ง ผู้เล่นได้รับเงินเพิ่ม2เท่าของเงินที่ลงพนัน")]
        [InlineData(100, 1, 2, Club, Heart, 1, 4, Club, Club, 1000, 1200)]
        [InlineData(200, 1, 3, Club, Heart, 1, 5, Club, Club, 1000, 1400)]
        [InlineData(300, 1, 4, Club, Heart, 1, 6, Club, Club, 1000, 1600)]
        public void PlayerWinSameSymbolThenGainX2FromBet(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "แต้มผู้เล่นแพ้เจ้ามือ2เด้ง ผู้เล่นผู้เล่นเสียเงิน2เท่าของเงินที่ลงพนัน")]
        [InlineData(100, 1, 5, Heart, Heart, 1, 1, Club, Club, 1000, 800)]
        [InlineData(200, 1, 6, Heart, Heart, 1, 3, Club, Club, 1000, 600)]
        [InlineData(300, 1, 4, Heart, Heart, 1, 2, Club, Club, 1000, 400)]
        public void PlayerLoseSameSymbolThenLoseX2FromBet(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "แต้มผู้เล่นแพ้เจ้ามือ2เด้ง ผู้เล่นผู้เล่นได้เงิน2เท่าของเงินที่ลงพนัน")]
        [InlineData(100, 1, 2, Heart, Club, 2, 2, Club, Heart, 1000, 1200)]
        [InlineData(200, 2, 1, Heart, Club, 2, 2, Club, Heart, 1000, 1400)]
        [InlineData(300, 4, 1, Heart, Club, 3, 3, Club, Heart, 1000, 1600)]
        public void PlayerWinSameNumberThenGainX2FromBet(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "แต้มผู้เล่นป็อก8ชนะเจ้ามือ ผู้เล่นได้เงินเท่ากับเงินที่ลงพนัน")]
        [InlineData(100, 1, 2, Heart, Club, 1, 7, Club, Heart, 1000, 1100)]
        [InlineData(200, 2, 1, Heart, Club, 2, 6, Club, Heart, 1000, 1200)]
        [InlineData(300, 4, 1, Heart, Club, 3, 5, Club, Heart, 1000, 1300)]

        [InlineData(100, 1, 2, Heart, Club, 1, 7, Club, Club, 1000, 1200)]
        [InlineData(200, 2, 1, Heart, Club, 2, 6, Club, Club, 1000, 1400)]
        [InlineData(300, 4, 1, Heart, Club, 3, 5, Club, Club, 1000, 1600)]
        public void PlayerWinPok8ThenGainX1FromBet(int bet, int p1cn1, int p1cn2, string p1cs1, string p1cs2, int p2cn1, int p2cn2, string p2cs1, string p2cs2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng { PlayerBalance = balance };
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1cn1, p1cn2, 0, p1cs1, p1cs2, string.Empty, p2cn1, p2cn2, 0, p2cs1, p2cs2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }



        /*
         * Normal cases
         * แต้มผู้เล่นชนะเจ้ามือ โดยผลรวมเกิน 9 ผู้เล่นได้รับเงินเพิ่มเท่ากับเงินที่ลงพนัน
         * แต้มผู้เล่นแพ้เจ้ามือ โดยผลรวมเกิน 9 ผู้เล่นเสียเงินเท่ากับเงินที่ลงพนัน
         * แต้มผู้เล่นเสมอกับเจ้ามือ โดยผลรวมเกิน 9 ผู้เล่นไม่เสียเงิน
         * ---
         * แต้มผู้เล่นชนะเจ้ามือโดยเป็นไพ่ป๊อก ผู้เล่นได้รับเงินเพิ่มเท่ากับเงินที่ลงพนัน
         * แต้มผู้เล่นแพ้เจ้ามือโดยเป็นไพ่ป๊อก ผู้เล่นเสียเงินเท่ากับเงินที่ลงพนัน
         * แต้มผู้เล่นเสมอกับเจ้ามือโดยเป็นไพ่ป๊อก ผู้เล่นไม่เสียเงิน
         * ---
         * ผู้เล่นลงเงินเกินที่ตัวเองมี ระบบแจ้งเตือนข้อผิดพลาด และยกเลิกการเล่นในรอบนั้นไป
         * 
         * 
         * Alternative cases
         * แต้มผู้เล่นชนะเจ้ามือ แบบสองเด้ง ผู้เล่นได้รับเงินเพิ่ม 2 เท่าของเงินที่ลงพนัน
         * แต้มผู้เล่นแพ้เจ้ามือ แบบสองเด้ง ผู้เล่นเสียเงิน 2 เท่าของเงินที่ลงพนัน
         * แต้มผู้เล่นเสมอกับเจ้ามือ แบบสองเด้ง ผู้เล่นไม่เสียเงิน
         * ---
         * แต้มผู้เล่นชนะเจ้ามือ แบบป๊อกสองเด้ง ผู้เล่นได้รับเงินเพิ่ม 2 เท่าของเงินที่ลงพนัน
         * แต้มผู้เล่นแพ้เจ้ามือ แบบป๊อกสองเด้ง ผู้เล่นเสียเงิน 2 เท่าของเงินที่ลงพนัน
         * แต้มผู้เล่นเสมอกับเจ้ามือ แบบป๊อกสองเด้ง ผู้เล่นไม่เสียเงิน
         * ---
         * แต้มผู้เล่นชนะเจ้ามือ แบบสามเด้ง ผู้เล่นได้รับเงินเพิ่ม 3 เท่าของเงินที่ลงพนัน
         * แต้มผู้เล่นแพ้เจ้ามือ แบบสามเด้ง ผู้เล่นเสียเงิน 3 เท่าของเงินที่ลงพนัน
         * แต้มผู้เล่นเสมอกับเจ้ามือ แบบสามเด้ง ผู้เล่นไม่เสียเงิน
         * ---
         * แต้มผู้เล่นชนะเจ้ามือ แบบไพ่เรียง ผู้เล่นได้รับเงินเพิ่ม 3 เท่าของเงินที่ลงพนัน
         * แต้มผู้เล่นแพ้เจ้ามือ แบบไพ่เรียง ผู้เล่นเสียเงิน 3 เท่าของเงินที่ลงพนัน
         * แต้มผู้เล่นเสมอกับเจ้ามือ แบบไพ่เรียง ผู้เล่นไม่เสียเงิน
         * ---
         * แต้มผู้เล่นชนะเจ้ามือ แบบไพ่ผี ผู้เล่นได้รับเงินเพิ่ม 3 เท่าของเงินที่ลงพนัน
         * แต้มผู้เล่นแพ้เจ้ามือ แบบไพ่ผี ผู้เล่นเสียเงิน 3 เท่าของเงินที่ลงพนัน
         * แต้มผู้เล่นเสมอกับเจ้ามือ แบบไพ่ผี ผู้เล่นไม่เสียเงิน
         * ---
         * แต้มผู้เล่นชนะเจ้ามือ แบบไพ่ตอง ผู้เล่นได้รับเงินเพิ่ม 5 เท่าของเงินที่ลงพนัน
         * แต้มผู้เล่นแพ้เจ้ามือ แบบไพ่ตอง ผู้เล่นเสียเงิน 5 เท่าของเงินที่ลงพนัน
         * แต้มผู้เล่นเสมอกับเจ้ามือ แบบไพ่ตอง ผู้เล่นไม่เสียเงิน
         * ---
         * ผู้เล่นได้ไพ่ป๊อก เจ้ามือได้ไพ่เรียง ผู้เล่นได้รับเงินเพิ่มเท่ากับเงินที่ลงพนัน
         * ผู้เล่นได้ไพ่ป๊อก เจ้ามือได้ไพ่ผี ผู้เล่นได้รับเงินเพิ่มเท่ากับเงินที่ลงพนัน
         * ผู้เล่นได้ไพ่ป๊อก เจ้ามือได้ไพ่ตอง ผู้เล่นได้รับเงินเพิ่มเท่ากับเงินที่ลงพนัน
         * ผู้เล่นได้ไพ่ป๊อก เจ้ามือได้ไพ่สามเด้ง ผู้เล่นได้รับเงินเพิ่มเท่ากับเงินที่ลงพนัน
         * ---
         * ผู้เล่นได้ไพ่ป๊อกสองเด้ง เจ้ามือได้ไพ่เรียง ผู้เล่นได้รับเงินเพิ่ม 2 เท่าของเงินที่ลงพนัน
         * ผู้เล่นได้ไพ่ป๊อกสองเด้ง เจ้ามือได้ไพ่ผี ผู้เล่นได้รับเงินเพิ่ม 2 เท่าของเงินที่ลงพนัน
         * ผู้เล่นได้ไพ่ป๊อกสองเด้ง เจ้ามือได้ไพ่ตอง ผู้เล่นได้รับเงินเพิ่ม 2 เท่าของเงินที่ลงพนัน
         * ผู้เล่นได้ไพ่ป๊อกสองเด้ง เจ้ามือได้ไพ่สามเด้ง ผู้เล่นได้รับเงินเพิ่ม 2 เท่าของเงินที่ลงพนัน
         * ---
         * เจ้ามือได้ไพ่ป๊อก ผู้เล่นได้ไพ่เรียง ผู้เล่นเสียเงินเท่ากับเงินที่ลงพนัน
         * เจ้ามือได้ไพ่ป๊อก ผู้เล่นได้ไพ่ผี ผู้เล่นเสียเงินเท่ากับเงินที่ลงพนัน
         * เจ้ามือได้ไพ่ป๊อก ผู้เล่นได้ไพ่ตอง ผู้เล่นเสียเงินเท่ากับเงินที่ลงพนัน
         * เจ้ามือได้ไพ่ป๊อก ผู้เล่นได้ไพ่สามเด้ง ผู้เล่นเสียเงินเท่ากับเงินที่ลงพนัน
         * ---
         * เจ้ามือได้ไพ่ป๊อกสองเด้ง ผู้เล่นได้ไพ่เรียง ผู้เล่นเสียเงิน 2 เท่าของเงินที่ลงพนัน
         * เจ้ามือได้ไพ่ป๊อกสองเด้ง ผู้เล่นได้ไพ่ผี ผู้เล่นเสียเงิน 2 เท่าของเงินที่ลงพนัน
         * เจ้ามือได้ไพ่ป๊อกสองเด้ง ผู้เล่นได้ไพ่ตอง ผู้เล่นเสียเงิน 2 เท่าของเงินที่ลงพนัน
         * เจ้ามือได้ไพ่ป๊อกสองเด้ง ผู้เล่นได้ไพ่สามเด้ง ผู้เล่นเสียเงิน 2 เท่าของเงินที่ลงพนัน
         * ---
         * ผู้เล่นเสียเงินเกินที่ตัวเองมี ระบบแจ้งเตือนข้อผิดพลาด และยกเลิกการเล่นในรอบนั้นไป
         * ผู้เล่นและเจ้ามือได้ไพ่ตองทั้งคู่ ผู้เล่นไม่เสียเงิน
         * ผู้เล่นและเจ้ามือได้ไพ่ผีทั้งคู่ ผู้เล่นไม่เสียเงิน
         * ผู้เล่นและเจ้ามือได้ไพ่เรียงทั้งคู่ ผู้เล่นไม่เสียเงิน
         * 
         * Exception cases
         * ผู้เล่นมีเงินไม่พอจ่าย ระบบแจ้งเตือนข้อผิดพลาด และยกเลิกการเล่นในรอบนั้นไป
         * ผู้เล่นลงเงินไม่ถูกต้อง ระบบแจ้งเตือนข้อผิดพลาด และยกเลิกการเล่นในรอบนั้นไป
         * เจ้ามือได้ไพ่ป๊อก ผู้เล่นมีไพ่ 3 ใบ ระบบจะคำนวณแค่ไพ่ 2 ใบแรกของผู้เล่น
         * ได้รับไพ่ที่ไม่ถูกต้อง ระบบแจ้งเตือนข้อผิดพลาด และยกเลิกการเล่นในรอบนั้นไป
         */
    }
}
