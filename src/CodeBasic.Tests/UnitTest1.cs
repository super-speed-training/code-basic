using System;
using Xunit;



namespace CodeBasic.Tests
{
    public class PokdengTest
    {
       
        private const string club = "club";
        private const string diamond = "diamond";
        private const string heart = "heart";
        private const string spade = "spade";

        [Theory(DisplayName = "ผู้เล่นเสมอเจ้ามือ ไพ่สองใบ ผู้เล่นได้แต้ม'เท่ากับ'เจ้ามือ -ไม่เสียเงินเดิมพัน")]
        [InlineData(200, 3, 4, diamond, club, 5, 2, spade, spade, 1000, 1000)]
        [InlineData(200, 2, 4, diamond, club, 3, 3, spade, spade, 1000, 1000)]
        public void PlayerDraw2CardThenDoNothing(int bet, int p1card1, int p1card2, string p1sym1, string p1sym2, int p2card1, int p2card2, string p2sym1, string p2sym2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            /*balance = sut.PlayerBalance;
            sut.PlayerBalance = 0;
            balance = 0 */ //ด้านซ้ายไว้เก็บค่า 
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1card1, p1card2, 0, p1sym1, p1sym2, string.Empty, p2card1, p2card2, 0, p2sym1, p2sym2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "ผู้เล่นเสมอเจ้ามือ ไพ่สามใบ ผู้เล่นได้แต้ม'เท่ากับ'เจ้ามือ -ไม่เสียเงินเดิมพัน")]
        [InlineData(200, 3, 4, 1, diamond, club, diamond, 3, 2, 3, spade, spade, diamond, 1000, 1000)]
        public void PlayerDraw3CardThenDoNothing(int bet, int p1card1, int p1card2, int p1card3, string p1sym1, string p1sym2, string p1sym3, int p2card1, int p2card2, int p2card3, string p2sym1, string p2sym2, string p2sym3, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1card1, p1card2, p1card3, p1sym1, p1sym2, p1sym3, p2card1, p2card2, p2card3, p2sym1, p2sym2, p2sym3);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "ผู้เล่นชนะเจ้ามือ ผู้เล่นได้แต้ม'มากกว่า'เจ้ามือ -ได้เงินเท่ากับที่เดิมพัน")]
        [InlineData(100, 2, 3, club, spade, 5, 2, spade, diamond, 1000, 1100)]
        [InlineData(100, 3, 2, club, spade, 9, 8, spade, diamond, 1000, 1100)]

        public void PlayerWin_NormalCase(int bet, int p1card1, int p1card2, string p1sym1, string p1sym2, int p2card1, int p2card2, string p2sym1, string p2sym2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1card1, p1card2, 0, p1sym1, p1sym2, string.Empty, p2card1, p2card2, 0, p2sym1, p2sym2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "ผู้เล่นแพ้เจ้ามือ ผู้เล่นได้แต้ม'น้อยกว่า'เจ้ามือ -เสียเงินเท่ากับที่เดิมพัน")]
        [InlineData(100, 5, 2, club, spade, 4, 2, spade, diamond, 1000, 900)]
        public void Playerlose_NormalCase(int bet, int p1card1, int p1card2, string p1sym1, string p1sym2, int p2card1, int p2card2, string p2sym1, string p2sym2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1card1, p1card2, 0, p1sym1, p1sym2, string.Empty, p2card1, p2card2, 0, p2sym1, p2sym2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "(2เด้ง) ผู้เล่นชนะเจ้ามือ ผู้เล่นได้แต้ม'มากกว่า'เจ้ามือ && เป็นดอกเดียวกัน ||เป็นเลขเดียวกัน -ได้เงินเดิมพันเพิ่ม 2เท่า")]
        [InlineData(100, 3, 2, club, diamond, 3, 4, club, club, 1000, 1200)]
        [InlineData(100, 2, 3, diamond, heart, 3, 3, spade, diamond, 1000, 1200)]
        public void PlayerWin_2deng(int bet, int p1card1, int p1card2, string p1sym1, string p1sym2, int p2card1, int p2card2, string p2sym1, string p2sym2, int balance, int expectedBalance)
            {
                var sut = new Pokdeng();
                sut.PlayerBalance = balance;
                sut.CheckGameResult(bet, p1card1, p1card2, 0, p1sym1, p1sym2, string.Empty, p2card1, p2card2, 0, p2sym1, p2sym2, string.Empty);
                Assert.Equal(expectedBalance, sut.PlayerBalance);
            }

        [Theory(DisplayName = "(2เด้ง) ผู้เล่นแพ้เจ้ามือ ผู้เล่นได้แต้ม'น้อยกว่า'เจ้ามือ && ไพ่เจ้ามือเป็นดอกเดียวกัน ||เป็นเลขเดียวกัน -เสียเงินเดิมพันเพิ่ม 2เท่า")]
        [InlineData(100, 3, 4, club, club, 3, 2, club, diamond, 1000, 800)]
        [InlineData(100, 3, 3, spade, diamond, 2, 3, diamond, heart, 1000, 800)]
        public void Playerlose_2deng(int bet, int p1card1, int p1card2, string p1sym1, string p1sym2, int p2card1, int p2card2, string p2sym1, string p2sym2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1card1, p1card2, 0, p1sym1, p1sym2, string.Empty, p2card1, p2card2, 0, p2sym1, p2sym2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "(2เด้ง) ผู้เล่นเสมอเจ้ามือ ผู้เล่นได้แต้ม'เท่ากับ'เจ้ามือ -ไม่เสียเงินเดิมพัน")]
        [InlineData(100, 3, 4, club, club, 3, 4, spade, spade, 1000, 1000)]
        public void Playerdraw_2deng(int bet, int p1card1, int p1card2, string p1sym1, string p1sym2, int p2card1, int p2card2, string p2sym1, string p2sym2, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1card1, p1card2, 0, p1sym1, p1sym2, string.Empty, p2card1, p2card2, 0, p2sym1, p2sym2, string.Empty);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "(3เด้ง) ผู้เล่นชนะเจ้ามือ ผู้เล่นได้แต้ม'มากกว่า'เจ้ามือ && เป็นดอกเดียวกัน -ได้เงินเดิมพันเพิ่ม 3เท่า")]
        [InlineData(200, 3, 4, 1, diamond, diamond, diamond, 4, 2, 3, spade, spade, spade, 1000, 1600)]
        public void PlayerWin_3deng(int bet, int p1card1, int p1card2, int p1card3, string p1sym1, string p1sym2, string p1sym3, int p2card1, int p2card2, int p2card3, string p2sym1, string p2sym2, string p2sym3, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1card1, p1card2, p1card3, p1sym1, p1sym2, p1sym3, p2card1, p2card2, p2card3, p2sym1, p2sym2, p2sym3);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

        [Theory(DisplayName = "(3เด้ง) ผู้เล่นแพ้เจ้ามือ ผู้เล่นได้แต้ม'น้อยกว่า'เจ้ามือ && เป็นดอกเดียวกัน -เสียเงินเดิมพันเพิ่ม 3เท่า")]
        [InlineData(200, 4, 2, 3, diamond, diamond, diamond, 3, 4, 1, spade, spade, spade, 1000, 400)]
        [InlineData(200, 3, 3, 3, diamond, diamond, diamond, 2, 1, 5, spade, spade, spade, 1000, 400)] 
        public void Playerlose_3deng(int bet, int p1card1, int p1card2, int p1card3, string p1sym1, string p1sym2, string p1sym3, int p2card1, int p2card2, int p2card3, string p2sym1, string p2sym2, string p2sym3, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1card1, p1card2, p1card3, p1sym1, p1sym2, p1sym3, p2card1, p2card2, p2card3, p2sym1, p2sym2, p2sym3);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }


        

        [Theory(DisplayName = "(ไพ่ป๊อก) ผู้เล่นชนะเจ้ามือ ผู้เล่นได้แต้ม >=8 ในไพ่'สองใบแรก'ก่อน && เจ้ามือ <8 -ได้เงินเท่ากับที่เดิมพัน")]
        [InlineData(200, 4, 2, 0, diamond, diamond, diamond, 3, 5, 0, diamond, spade, spade, 1000, 1200)]
        [InlineData(200, 3, 5, 0, diamond, diamond, diamond, 4, 5, 0, diamond, spade, spade, 1000, 1200)]
        public void PlayerWin_Pok(int bet, int p1card1, int p1card2, int p1card3, string p1sym1, string p1sym2, string p1sym3, int p2card1, int p2card2, int p2card3, string p2sym1, string p2sym2, string p2sym3, int balance, int expectedBalance)
        {
            var sut = new Pokdeng();
            sut.PlayerBalance = balance;
            sut.CheckGameResult(bet, p1card1, p1card2, p1card3, p1sym1, p1sym2, p1sym3, p2card1, p2card2, p2card3, p2sym1, p2sym2, p2sym3);
            Assert.Equal(expectedBalance, sut.PlayerBalance);
        }

