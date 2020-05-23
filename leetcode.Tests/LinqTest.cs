using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Algo.Tests
{
    public class LinqTest
    {
        public class Row
        {
            public int Dia { get; set; }
            public int Pale { get; set; }
            public int Speed { get; set; }
            public int Power { get; set; }
            public int Cost { get; set; }
        }

        [Fact]
        public void Test()
        {
            var tbl = new List<Row>
            {
                new Row{ Dia = 8, Pale = 7, Speed = 45, Power = 82 , Cost = 335 },
                new Row{ Dia = 8, Pale = 7, Speed = 68, Power = 85 , Cost = 335 },
                new Row{ Dia = 8, Pale = 7, Speed = 77, Power = 96 , Cost = 335 },
                new Row{ Dia = 8, Pale = 8, Speed = 69, Power = 98 , Cost = 345 },
                new Row{ Dia = 9, Pale = 7, Speed = 55, Power = 95 , Cost = 324 }
            };

            var res = from c in tbl
                      group c by new
                      {
                          DIA = c.Dia,
                          PALE = c.Pale,
                          COST = c.Cost
                      } into grp
                      select new Row
                      {
                          Dia = grp.Key.DIA,
                          Pale = grp.Key.PALE,
                          Speed = grp.Min(x => x.Speed),
                          Power = grp.Min(x => x.Power),
                          Cost = grp.Key.COST
                      };

            foreach (var item in res)
            {
                Debug.WriteLine($"{item.Dia} {item.Pale} {item.Speed} {item.Power} {item.Cost}");
            }
        }
    }
}