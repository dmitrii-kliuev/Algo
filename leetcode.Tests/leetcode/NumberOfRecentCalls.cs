﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class NumberOfRecentCalls
    {
        /*
         933. Number of Recent Calls

Write a class RecentCounter to count recent requests.

It has only one method: ping(int t), where t represents some time in milliseconds.

Return the number of pings that have been made from 3000 milliseconds ago until now.

Any ping with time in [t - 3000, t] will count, including the current ping.

It is guaranteed that every call to ping uses a strictly larger value of t than before.

 

Example 1:

Input: inputs = ["RecentCounter","ping","ping","ping","ping"], inputs = [[],[1],[100],[3001],[3002]]
Output: [null,1,2,3,3]
 

Note:

Each test case will have at most 10000 calls to ping.
Each test case will call ping with strictly increasing values of t.
Each call to ping will have 1 <= t <= 10^9.


            Solution
Approach 1: Queue
Intuition

We only care about the most recent calls in the last 3000 ms, so let's use a data structure that keeps only those.

Algorithm

Keep a queue of the most recent calls in increasing order of t. When we see a new call with time t, remove all calls that occurred before t - 3000.
             */

        [Fact]
        public void Test()
        {
            var rc = new RecentCounter();

            var lst = new List<int>();

            lst.Add(rc.Ping(1));
            lst.Add(rc.Ping(100));
            lst.Add(rc.Ping(3001));
            lst.Add(rc.Ping(3002));


            /*
             ["RecentCounter","ping","ping","ping","ping","ping"]
            [[],[642],[1849],[4921],[5936],[5957]]
                   Output   [null,1,2,2,2,3]
                   Expected [null,1,2,1,2,3]
        */

            rc = new RecentCounter();

            lst = new List<int>();

            lst.Add(rc.Ping(642));
            lst.Add(rc.Ping(1849));
            lst.Add(rc.Ping(4921));
            lst.Add(rc.Ping(5936));
            lst.Add(rc.Ping(5957));
        }

        class RecentCounter
        {
            Queue<int> q = new Queue<int>();
            public RecentCounter()
            {

            }

            public int Ping(int t)
            {
                q.Enqueue(t);

                while(q.Peek() < t - 3000)
                    q.Dequeue();


                return q.Count;
            }
        }

        /**
         * Your RecentCounter object will be instantiated and called as such:
         * RecentCounter obj = new RecentCounter();
         * int param_1 = obj.ping(t);
         */
    }
}