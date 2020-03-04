using System;

namespace brianmmdev.weeklychallenges.azureapi.utils
{
    public class Helpers
    {
        public int RangedPRNG(int min, int max)
        {
            var rand = new Random();
            return rand.Next(min, max);
        }
    }
}