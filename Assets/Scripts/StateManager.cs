public static class StateManager
{
        public static int PreviousScore { get; private set; }
        
        public static int HighScore { get; private set; }

        public static void SetScore(int score)
        {
                PreviousScore = score;

                if (score > HighScore)
                {
                        HighScore = score;
                }
        }
}