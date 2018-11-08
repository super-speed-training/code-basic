using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBasic
{
    public class Pokdeng
    {
        private bool IsPok8(int p1CardNo1, int p1CardNo2, int p1CardNo3) => p1CardNo1 + p1CardNo2 == 8 && p1CardNo3 == 0;
        private bool IsPog9(int p1CardNo1, int p1CardNo2, int p1CardNo3) => p1CardNo1 + p1CardNo2 == 9 && p1CardNo3 == 0;
        private bool IsTong(int p1CardNo1, int p1CardNo2, int p1CardNo3) => p1CardNo1 == p1CardNo2 && p1CardNo2 == p1CardNo3;
        private bool IsGhost(int p1CardNo1, int p1CardNo2, int p1CardNo3) => Enumerable.Range(11, 13).Contains(p1CardNo1) && Enumerable.Range(11, 13).Contains(p1CardNo2) && Enumerable.Range(11, 13).Contains(p1CardNo3);

        private bool IsSet(int p1CardNo1, int p1CardNo2, int p1CardNo3)
        {
            var cardList = new List<int> { p1CardNo1, p1CardNo2, p1CardNo3 };
            cardList = cardList.OrderBy(it => it).ToList();
            return cardList[2] - cardList[1] == 1 && cardList[1] - cardList[0] == 1;
        }

        private bool IsTwobounce(int p1CardNo1, int p1CardNo2, int p1CardNo3, string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3)
        {
            return (p1CardNo1 == p1CardNo2 || p1CardSymbol1 == p1CardSymbol2) && p1CardNo3 == 0 && p1CardSymbol3 == "";
        }

        private bool IsThreeBounce(string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3)
        {
            return p1CardSymbol1 == p1CardSymbol2 && p1CardSymbol2 == p1CardSymbol3;
        }

        public int PlayerBalance { get; set; }

        public void CheckGameResult(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            throw new NotImplementedException();
        }

        public bool Playable(int playerBet)
        {
            return playerBet * 5 <= PlayerBalance && playerBet > 0 && PlayerBalance > 0;
        }

        public PokdengInfo.PlayerResult GetRewardType(int p1CardNo1, int p1CardNo2, int p1CardNo3, string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3)
        {

        }
    }
}