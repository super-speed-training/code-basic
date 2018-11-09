using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBasic
{
    public class Pokdeng
    {
        private string winMethod;
        private string winner;

        public int PlayerBalance { get; set; }
        private List<PlayerCard> p1Cards { get; set; }
        private List<PlayerCard> p2Cards { get; set; }
        private class PlayerCard
        {
            public int CardNumber { get; set; }
            public string CardFlowers { get; set; }
        }

        // Club, Diamond, Heart, Spade (case sensitive)
        public void CheckGameResult(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            p1Cards = new List<PlayerCard>
            {
                new PlayerCard { CardNumber = p1CardNo1, CardFlowers = p1CardSymbol1 },
                new PlayerCard { CardNumber = p1CardNo2, CardFlowers = p1CardSymbol2 },
                new PlayerCard { CardNumber = p1CardNo3, CardFlowers = p1CardSymbol3 },
            };
            var p1Score = p1Cards.Sum(x => x.CardNumber);

            p2Cards = new List<PlayerCard>
            {
                new PlayerCard { CardNumber = p2CardNo1, CardFlowers = p2CardSymbol1 },
                new PlayerCard { CardNumber = p2CardNo2, CardFlowers = p2CardSymbol2 },
                new PlayerCard { CardNumber = p2CardNo3, CardFlowers = p2CardSymbol3 },
            };
            var p2Score = p2Cards.Sum(x => x.CardNumber);

            var isP1Pok = checkPok(p1Cards, p1Score);
            var isP2Pok = checkPok(p2Cards, p2Score); 
            var isP1ThreeSame = checkThreeSame(p1Cards);
            var isP2ThreeSame = checkThreeSame(p2Cards);
            var isP1Ghost = checkGhost(p1Cards);
            var isP2Ghost = checkGhost(p2Cards);
            var isP1Straight = checkStraight(p1Cards);
            var isP2Straight = checkStraight(p2Cards);

            //Pok
            if (isP1Pok && !isP2Pok)
            {
                //house always win
                winner = "house";
                winMethod = "pok";
            }
            else if (isP1Pok && isP2Pok)
            {
                winner = p1Score > p2Score ? "house" : "player";
                winMethod = "pok";
            }
            else if (!isP1Pok && isP2Pok)
            {
                winner = "player";
                winMethod = "pok";
            }
            //ThreeSame
            else
            {
                if (isP1ThreeSame && isP2ThreeSame)
                {
                    winner = p1Score > p2Score ? "house" : "player";
                    winMethod = "threesame";
                }
                else if (isP1ThreeSame || isP2ThreeSame)
                {
                    winner = isP1ThreeSame ? "house" : "player";
                    winMethod = "threesame";
                }
                //Ghost
                else if (isP1Ghost && isP2Ghost)
                {
                    winner = p1Score > p2Score ? "house" : "player";
                    winMethod = "ghost";
                }
                else if (isP1Ghost)
                {
                    winner = "house";
                    winMethod = "ghost";
                }
                else if (isP2Ghost)
                {
                    winner = "player";
                    winMethod = "ghost";
                }
                //Straight
                else if (isP1Straight && isP2Straight)
                {
                    winner = p1Score > p2Score ? "house" : "player";
                    winMethod = "straight";
                }
                else if (isP1Straight)
                {
                    winner = "house";
                    winMethod = "straight";
                }
                else if (isP2Straight)
                {
                    winner = "player";
                    winMethod = "straight";
                }
                //Double
                //Triple

                //Normal
                else if (p1Score > p2Score)
                {
                    winner = "house";
                    winMethod = "normal";
                }
                else if (p1Score < p2Score)
                {
                    winner = "player";
                    winMethod = "normal";
                }
            }
            calculateBalance(betAmount, winner);
        }
        private bool checkPok(List<PlayerCard> playerCards, int playerScore)
        {
            return playerCards.Count() == 2 && playerScore >= 8;
        }
        private bool checkThreeSame(List<PlayerCard> playerCards)
        {
            return playerCards.Count() == 3 && playerCards.GroupBy(x => x.CardNumber).FirstOrDefault().Count() == 3;
        }

        private bool checkGhost(List<PlayerCard> playerCards)
        {
            return playerCards.All(x => x.CardNumber == 10 || x.CardNumber == 11 || x.CardNumber == 12);
        }

        private bool checkStraight(List<PlayerCard> playerCards)
        {
            var ord = playerCards.OrderBy(x => x.CardNumber).ToArray();
            for (int i = 0; i < ord.Count() - 1; i++)
            {
                if (Math.Abs(ord[i].CardNumber - ord[i + 1].CardNumber) == 1 )
                { }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void calculateBalance(int betAmount, string winner)
        {
            switch (winner)
            {
                case "house":
                    PlayerBalance -= betAmount * winnerMultiply(p1Cards, winMethod);
                    break;
                case "player":
                    PlayerBalance += betAmount * winnerMultiply(p2Cards, winMethod);
                    break;
                default:
                    break;
            }
        }

        private int winnerMultiply(List<PlayerCard> playerCards, string winMethod)
        {
            var sameFlowers = playerCards.Select(x => x.CardFlowers).GroupBy(x => x).Where(x => x.Count() > 1).FirstOrDefault();
            var sameNumber = playerCards.Select(x => x.CardNumber).GroupBy(x => x).Where(x => x.Count() > 1).FirstOrDefault();
            var multiply = 0;
            switch (winMethod)
            {
                case "pok":
                case "normal":
                    if (sameFlowers != null)
                    {
                        multiply = sameFlowers.Count();
                    }
                    else if (sameNumber != null)
                    {
                        multiply = sameNumber.Count();
                    }
                    else
                    {
                        multiply = 1;
                    }
                    break;
                case "ghost":
                case "straight":
                    multiply = 3;
                    break;
                case "threesame":
                        multiply = 5;
                    break;
                default:
                    break;
            }
            return multiply;
        }
    }
}
