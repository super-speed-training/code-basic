using System;
using Xunit;

namespace CodeBasic.Tests
{
    public class UnitTest1
    {
        // Normal cases
        // Alternative cases
        // Exception cases

        [Theory]
        [InlineData(100,4,5,3,4,1000,1100)]
        [InlineData(100,6,3,7,1,1000,1200)]
        //  [InlineData(100,4,4,3,4,1000,1100)]
        // [InlineData(100,9,9,7,1,1000,1200)]


        public void SumCardP1PokWin (int betAmount,int p1CardNo1, int p1CardNo2,
         int p2CardNo1, int p2CardNo2,int Balance, int excepted)
        {
           var a = new Pokdeng();
           a.PlayerBalance = Balance;
           a.CheckGameResult(
             betAmount,
             p1CardNo1, p1CardNo2, 0,
            string.Empty, string.Empty, string.Empty ,
             p2CardNo1, p2CardNo2, 0,
            string.Empty, string.Empty, string.Empty);
            

        }
    }
}
