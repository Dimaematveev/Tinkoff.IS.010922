using System;
namespace Tinkoff.Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');
            var a = int.Parse(data[0]);
            var b = int.Parse(data[1]);
            if (a > b)
            {
                (a, b) = (b, a);

            }

            var x = int.Parse(data[2]);
            var y = int.Parse(data[3]);
           

            var minTime = b - a;

            var minTimeToStationFromA = Math.Min(Math.Abs(a - x), Math.Abs(a - y));
            var minTimeToStationFromB = Math.Min(Math.Abs(b - x), Math.Abs(b - y));
            var minTimeWithExpress = minTimeToStationFromA + minTimeToStationFromB;
            if (minTime > minTimeWithExpress)
            {
                minTime = minTimeWithExpress;
            }
            Console.WriteLine(minTime);
            Console.ReadKey();
        }
    }
}
