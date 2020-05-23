using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algo.Tests.leetcode
{

    public class Solution
    {
        [Fact]
        public void MyTestMethod()
        {
            var input = "1 1 3 1 2 1 3 3 3 3";
            int[] ar = Array.ConvertAll(input.Split(' '), arTemp => Convert.ToInt32(arTemp));
            SockMerchant(10, ar);
        }

        // Complete the sockMerchant function below.
        private static void SockMerchant(int n, int[] ar)
        {
            var dict = new List<KeyValuePair<int, int>>(); // num, qty
            for (int i = 0; i < n; i++)
            {
                if (!dict.Select(d => d.Key).Contains(ar[i]))
                {
                    var qty = ar.Count(c => c == ar[i]) / 2;
                    dict.Add(new KeyValuePair<int, int>(ar[i], qty));
                }
            }
        }
    }

}


