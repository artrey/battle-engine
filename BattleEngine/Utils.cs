using System;

namespace BattleEngine
{
    public static class Utils
    {
        private static readonly Random Rnd = new Random();

        public static int GetRandom(int from, int to) => Rnd.Next(from, to + 1);

        public static uint GetURandom(uint from, uint to) => (uint) GetRandom((int) from, (int) to);
    }
}