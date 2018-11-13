namespace CodeBasic
{
    public class Pokdeng
    {
        public int PlayerBalance { get; set; }

        // Club, Diamond, Heart, Spade (case sensitive)
        public void CheckGameResult(
            int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            var hostPoint = p1CardNo1 + p1CardNo2 + p1CardNo3;
            var playerPoint = p2CardNo1 + p2CardNo2 + p2CardNo3;

            var isPlayerWin = playerPoint > hostPoint;
            var isHostWin = playerPoint < hostPoint;

            var isSameNumber = p2CardNo1 == p2CardNo2;
            var isSameSymbol = p2CardSymbol1 == p2CardSymbol2;
            var isPlayerTwoDeng = isSameNumber || isSameSymbol;

            var isSameNumbers = p1CardNo1 == p1CardNo2;
            var isSameSymbols = p1CardSymbol1 == p1CardSymbol2;
            var isHostTwoDeng = isSameNumbers || isSameSymbols;

            var isDraw = playerPoint == hostPoint;
            if (isDraw) return;

            if (isPlayerWin)
            {
                if (isPlayerTwoDeng)
                {
                    PlayerBalance += betAmount * 2;
                }
                else
                {
                    PlayerBalance += betAmount;
                }
            }
            else if (isHostWin)
            {
                if (isHostTwoDeng)
                {
                    PlayerBalance -= betAmount * 2;
                }
                else
                {
                    PlayerBalance -= betAmount;
                }
            }
        }
        public void isPok(int betAmount,
            int p1CardNo1, int p1CardNo2, int p1CardNo3,
            string p1CardSymbol1, string p1CardSymbol2, string p1CardSymbol3,
            int p2CardNo1, int p2CardNo2, int p2CardNo3,
            string p2CardSymbol1, string p2CardSymbol2, string p2CardSymbol3)
        {
            var hostPok = p1CardNo1 + p1CardNo2 + p1CardNo3;
            var playerPoint = p2CardNo1 + p2CardNo2 + p2CardNo3;
            if (hostPok >=8)
            {
                PlayerBalance -= betAmount;
            }
        }
    }
}