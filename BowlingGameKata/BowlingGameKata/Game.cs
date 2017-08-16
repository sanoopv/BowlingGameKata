﻿namespace BowlingGameKata
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
            var score = 0;
            var frameIndex = 0;
            for (var frames = 0; frames < 10; frames++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfPinsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }
            return score;
        }

        private bool IsStrike(int frameIndex)
        {
            return (rolls[frameIndex] == 10);
        }

        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int SumOfPinsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private bool IsSpare(int frameIndex)
        {
            return (rolls[frameIndex] + rolls[frameIndex + 1] == 10);
        }
    }
}
