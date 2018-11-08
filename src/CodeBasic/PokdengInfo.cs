using System;

namespace CodeBasic
{
    public class PokdengInfo
    {
        public enum PlayerResult
        {
            Pok9,
            Pok9Twobounce = 0,
            Pok8,
            Pok8Twobounce = 1,
            Tong,
            Ghost,
            GhostThreeBounce = 3,
            Set,
            SetThreeBounce = 5,
            Normal,
            Twobounce = 8,
            ThreeBounce = 8
        }

        public class Symbol
        {
            public const string Club = "Club";
            public const string Diamond = "Diamond";
            public const string Heart = "Heart";
            public const string Spade = "Spade";
        }
    }
}
