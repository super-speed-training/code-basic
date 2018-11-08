using System;

namespace CodeBasic
{
    public class PokdengInfo
    {
        public enum PlayerResult
        {
            Pok9 = 0,
            Pok8 = 1,
            Tong = 2,
            Ghost = 3,
            Set = 4,
            Normal = 5,

            Pok9Twobounce = 10,
            Pok8Twobounce = 11,
            GhostThreeBounce = 13,
            SetThreeBounce = 14,

            Twobounce = 20,
            ThreeBounce = 21
        }

        public class Symbol
        {
            public const string Club = "Club";
            public const string Diamond = "Diamond";
            public const string Heart = "Heart";
            public const string Spade = "Spade";
        }

        public class GameResult
        {
            public const string Player1Win = "Player1Win";
            public const string Player2Win = "Player2Win";
            public const string Draw = "Draw";
            public const string Error = "System Error";
        }
    }
}
