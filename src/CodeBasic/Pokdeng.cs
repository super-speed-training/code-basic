using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeBasic
{

    public class Pokdeng
    {
        public int PlayerBalance { get; set; }

        public List<string> CardSymbol = new List<string> { "Club", "Diamond", "Heart", "Spade" };

        public enum HandType { ไม่มี, เรียง, ผี, ตอง, ป๊อก };
        public HandResult p1HandResult;

        public class Card
        {
            public int Number { get; set; }
            public string Symbol { get; set; }
        }

        public class HandResult
        {
            public HandType Hand { get; set; }
            public int Point { get; set; }
            public int BetReturnRate { get; set; }
        }

        // Club, Diamond, Heart, Spade (case sensitive)
        public void CheckGameResult(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            var deck = GetNewDeck();

            var haveCheat = false;
            haveCheat |= !CheckBalance(betAmount);
            haveCheat |= CheckCard(p1CardNo1, p1CardSymbol1, deck);
            haveCheat |= CheckCard(p1CardNo2, p1CardSymbol2, deck);
            if (p1CardNo3 != 0)
                haveCheat |= CheckCard(p1CardNo3, p1CardSymbol3, deck);
            haveCheat |= CheckCard(p2CardNo1, p2CardSymbol1, deck);
            haveCheat |= CheckCard(p2CardNo2, p2CardSymbol2, deck);
            if (p2CardNo3 != 0)
                haveCheat |= CheckCard(p2CardNo3, p2CardSymbol3, deck);

            if (!haveCheat)
            {
                var p1Hand = CalculateCardInHand(p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3);
                var p2Hand = CalculateCardInHand(p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);

                PlayerBalance += WinnerCalculator(p1Hand, p2Hand, betAmount);
            }
        }

        public bool CheckBalance(int betAmount)
        {
            return PlayerBalance >= betAmount * 5;
        }

        public Card GetRandomCard(List<Card> deck)
        {
            Random rnd = new Random();
            var r = rnd.Next(deck.Count);
            var Card = deck[r];
            deck.Remove(Card);
            return Card;
        }

        public bool CheckCard(int CardNo, string CardSymbol, List<Card> deck)
        {
            var haveCheat = !deck.Any(it => it.Number == CardNo && it.Symbol == CardSymbol);
            if (!haveCheat)
                deck.RemoveAll(it => it.Number == CardNo && it.Symbol == CardSymbol);
            return haveCheat;
        }

        public int WinnerCalculator(HandResult p1Hand, HandResult p2Hand, int betAmount)
        {
            var returnAmount = 0;
            var SameHandType = p1Hand.Hand == p2Hand.Hand && (p1Hand.Hand == HandType.ป๊อก || p1Hand.Hand == HandType.ไม่มี);
            var p1Win = p1Hand.Hand > p2Hand.Hand || (SameHandType && p1Hand.Point > p2Hand.Point);
            var p2Win = p1Hand.Hand < p2Hand.Hand || (SameHandType && p1Hand.Point < p2Hand.Point);
            if (p1Win)
            {
                returnAmount = betAmount * p1Hand.BetReturnRate * -1;
            }
            else if (p2Win)
            {
                returnAmount = betAmount * p2Hand.BetReturnRate;
            }

            return returnAmount;
        }

        public List<Card> GetNewDeck()
        {
            var type = new List<string> { "Club", "Diamond", "Heart", "Spade" };
            var deck = new List<Card>();
            foreach (var item in type)
            {
                for (int i = 1; i <= 13; i++)
                {
                    deck.Add(new Card { Number = i, Symbol = item });
                }
            }
            return deck;
        }

        public HandResult CalculateCardInHand(int CardNo1, int CardNo2, int CardNo3, string CardSymbol1, string CardSymbol2, string CardSymbol3)
        {
            var Result = new HandResult()
            {
                Hand = HandType.ไม่มี,
                BetReturnRate = 1,
                Point = PointCalculator(CardNo1, CardNo2, CardNo3)
            };

            if (CardNo3 == 0)
            {
                if (Result.Point > 7)
                    Result.Hand = HandType.ป๊อก;

                if (CardNo1 == CardNo2 || CardSymbol1 == CardSymbol2)
                    Result.BetReturnRate = 2;
            }
            else if (CardNo1 == CardNo2 && CardNo2 == CardNo3)
            {
                Result.Hand = HandType.ตอง;
                Result.BetReturnRate = 5;
            }
            else if (CardNo1 >= 11 && CardNo1 <= 13 && CardNo2 >= 11 && CardNo2 <= 13 && CardNo3 >= 11 && CardNo3 <= 13)
            {
                Result.Hand = HandType.ผี;
                Result.BetReturnRate = 3;
            }
            else
            {
                ReOrderCardInHand(ref CardNo1, ref CardNo2, ref CardNo3, ref CardSymbol1, ref CardSymbol2, ref CardSymbol3);
                if (CardNo1 + 1 == CardNo2 && CardNo2 + 1 == CardNo3)
                {
                    Result.Hand = HandType.เรียง;
                    Result.BetReturnRate = 3;
                }
                else
                {
                    if (CardSymbol1 == CardSymbol2 && CardSymbol2 == CardSymbol3)
                        Result.BetReturnRate = 3;
                }
            }

            return Result;
        }

        private void ReOrderCardInHand(ref int CardNo1, ref int CardNo2, ref int CardNo3, ref string CardSymbol1, ref string CardSymbol2, ref string CardSymbol3)
        {
            if (CardNo1 > CardNo2)
                SwitchCardInHand(ref CardNo1, ref CardNo2, ref CardSymbol1, ref CardSymbol2);

            if (CardNo2 > CardNo3)
            {
                SwitchCardInHand(ref CardNo2, ref CardNo3, ref CardSymbol2, ref CardSymbol3);
                if (CardNo1 > CardNo2)
                    SwitchCardInHand(ref CardNo1, ref CardNo2, ref CardSymbol1, ref CardSymbol2);
            }
        }

        private int PointCalculator(int CardNo1, int CardNo2, int CardNo3)
        {
            CardNo1 = CardNo1 > 10 ? 10 : CardNo1;
            CardNo2 = CardNo2 > 10 ? 10 : CardNo2;
            CardNo3 = CardNo3 > 10 ? 10 : CardNo3;

            return (CardNo1 + CardNo2 + CardNo3) % 10;
        }

        private void SwitchCardInHand(ref int CardNo1, ref int CardNo2, ref string CardSymbol1, ref string CardSymbol2)
        {
            var SwitchPoint = CardNo1;
            CardNo1 = CardNo2;
            CardNo2 = SwitchPoint;
            var SwitchType = CardSymbol1;
            CardSymbol1 = CardSymbol2;
            CardSymbol2 = SwitchType;
        }
    }
}
