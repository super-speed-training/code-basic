using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodeBasic
{
    public class Pokdeng
    {
        public int PlayerBalance { get; set; }

        // Club, Diamond, Heart, Spade (case sensitive)
        public void CheckGameResult(
            int betAmount,
            int p1CardNo1,
            int p1CardNo2,
            int p1CardNo3,
            string p1CardSymbol1,
            string p1CardSymbol2,
            string p1CardSymbol3,
            int p2CardNo1,
            int p2CardNo2,
            int p2CardNo3,
            string p2CardSymbol1,
            string p2CardSymbol2,
            string p2CardSymbol3)
        {
            PlayerBalance = 0;
            var BankerCard = CreateCards(p1CardNo1, p1CardNo2, p1CardNo3, p1CardSymbol1, p1CardSymbol2, p1CardSymbol3);
            var PlayerCard = CreateCards(p2CardNo1, p2CardNo2, p2CardNo3, p2CardSymbol1, p2CardSymbol2, p2CardSymbol3);
            var BankerRank = GetRank(BankerCard);
            var PlayerRank = GetRank(PlayerCard);
            int BankerScore;
            int PlayerScore;

            switch (BankerCard.Length)
            {
                case 2:
                    BankerScore = (BankerCard[0].Point + BankerCard[1].Point) % 10;
                    break;
                default:
                    BankerScore = (BankerCard[0].Point + BankerCard[1].Point + BankerCard[2].Point) % 10;
                    break;
            }

            switch (PlayerCard.Length)
            {
                case 2:
                    PlayerScore = PlayerCard[0].Point + PlayerCard[1].Point;
                    break;
                default:
                    PlayerScore = PlayerCard[0].Point + PlayerCard[1].Point + PlayerCard[2].Point;
                    break;
            }

            // Bank Pok
            if (BankerRank == ScoreRank.Pok && (PlayerCard.Length > 2 || PlayerRank == ScoreRank.Score))
            {
                if (BankerCard[0].CardType == BankerCard[1].CardType || BankerCard[0].Point == BankerCard[1].Point)
                {
                    PlayerBalance = PlayerBalance - (betAmount * 2);
                }
                else
                {
                    PlayerBalance = PlayerBalance - betAmount;
                }

            }

            // Player Pok
            else if (PlayerRank == ScoreRank.Pok && (BankerCard.Length > 2 || BankerRank == ScoreRank.Score))
            {
                if (PlayerCard[0].CardType == PlayerCard[1].CardType || PlayerCard[0].Point == PlayerCard[1].Point)
                {
                    PlayerBalance = PlayerBalance + (betAmount * 2);
                }
                else
                {
                    PlayerBalance = PlayerBalance + betAmount;
                }

            }

            // Banker & Player Pok
            else if (PlayerRank == ScoreRank.Pok && BankerRank == ScoreRank.Pok)
            {
                if (PlayerScore > BankerScore)
                {
                    if (PlayerCard[0].CardType == PlayerCard[1].CardType || PlayerCard[0].Point == PlayerCard[1].Point)
                    {
                        PlayerBalance = PlayerBalance + (betAmount * 2);
                    }
                    else
                    {
                        PlayerBalance = PlayerBalance + betAmount;
                    }
                }
                else if (BankerScore > PlayerScore)
                {
                    if (BankerCard[0].CardType == BankerCard[1].CardType || BankerCard[0].Point == BankerCard[1].Point)
                    {
                        PlayerBalance = PlayerBalance - (betAmount * 2);
                    }
                    else
                    {
                        PlayerBalance = PlayerBalance - betAmount;
                    }
                }
                else
                {
                    PlayerBalance = PlayerBalance;
                }
            }

            // Banker & Player are Three
            else if (BankerRank == ScoreRank.Three && PlayerRank != ScoreRank.Tripple)
            {
                PlayerBalance = PlayerBalance - (betAmount * 5);
            }
            else if (PlayerRank == ScoreRank.Three && BankerRank != ScoreRank.Tripple)
            {
                PlayerBalance = PlayerBalance + (betAmount * 5);
            }
            else if (BankerRank == ScoreRank.Three && PlayerRank == ScoreRank.Three)
            {
                PlayerBalance = PlayerBalance;
            }

            // Banker & Player are Ghost
            else if (BankerRank == ScoreRank.Ghost && PlayerRank != ScoreRank.Ghost)
            {
                PlayerBalance = PlayerBalance - (betAmount * 3);
            }
            else if (PlayerRank == ScoreRank.Ghost && BankerRank != ScoreRank.Ghost)
            {
                PlayerBalance = PlayerBalance + (betAmount * 3);
            }
            else if (BankerRank == ScoreRank.Ghost && PlayerRank == ScoreRank.Ghost)
            {
                PlayerBalance = PlayerBalance;
            }

            // Banker & Player are Sequence
            else if (BankerRank == ScoreRank.Sequence && PlayerRank != ScoreRank.Sequence)
            {
                PlayerBalance = PlayerBalance - (betAmount * 3);
            }
            else if (PlayerRank == ScoreRank.Sequence && BankerRank != ScoreRank.Sequence)
            {
                PlayerBalance = PlayerBalance + (betAmount * 3);
            }
            else if (BankerRank == ScoreRank.Sequence && PlayerRank == ScoreRank.Sequence)
            {
                PlayerBalance = PlayerBalance;
            }

            else if (BankerScore > PlayerScore)
            {
                if (BankerRank == ScoreRank.Tripple)
                {
                    PlayerBalance = PlayerBalance - (betAmount * 3);
                }
                else if (BankerRank == ScoreRank.Double)
                {
                    PlayerBalance = PlayerBalance - (betAmount * 2);
                }
                else
                {
                    PlayerBalance = PlayerBalance - (betAmount);
                }
            }
            else if (PlayerScore > BankerScore)
            {
                if (PlayerRank == ScoreRank.Tripple)
                {
                    PlayerBalance = PlayerBalance + (betAmount * 3);
                }
                else if (PlayerRank == ScoreRank.Double)
                {
                    PlayerBalance = PlayerBalance + (betAmount * 2);
                }
                else
                {
                    PlayerBalance = PlayerBalance + (betAmount);
                }
            }


        }

        public Card[] CreateCards(
            int cardNo1,
            int cardNo2,
            int cardNo3,
            string cardSymbol1,
            string cardSymbol2,
            string cardSymbol3)
        {
            var card = new List<Card>();
            int[] Point = new int[] { cardNo1, cardNo2, cardNo3 };
            string[] Sym = new String[] { cardSymbol1, cardSymbol2, cardSymbol3 };

            for (int i = 0; i < Point.Length; i++)
            {
                if (Point[i] != 0 && Sym[i] != "")
                {
                    switch (Sym[i])
                    {
                        case "Club":
                            card.Add(new Card(Point[i], CardType.Club));
                            break;
                        case "Diamond":
                            card.Add(new Card(Point[i], CardType.Diamond));
                            break;
                        case "Heart":
                            card.Add(new Card(Point[i], CardType.Heart));
                            break;
                        default:
                            card.Add(new Card(Point[i], CardType.Spade));
                            break;
                    }
                }
            }
            return card.ToArray();
        }

        public ScoreRank GetRank(Card[] Card)
        {
            if (Card.Length == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (Card[i].Point >= 10)
                    {
                        Card[i].Point = 0;
                    }
                }
                if (Card[0].Point + Card[1].Point >= 8)
                {
                    return ScoreRank.Pok;
                }
                if (Card[0].Point == Card[1].Point || Card[0].CardType == Card[1].CardType)
                {
                    return ScoreRank.Double;
                }
                return ScoreRank.Score;
            }
            else
            {
                if (Card[0].Point == Card[1].Point && Card[1].Point == Card[2].Point)
                {
                    return ScoreRank.Three;
                }
                if (Card[0].Point > 10 && Card[1].Point > 10 && Card[2].Point > 10)
                {
                    return ScoreRank.Ghost;
                }

                Card = Card.OrderBy(it => it.Point).ToArray();
                if (Card[0].Point == Card[1].Point - 1 && Card[1].Point == Card[2].Point - 1)
                {
                    return ScoreRank.Sequence;
                }
                if (Card[0].CardType == Card[1].CardType && Card[1].CardType == Card[2].CardType)
                {
                    return ScoreRank.Tripple;
                }
                return ScoreRank.Score;
            }
        }
    }
}
