using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class LinqTest
    {
        public class Row
        {
            public int DIA { get; set; }
            public int PALE { get; set; }
            public int SPEED { get; set; }
            public int POWER { get; set; }
            public int COST { get; set; }
        }

        [Fact]
        public void Test()
        {
            var tbl = new List<Row>() {
                new Row{ DIA = 8, PALE = 7, SPEED = 45, POWER = 82 , COST = 335 },
                new Row{ DIA = 8, PALE = 7, SPEED = 68, POWER = 85 , COST = 335 },
                new Row{ DIA = 8, PALE = 7, SPEED = 77, POWER = 96 , COST = 335 },
                new Row{ DIA = 8, PALE = 8, SPEED = 69, POWER = 98 , COST = 345 },
                new Row{ DIA = 9, PALE = 7, SPEED = 55, POWER = 95 , COST = 324 }
            };

            var res = from c in tbl
                      group c by new
                      {
                          c.DIA,
                          c.PALE,
                          c.COST
                      } into grp
                      select new Row
                      {
                          DIA = grp.Key.DIA,
                          PALE = grp.Key.PALE,
                          SPEED = grp.Min(x => x.SPEED),
                          POWER = grp.Min(x => x.POWER),
                          COST = grp.Key.COST
                      };

            foreach (var item in res)
            {
                Debug.WriteLine($"{item.DIA} {item.PALE} {item.SPEED} {item.POWER} {item.COST}");
            }
        }
    }
}