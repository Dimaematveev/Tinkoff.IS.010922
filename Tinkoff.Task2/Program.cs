using System;

namespace Tinkoff.Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ');
            var W = int.Parse(data[0]);
            var H = int.Parse(data[1]);


            data = Console.ReadLine().Split(' ');
            var w = int.Parse(data[0]);
            var h = int.Parse(data[1]);


            Console.WriteLine(MinNumberFolds(W, H, w, h));

        }

        private static int MinNumberFolds(int W, int H, int w, int h)
        {
            //W - Max
            if (H > W)
            {
                (W, H) = (H, W);
            }

            if (h > w)
            {
                (w, h) = (h, w);
            }

            if (w > W || h > H)
            {
                return -1;
            }

            var res = NumberFold(W, w) + NumberFold(H, h);

            return res;
        }

        private static int NumberFold(int N, int n)
        {
            if (N == n) 
            {
                return 0;
            }
            var max = Math.Ceiling((double)N / n);
            var res = Math.Ceiling(Math.Log(max,2));

            return (int)res;
        }
    }
}
