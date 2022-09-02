using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinkoff.Task5
{
    internal class Program
    {
        class Data
        {
            public bool Add;
            public int Time;
            public int Count;
        }

        class Need
        {
            public int Time;
            public int Count;

            public Need(int time, int count)
            {
                Time = time;
                Count = count;
            }
        }
        static void Main(string[] args)
        {
            var dataRead = Console.ReadLine().Split(' ');
            var n = int.Parse(dataRead[0]);
            var m = int.Parse(dataRead[1]);

            Data[] datas = new Data[n];
            for (int i = 0; i < n; i++)
            {
                Data data = new Data();
                dataRead = Console.ReadLine().Split(' ');
                if (dataRead[0]=="-")
                {
                    data.Add = false;
                }
                else
                {
                    data.Add = true;
                }
                data.Time = int.Parse(dataRead[1]);
                data.Count = int.Parse(dataRead[2]);
                datas[i] = data;
            }

            int[] numberSkatesTheStarts = Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToArray();

            for (int i = 0; i < m; i++)
            {
                var wait = 0;
                var count = numberSkatesTheStarts[i];
                var needs = new List<Need>();
                foreach (var data in datas)
                {
                    if (data.Add)
                    {
                        count += data.Count;

                        int temp = data.Count;
                        for (int ind = 0; ind < needs.Count; ind++)
                        {
                            var need = needs[ind];
                            if (need.Count > temp)
                            {
                                need.Count -= temp;
                                wait += temp * (data.Time - need.Time);
                                break;
                            }
                            wait += need.Count * (data.Time - need.Time);
                            needs.RemoveAt(ind);
                            ind--;
                            temp  -= need.Count;
                        }
                        continue;
                    }

                    if (count >= data.Count)
                    {
                        count -= data.Count;
                        continue;
                    }

                    if (count < 0)
                    {
                        count -= data.Count;
                        needs.Add(new Need(data.Time, data.Count));
                        continue;
                    }

                    count -= data.Count;
                    needs.Add(new Need(data.Time, -count));
                       

                }
                if (needs.Count > 0)
                {
                    Console.WriteLine("INFINITY");
                }
                else
                {
                    Console.WriteLine(wait);
                }
                
            }


        }
    }
}
