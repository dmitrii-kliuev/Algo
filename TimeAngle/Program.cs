using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAngle
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
30 градусов проходит часовая стрелка за 1 час
сколько градусов пройдёт часовая стрелка за 15 минут

3:15
10:47
minutesAngle = minutes * (360/60)
hoursAngle = (360/12)*hours + (360/12)/ (60/minutes)

300 + 23.5
30 / 

282 - 323.5
             */
            var res = GetTimeAngle(3, 15);

            var res1 = GetTimeAngle(10, 47);
        }

        private static decimal GetTimeAngle(int hours, int minutes)
        {
            // 360/60 = 6 градусов в 1й минуте или 6 градусов проходит минутная стрелка за минуту
            decimal minutesAngle = minutes * (360m / 60m);

            // 360/12 = 30 градусов проходит часовая стрелка за 1 час
            decimal hoursAngle = (360m / 12m) * hours + (360m / 12m) / (60m / minutes);

            return Math.Abs(hoursAngle - minutesAngle);
        }
    }
}
