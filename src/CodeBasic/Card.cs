namespace CodeBasic
{
    public class Card
    {
        public Card(int number, CardType type)
        {
            CardType = type;
            Number = number;
        }

        public CardType CardType { get; set; }
        // A = 1, 2, ..., 10, J = 11, Q = 12, K = 13
        public int Number { get; set; }
    }
}