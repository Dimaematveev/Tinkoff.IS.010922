using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinkoff.Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataRead = Console.ReadLine().Split(' ');
            var l = int.Parse(dataRead[0]);
            var r = int.Parse(dataRead[1]);
            var w = int.Parse(dataRead[2]);
            int[] a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int[] b = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int maxA = a.Max();
            int maxB = b.Max();

            int minS = int.MaxValue;
            for (int i = maxA; i < l - maxB; i++)
            {
                var s = 0;

                var leng = 0;

                int lengA = i;
                var sA = 1;
                
                for (int j = 0; j < r; j++)
                {
                    if (leng + a[j] > lengA)
                    {
                        sA++;
                        leng = a[j];
                        continue;
                    }
                    leng += a[j];
                }

                leng = 0;
                int lengB = l - i;
                var sB = 1;
                for (int j = 0; j < w; j++)
                {
                    if (leng + b[j] > lengB)
                    {
                        sB++;
                        leng = b[j];
                        continue;
                    }
                    leng += b[j];
                }

                s = Math.Max(sA, sB);

                minS = Math.Min(s, minS);
            }

            Console.WriteLine(minS);
        }
    }
}