//         [Theory(DisplayName = "(ไพ่ป๊อก) ผู้เล่นแพ้เจ้ามือ เจ้ามือได้แต้ม >=8 ในไพ่'สองใบแรก'ก่อน && ผู้เล่น <8 -เสียเงินเท่ากับที่เดิมพัน")]
//         [InlineData(200, 3, 5, 0, spade, diamond, diamond, 4, 2, 0, spade, spade, spade, 1000, 800)]
//         [InlineData(200, 4, 5, 0, diamond, club, diamond, 4, 2, 0, spade, spade, spade, 1000, 800)]
//         [InlineData(200, 2, 5, 2, diamond, club, heart, 3, 4, 2, spade, spade, spade, 1000, 1000)] //เสมอ
//         //ผู้เล่นแพ้เจ้ามือ เจ้ามือได้แต้ม >=8 ในไพ่'สองใบแรก'ก่อน && ผู้เล่น ==8 -เสียเงินเท่ากับที่เดิมพัน
//         //[InlineData(200, 4, 5, 0, diamond, diamond, diamond, 3, 5, 0, diamond, spade, spade, 1000, 800)]
//         //ผู้เล่นแพ้เจ้ามือ เจ้ามือได้แต้ม >=8 ในไพ่'สองใบแรก'ก่อน && ดอกเดียวกัน && ผู้เล่น ==8 -เสียเงินเท่ากับที่เดิมพัน
//         //[InlineData(200, 4, 5, 0, diamond, diamond, diamond, 3, 5, 0, diamond, spade, spade, 1000, 600)]
//         public void Playerlose_Pok(int bet, int p1card1, int p1card2, int p1card3, string p1sym1, string p1sym2, string p1sym3, int p2card1, int p2card2, int p2card3, string p2sym1, string p2sym2, string p2sym3, int balance, int expectedBalance)
//         {
//             var sut = new Pokdeng();
//             sut.PlayerBalance = balance;
//             sut.CheckGameResult(bet, p1card1, p1card2, p1card3, p1sym1, p1sym2, p1sym3, p2card1, p2card2, p2card3, p2sym1, p2sym2, p2sym3);
//             Assert.Equal(expectedBalance, sut.PlayerBalance);
//         }


