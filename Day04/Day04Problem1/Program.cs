﻿namespace Day04Problem1
{
    internal class Program
    {
        private static long GetCardScore(string cardLine)
        {
            string justNumbers = cardLine.Split(':')[1];
            string[] twoHalves = justNumbers.Split('|');
            string allWinnerString = twoHalves[0];
            var winners = new HashSet<int>();
            foreach (string winnerString in allWinnerString.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                winners.Add(int.Parse(winnerString));
            }

            string allCardNumberString = twoHalves[1];
            var cardNumbers = new List<int>();
            foreach (string cardNumberString in allCardNumberString.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                cardNumbers.Add(int.Parse(cardNumberString));
            }

            long score = 0;
            foreach (int number in cardNumbers)
            {
                if (winners.Contains(number))
                {
                    if (score == 0) score = 1;
                    else score = score * 2;
                }
            }

            return score;
        }

        static async Task Main(string[] args)
        {
            var inputLines = await File.ReadAllLinesAsync(args[0]);
            long cardScoreSum = 0;
            foreach (string cardLine in inputLines)
            {
                cardScoreSum += GetCardScore(cardLine);
            }

            Console.Out.WriteLine(cardScoreSum);
        }
    }
}