namespace BowlingGame
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll;

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int Score()
        {
            int score = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (rolls[roll] == 10) // strike
                {
                    score += 10 + rolls[roll + 1] + rolls(roll + 2);
                    roll += 2;
                }
                if (IsSpare(roll))
                {
                    score += 10 + rolls[roll + 2];
                }
                else
                {
                    score += rolls[roll] + rolls[roll + 1];
                }
                roll += 2;
            }

            return score;
        }

        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }
    }
}