//         [Theory(DisplayName = "(ไพ่ป๊อกเด้ง)ผู้เล่นชนะเจ้ามือ ผู้เล่นได้แต้ม >=8 && เป็นดอกเดียวกัน เจ้ามือได้ <8 -ได้เงินเดิมพันเพิ่ม 2เท่า")]
//         [InlineData(200, 3, 5, 0, diamond, diamond, diamond, 4, 5, 0, spade, spade, spade, 1000, 1400)]
//         //ผู้เล่นชนะเจ้ามือ ผู้เล่นได้แต้มเท่ากับ 8 && เป็นเลขเดียวกัน(4,4),(9,9) โดยเจ้ามือได้ <8 -ได้เงินเดิมพันเพิ่ม 2เท่า
//         [InlineData(200, 3, 2, 0, diamond, diamond, diamond, 4, 4, 0, spade, club, spade, 1000, 1400)]
//         public void PlayerWin_Pokdeng(int bet, int p1card1, int p1card2, int p1card3, string p1sym1, string p1sym2, string p1sym3, int p2card1, int p2card2, int p2card3, string p2sym1, string p2sym2, string p2sym3, int balance, int expectedBalance)
//         {
//             var sut = new Pokdeng();
//             sut.PlayerBalance = balance;
//             sut.CheckGameResult(bet, p1card1, p1card2, p1card3, p1sym1, p1sym2, p1sym3, p2card1, p2card2, p2card3, p2sym1, p2sym2, p2sym3);
//             Assert.Equal(expectedBalance, sut.PlayerBalance);
//         }

