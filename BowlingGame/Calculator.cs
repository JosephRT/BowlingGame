namespace BowlingGame
{
    class Calculator
    {
        private readonly int[] rolls;
        private const int BowlingGameFrames = 10;
        private const int MaxPinsPerFrame = 10;

        private Calculator(int[] rolls)
        {
            this.rolls = rolls;
        }

        public static Calculator GetRollCalculator(int[] rolls)
        {
            return new Calculator(rolls);
        }

        public void GetScoreForAllRollsInGame(ref int score)
        {
            var currentRoll = 0;

            for (var currentFrame = 0; currentFrame < BowlingGameFrames; currentFrame++)
            {
                var currentRollsPins = rolls[currentRoll];
                var nextRollsPins = rolls[currentRoll + 1];
                var rollAfterNextPins = rolls[currentRoll + 2];

                var frameIsAStrike = currentRollsPins == MaxPinsPerFrame;
                var frameIsASpare = !frameIsAStrike && (currentRollsPins + nextRollsPins) == MaxPinsPerFrame;

                if (frameIsAStrike)
                {
                    score += CalculateStrikeScore(currentRollsPins, nextRollsPins, rollAfterNextPins);
                }
                else if (frameIsASpare)
                {
                    score += CalculateSpareScore(rollAfterNextPins);
                    currentRoll++;
                }
                else
                {
                    score += currentRollsPins + nextRollsPins;
                    currentRoll++;
                }

                currentRoll++;
            }
        }

        private static int CalculateStrikeScore(int currentRollsPins, int nextRollsPins, int rollAfterNextPins)
        {
            return currentRollsPins + nextRollsPins + rollAfterNextPins;
        }

        private static int CalculateSpareScore(int rollAfterNextsPins)
        {
            return MaxPinsPerFrame + rollAfterNextsPins;
        }
    }
}
