public static class StateManager
{
        public static int LastScore { get; private set; }
        
        public static int HighScore { get; private set; }

        public static void SetScore(int score)
        {
                LastScore = score;

                if (score > HighScore)
                {
                        HighScore = score;
                }
        }
}