//         [Theory(DisplayName = "(ไพ่ป๊อกเด้ง) ผู้เล่นแพ้เจ้ามือ เจ้ามือได้แต้ม >=8 ในไพ่'สองใบแรก'ก่อน && ผู้เล่น <8 -เสียเงินเท่ากับที่เดิมพัน")]
//         [InlineData(200, 3, 5, 0, diamond, diamond, diamond, 4, 2, 1, spade, spade, spade, 1000, 600)]
//         //ผู้เล่นแพ้เจ้ามือ ผู้เล่นได้แต้ม <8 เจ้ามือได้แต้ม 8 && เป็นเลขเดียวกัน(4,4),(9,9) -เสียเงินเดิมพันเพิ่ม 2เท่า
//         [InlineData(200, 4, 4, 0, diamond, club, diamond, 4, 2, 0, spade, spade, spade, 1000, 600)]
//         [InlineData(200, 9, 9, 0, diamond, club, diamond, 4, 4, 0, spade, club, spade, 1000, 1000)] //เสมอ
//         public void Playerlose_Pokdeng(int bet, int p1card1, int p1card2, int p1card3, string p1sym1, string p1sym2, string p1sym3, int p2card1, int p2card2, int p2card3, string p2sym1, string p2sym2, string p2sym3, int balance, int expectedBalance)
//         {
//             var sut = new Pokdeng();
//             sut.PlayerBalance = balance;
//             sut.CheckGameResult(bet, p1card1, p1card2, p1card3, p1sym1, p1sym2, p1sym3, p2card1, p2card2, p2card3, p2sym1, p2sym2, p2sym3);
//             Assert.Equal(expectedBalance, sut.PlayerBalance);
//         }
    }
}




//         // **Normal cases
//         //==ไพ่สอง หรือ สามใบ ทั้งผู้เล่นและเจ้ามือ
//         //==ผู้เล่นชนะเจ้ามือ ผู้เล่นได้แต้ม'มากกว่า'เจ้ามือ -ได้เงินเท่ากับที่เดิมพัน
//         //==ผู้เล่นแพ้เจ้ามือ ผู้เล่นได้แต้ม'น้อยกว่า'เจ้ามือ -เสียเงินเท่ากับที่เดิมพัน
//         //==ผู้เล่นเสมอเจ้ามือ ผู้เล่นได้แต้ม'เท่ากับ'เจ้ามือ -ไม่เสียเงินเดิมพัน

// // **Alternative cases
// //(2เด้ง)
// //==ผู้เล่นชนะเจ้ามือ ผู้เล่นได้แต้ม'มากกว่า'เจ้ามือ && เป็นดอกเดียวกัน ||เป็นเลขเดียวกัน -ได้เงินเดิมพันเพิ่ม 2เท่า
// //==ผู้เล่นแพ้เจ้ามือ ผู้เล่นได้แต้ม'น้อยกว่า'เจ้ามือ && ไพ่เจ้ามือเป็นดอกเดียวกัน ||เป็นเลขเดียวกัน -เสียเงินเดิมพันเพิ่ม 2เท่า
// //==ผู้เล่นเสมอเจ้ามือ ผู้เล่นได้แต้ม'เท่ากับ'เจ้ามือ -ไม่เสียเงินเดิมพัน

