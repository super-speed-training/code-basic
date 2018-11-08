using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBasic
{
    public class Pokdeng
    {
        static private int _Balance;

        public Pokdeng(int p1 = 0) => _Balance = p1;

        public int PlayerBalance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }

        static bool IsMoreThanTen(int a) => (a > 10);

        static int ModByTen(int a) => (a % 10);

        static bool IsBothPoks(int a, int b) => IsPok(a) && IsPok(b);

        static bool IsPok(int a) => (a == 8 || a == 9);

        static bool IsP1Win(int p1, int p2) => p1 > p2;

        static bool IsJQK(int no1, int no2, int no3) => (no1 == 11) && (no2 == 12) && (no3 == 13);

        static bool IsSameCards (int a, int b) => a == b;

        static bool IsSameOfThreeCards(int c1, int c2, int c3) => IsSameCards(c1, c2) && IsSameCards(c1, c3) && IsSameCards(c2, c3);

        static bool IsConsecutive(int c1, int c2, int c3)
        {
            for (int i = 1; i <= 7; i++)
            {
                if (i == c1 && (i+1) == c2 && (i+2) == c3)
                {
                    return true;
                }
            }
            return false;
        }

        static int totalSum(int CardNo1, int CardNo2, int CardNo3)
        {
            int Sum = 0;
            if (!IsMoreThanTen(CardNo1))
            {
                Sum += CardNo1;
            }
            if (!IsMoreThanTen(CardNo2))
            {
                Sum = Sum + CardNo2;
                if (IsMoreThanTen(Sum))
                {
                    Sum = ModByTen(Sum);
                }
            }
            if (!IsMoreThanTen(CardNo3))
            {
                Sum = Sum + CardNo3;
                if (IsMoreThanTen(Sum))
                {
                    Sum = ModByTen(Sum);
                }
            }
            return Sum;
        }

        public void CheckGameResult(
            int p1BetAmount, int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2BetAmount, int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            if (!((5*p1BetAmount) <= _Balance))
            {
                return;
            }
            bool p1flag = false;
            int Player1Sum = totalSum(p1CardNo1, p1CardNo2, p1CardNo3);
            int Player2Sum = totalSum(p2CardNo1, p2CardNo2, p2CardNo3);
            if (IsBothPoks(Player1Sum, Player2Sum) || Player1Sum == Player2Sum)
            {
                return;
            }
            else if (IsPok(Player1Sum))
            {
                if ((IsSameCards(p1CardNo1, p1CardNo2)) || (p1CardSymbol1.Equals(p1CardSymbol2)))
                {
                    _Balance -= (p1BetAmount*2);
                }
                else
                {
                    _Balance -= p1BetAmount;
                }
                p1flag = true;
                return;
            }
            else if (IsPok(Player2Sum))
            {
                if ((IsSameCards(p2CardNo1, p2CardNo2)) || (p2CardSymbol1.Equals(p2CardSymbol2)))
                {
                    _Balance += (p2BetAmount*2);
                }
                else
                {
                    _Balance += p2BetAmount;
                }
                p1flag = false;
                return;
            }
            else
            {
                p1flag = IsP1Win(Player1Sum, Player2Sum);
            }
            if (IsSameOfThreeCards(p1CardNo1, p1CardNo2, p1CardNo3))
            {
                _Balance -= (5*p1BetAmount);
                return;
            }
            else if (IsSameOfThreeCards(p2CardNo1, p2CardNo2, p2CardNo3))
            {
                _Balance += (5*p2BetAmount);
                return;
            }
            if (IsJQK(p1CardNo1, p1CardNo2, p1CardNo3))
            {
                _Balance -= (3*p1BetAmount);
                return;
            }
            else if (IsJQK(p2CardNo1, p2CardNo2, p2CardNo3))
            {
                _Balance += (3*p2BetAmount);
                return;
            }
            if (IsConsecutive(p1CardNo1, p1CardNo2, p1CardNo3))
            {
                _Balance -= (3*p1BetAmount);
                return;
            }
            else if (IsConsecutive(p2CardNo1, p2CardNo2, p2CardNo3))
            {
                _Balance += (3*p2BetAmount);
                return;
            }
            if (p1flag)
            {
                if (p2CardSymbol1.Equals(p2CardSymbol2) && p2CardSymbol2.Equals(p2CardSymbol3))
                {
                    _Balance -= (p2BetAmount*3);
                    return;
                }
                if ((IsSameCards(p1CardNo1, p1CardNo2)) || (p1CardSymbol1.Equals(p1CardSymbol2)))
                {
                    _Balance -= (p1BetAmount*2);
                    return;
                }
                else
                {
                    _Balance -= p1BetAmount;
                    return;
                }
            }
            else
            {
                if (p2CardSymbol1.Equals(p2CardSymbol2) && p2CardSymbol2.Equals(p2CardSymbol3))
                {
                    _Balance += (p2BetAmount*3);
                    return;
                }
                if ((IsSameCards(p2CardNo1, p2CardNo2)) || (p2CardSymbol1.Equals(p2CardSymbol2)))
                {
                    _Balance += (p2BetAmount*2);
                    return;
                }
                else
                {
                    _Balance += p2BetAmount;
                    return;
                }
            }
        }
    }
}
