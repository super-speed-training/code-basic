using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBasic
{
    public class Pokdeng
    {
        #region Result condition

        private bool IsPok8(int cardNo1, int cardNo2, int cardNo3)
        {
            cardNo1 = cardNo1 >= 10 ? 0 : cardNo1;
            cardNo2 = cardNo2 >= 10 ? 0 : cardNo2;
            return cardNo1 + cardNo2 == 8 && cardNo3 == 0;
        }

        private bool IsPog9(int cardNo1, int cardNo2, int cardNo3)
        {
            cardNo1 = cardNo1 >= 10 ? 0 : cardNo1;
            cardNo2 = cardNo2 >= 10 ? 0 : cardNo2;
            return cardNo1 + cardNo2 == 9 && cardNo3 == 0;
        }

        private bool IsTong(int cardNo1, int cardNo2, int cardNo3) => cardNo1 == cardNo2 && cardNo2 == cardNo3;
        private bool IsGhost(int cardNo1, int cardNo2, int cardNo3) => Enumerable.Range(11, 13).Contains(cardNo1) && Enumerable.Range(11, 13).Contains(cardNo2) && Enumerable.Range(11, 13).Contains(cardNo3);

        private bool IsSet(int cardNo1, int cardNo2, int cardNo3)
        {
            var cardList = new List<int> { cardNo1, cardNo2, cardNo3 };
            cardList = cardList.OrderBy(it => it).ToList();
            return cardList[2] - cardList[1] == 1 && cardList[1] - cardList[0] == 1 && cardNo3 != 0;
        }

        private bool IsTwobounce(int cardNo1, int cardNo2, int cardNo3, string cardSymbol1, string cardSymbol2, string cardSymbol3)
        {
            return (cardNo1 == cardNo2 || cardSymbol1 == cardSymbol2) && cardNo3 == 0 && cardSymbol3 == "";
        }

        private bool IsThreeBounce(string cardSymbol1, string cardSymbol2, string cardSymbol3)
        {
            return cardSymbol1 == cardSymbol2 && cardSymbol2 == cardSymbol3;
        }

        #endregion Result condition

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

            var result = PokdengInfo.PlayerResult.Normal;

            if (IsPog9(p1CardNo1, p1CardNo2, p1CardNo3))
            {
                if (IsTwobounce(p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3))
                {
                    result = PokdengInfo.PlayerResult.Pok9Twobounce;
                }
                else result = PokdengInfo.PlayerResult.Pok9;
            }
            else if (IsPok8(p1CardNo1, p1CardNo2, p1CardNo3))
            {
                if (IsTwobounce(p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3))
                {
                    result = PokdengInfo.PlayerResult.Pok8Twobounce;
                }
                else result = PokdengInfo.PlayerResult.Pok8;
            }
            else if (IsTong(p1CardNo1, p1CardNo2, p1CardNo3))
            {
                result = PokdengInfo.PlayerResult.Tong;
            }
            else if (IsGhost(p1CardNo1, p1CardNo2, p1CardNo3))
            {
                if (IsThreeBounce(p1CardSymbol1, p1CardSymbol2, p1CardSymbol3))
                {
                    result = PokdengInfo.PlayerResult.GhostThreeBounce;
                }
                else result = PokdengInfo.PlayerResult.Ghost;
            }
            else if (IsSet(p1CardNo1, p1CardNo2, p1CardNo3))
            {
                if (IsThreeBounce(p1CardSymbol1, p1CardSymbol2, p1CardSymbol3))
                {
                    result = PokdengInfo.PlayerResult.SetThreeBounce;
                }
                else result = PokdengInfo.PlayerResult.Set;
            }
            else if (IsTwobounce(p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3)) result = PokdengInfo.PlayerResult.Twobounce;
            else if (IsThreeBounce(p1CardSymbol1, p1CardSymbol2, p1CardSymbol3)) result = PokdengInfo.PlayerResult.ThreeBounce;

            return result;
        }

        public string GetWinnerBySpecialResult(PokdengInfo.PlayerResult p1Result, PokdengInfo.PlayerResult p2Result)
        {
            p1Result = (int)p1Result >= 10 ? (PokdengInfo.PlayerResult)((int)p1Result - 10) : p1Result;
            p2Result = (int)p2Result >= 10 ? (PokdengInfo.PlayerResult)((int)p2Result - 10) : p2Result;

            if (p1Result < p2Result)
            {
                return PokdengInfo.GameResult.Player1Win;
            }
            else if (p2Result < p1Result)
            {
                return PokdengInfo.GameResult.Player2Win;
            }
            else return PokdengInfo.GameResult.Draw;
        }
    }
}