// //(3เด้ง)
// //==ผู้เล่นชนะเจ้ามือ ผู้เล่นได้แต้ม'มากกว่า'เจ้ามือ && เป็นดอกเดียวกัน -ได้เงินเดิมพันเพิ่ม 3เท่า
// //ผู้เล่นชนะเจ้ามือ ผู้เล่นได้แต้ม'มากกว่า'เจ้ามือ && เป็นเลขเดียวกัน -ได้เงินเดิมพันเพิ่ม 3เท่า
// //==ผู้เล่นแพ้เจ้ามือ ผู้เล่นได้แต้ม'น้อยกว่า'เจ้ามือ && เป็นดอกเดียวกัน -เสียเงินเดิมพันเพิ่ม 3เท่า
// //==ผู้เล่นเสมอเจ้ามือ ผู้เล่นได้แต้ม'เท่ากับ'เจ้ามือ -ไม่เสียเงินเดิมพัน

// //ไพ่ป๊อก (ฝ่ายใดฝ่ายหนึ่ง 'ป๊อก' จะไม่สนไพ่ใบที่3 )
// //==ผู้เล่นชนะเจ้ามือ ผู้เล่นได้แต้ม >=8 ในไพ่'สองใบแรก'ก่อน && เจ้ามือ <8 -ได้เงินเท่ากับที่เดิมพัน
// //==ผู้เล่นแพ้เจ้ามือ เจ้ามือได้แต้ม >=8 ในไพ่'สองใบแรก'ก่อน && ผู้เล่น <8 -เสียเงินเท่ากับที่เดิมพัน
// //==ผู้เล่นเสมอเจ้ามือ ผู้เล่นได้แต้ม >=8 ในไพ่'สองใบแรก'ก่อน && เจ้ามือ >=8 -ไม่เสียเงินเดิมพัน


// //ไพ่ป๊อก(เด้ง (ฝ่ายใดฝ่ายหนึ่ง 'ป๊อก' จะไม่สนไพ่ใบที่3 ))
// //==ผู้เล่นชนะเจ้ามือ ผู้เล่นได้แต้ม >=8 && เป็นดอกเดียวกัน เจ้ามือได้ <8 -ได้เงินเดิมพันเพิ่ม 2เท่า
// //==ผู้เล่นชนะเจ้ามือ ผู้เล่นได้แต้มเท่ากับ 8 && เป็นเลขเดียวกัน(4,4),(9,9) โดยเจ้ามือได้ <8 -ได้เงินเดิมพันเพิ่ม 2เท่า
// //==ผู้เล่นแพ้เจ้ามือ ผู้เล่นได้แต้ม <8 เจ้ามือได้แต้ม >=8 && เป็นดอกเดียวกัน -เสียเงินเดิมพันเพิ่ม 2เท่า
// //==ผู้เล่นแพ้เจ้ามือ ผู้เล่นได้แต้ม <8 เจ้ามือได้แต้ม 8 && เป็นเลขเดียวกัน(4,4),(9,9) -เสียเงินเดิมพันเพิ่ม 2เท่า
// //==ผู้เล่นเสมอเจ้ามือ ผู้เล่นได้แต้ม >=8 'เท่ากับ' เจ้ามือ -ไม่เสียเงินเดิมพัน
// //TODO: ผู้เล่นเสมอเจ้ามือ ผู้เล่นได้แต้ม >9 'เท่ากับ' เจ้ามือ -ไม่เสียเงินเดิมพัน

// // **Exception cases
// // ผู้เล่นลงเงิน'เกิน'ที่ตัวเองมี ระบบแจ้งเตือนข้อผิดพลาด และยกเลิกการเล่นในรอบนั้นไป
// // ผู้เล่นมีเงินไม่พอจ่าย ระบบแจ้งเตือนข้อผิดพลาด และยกเลิกการเล่นในรอบนั้นไป
// // ผู้เล่นลงเงินไม่ถูกต้อง ระบบแจ้งเตือนข้อผิดพลาด และยกเลิกการเล่นในรอบนั้นไป
// // **ฝ่ายไหนได้ไพ่ป๊อก ผู้เล่นมีไพ่ 3 ใบ ระบบจะคำนวณแค่ไพ่ 2 ใบแรกของผู้เล่น
// // ได้รับไพ่ที่ไม่ถูกต้อง ระบบแจ้งเตือนข้อผิดพลาด และยกเลิกการเล่นในรอบนั้นไป
// // TODO: J Q K A ยังไม่ถูกกำหนดค่า && เลขมากกว่า 9 ยังไม่ได้ mod