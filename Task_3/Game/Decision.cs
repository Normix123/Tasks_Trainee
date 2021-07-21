namespace Game
{
    internal class Decision
    {
        private static bool? _IsPlayerWin;
        private static int _CountOfPositions;

        private Decision(bool? hasPlayerWon)
        {
            _IsPlayerWin = hasPlayerWon;
        }


        public static Decision Decide<T>(T player, T computer, int count) where T : System.Enum
        {
            return Decide((int)(object)player, (int)(object)computer, count);
        }

        public static Decision Decide(int player, int computer, int count)
        {
            _CountOfPositions = count;
            FindWinningRule(player, computer);
            return new Decision(_IsPlayerWin);
        }

        private static void FindWinningRule(int player, int opponent)
        {
            if (player == opponent) return;
            for (var i = 0; i < _CountOfPositions / 2 + 1; i++)
                if ((player + i) % _CountOfPositions == opponent)
                {
                    _IsPlayerWin = true;
                    return;
                }

            _IsPlayerWin = false;
        }

        public override string ToString()
        {
            if (_IsPlayerWin == null)
                return "The same!";
            if (_IsPlayerWin == true)
                return "You win!";
            return "You lose!";
        }
    }
}