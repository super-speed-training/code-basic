using System;
using Xunit;
using static CodeBasic.Pokdeng;

namespace CodeBasic.Tests
{
    public class PokdengTest
    {

        [Theory(DisplayName = "Point")]
        [InlineData(1, 2, 3, 6)]
        [InlineData(4, 3, 0, 7)]
        [InlineData(11, 4, 3, 7)]
        [InlineData(1, 5, 11, 6)]
        [InlineData(11, 12, 1, 1)]
        public void CheckPoint(int cardNo1, int cardNo2, int cardNo3, int expected)
        {
            var sut = new Pokdeng();
            var result = sut.SumCard(cardNo1, cardNo2, cardNo3);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "Pok")]
        [InlineData(4, 4, 0, true)]
        [InlineData(10, 9, 0, true)]
        [InlineData(8, 1, 0, true)]
        [InlineData(3, 7, 5, false)]
        [InlineData(3, 3, 3, false)]
        public void CheckPokg(int cardNo1, int cardNo2, int cardNo3, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsPokCheck(cardNo1, cardNo2, cardNo3);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "TwoDeng")]
        [InlineData(4, 4, Symbol.Club, Symbol.Heart, true)]
        [InlineData(3, 3, Symbol.Club, Symbol.Heart, true)]
        [InlineData(10, 9, Symbol.Heart, Symbol.Heart, true)]
        [InlineData(1, 3, Symbol.Spade, Symbol.Spade, true)]
        [InlineData(5, 4, Symbol.Heart, Symbol.Heart, true)]
        public void CheckTwoDeng(int cardNo1, int cardNo2, string cardNo1Symbol, string cardNo2Symbol, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsTwoDengCheck(cardNo1, cardNo2, cardNo1Symbol, cardNo2Symbol);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "ThreeDeng")]
        [InlineData(4, 1, 2, Symbol.Club, Symbol.Club, Symbol.Club, true)]
        [InlineData(3, 1, 3, Symbol.Club, Symbol.Heart, Symbol.Heart, false)]
        [InlineData(10, 2, 10, Symbol.Heart, Symbol.Heart, Symbol.Heart, true)]
        public void CheckThreeDeng(int cardNo1, int cardNo2, int cardNo3, string cardNo1Symbol, string cardNo2Symbol, string cardNo3Symbol, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsThreeDengCheck(cardNo1, cardNo2,cardNo3, cardNo1Symbol, cardNo2Symbol,cardNo3Symbol);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "Ghost")]
        [InlineData(10, 10, 10, Symbol.Club, Symbol.Club, Symbol.Club, false)]
        [InlineData(11, 11, 12, Symbol.Club, Symbol.Heart, Symbol.Heart, true)]
        [InlineData(11, 12, 13, Symbol.Heart, Symbol.Heart, Symbol.Heart, true)]
        [InlineData(8, 12, 13, Symbol.Heart, Symbol.Heart, Symbol.Heart, false)]
        [InlineData(10, 10, 13, Symbol.Heart, Symbol.Heart, Symbol.Heart, false)]
        public void CheckGhost(int cardNo1, int cardNo2, int cardNo3, string cardNo1Symbol, string cardNo2Symbol, string cardNo3Symbol, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsGhostCheck(cardNo1, cardNo2, cardNo3, cardNo1Symbol, cardNo2Symbol, cardNo3Symbol);
            Assert.Equal(expected, result);
        }

        [Theory(DisplayName = "Tong")]
        [InlineData(10, 10, 10, Symbol.Club, Symbol.Club, Symbol.Club, true)]
        [InlineData(11, 11, 12, Symbol.Club, Symbol.Heart, Symbol.Heart, false)]
        [InlineData(11, 12, 13, Symbol.Heart, Symbol.Heart, Symbol.Heart, false)]
        [InlineData(8, 12, 13, Symbol.Heart, Symbol.Heart, Symbol.Heart, false)]
        [InlineData(5, 5, 5, Symbol.Heart, Symbol.Heart, Symbol.Heart, true)]
        public void CheckTong(int cardNo1, int cardNo2, int cardNo3, string cardNo1Symbol, string cardNo2Symbol, string cardNo3Symbol, bool expected)
        {
            var sut = new Pokdeng();
            var result = sut.IsTongCheck(cardNo1, cardNo2, cardNo3, cardNo1Symbol, cardNo2Symbol, cardNo3Symbol);
            Assert.Equal(expected, result);
        }
    }
}
