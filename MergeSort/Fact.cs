﻿namespace MergeSort
{
    public static class Fact
    {
        public static int Compute(int n)
        {
            if (n == 1)
                return n;

            var nextN = n - 1;
            var nextFact = Compute(nextN);
            int result = nextFact * n;

            return result;
        }
    }
}
