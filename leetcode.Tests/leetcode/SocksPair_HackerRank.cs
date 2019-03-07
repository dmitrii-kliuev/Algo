using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using Xunit;


namespace leetcode
{
    
    public class Solution
    {
        [Fact]
        public void MyTestMethod()
        {
            var input = "1 1 3 1 2 1 3 3 3 3";
            int[] ar = Array.ConvertAll(input.Split(' '), arTemp => Convert.ToInt32(arTemp));
            int result = SockMerchant(10, ar);
        }

        // Complete the sockMerchant function below.
        static int SockMerchant(int n, int[] ar)
        {
            var res = 0;
            var dict = new List<KeyValuePair<int, int>>(); // num, qty
            for (int i = 0; i < n; i++)
            {
                if (!dict.Select(d => d.Key).Contains(ar[i]))
                {
                    var qty = ar.Count(c => c == ar[i]) / 2;
                    dict.Add(new KeyValuePair<int, int>(ar[i], qty));
                }
            }

            res = dict.Sum(d => d.Value);

            return res;
        }
    }

}


