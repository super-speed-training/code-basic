using System;

namespace CodeBasic
{
    public class PokdengInfo
    {
        public enum PlayerResult
        {
            Pok9,
            Pok8,
            Tong,
            Ghost,
            Set,
            Normal,
            Twobounce,
            ThreeBounce,

            Pok9Twobounce = 10,
            Pok8Twobounce = 11,
            GhostThreeBounce = 13,
            SetThreeBounce = 14,
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
