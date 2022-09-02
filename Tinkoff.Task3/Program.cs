using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tinkoff.Task3
{
    internal class Program
    {
        static void Main()
        {
            var data = "6 3".Split(' ');
            var n = int.Parse(data[0]);
            var k = int.Parse(data[1]);
            var a = new LinkedList<int>("2 5 4 2 6 2".Split(' ').Select(x=>int.Parse(x)));
            for (var i = 0; i < n; i++)
            {
                //a.AddLast(int.Parse(Console.ReadLine()));
            }

            //Ver1(n, k, a);
            var res = Ver2(n, k, a);
            Console.WriteLine(res);
            Console.ReadLine();
        }

        private static int Ver2(int n, int k, LinkedList<int> a)
        {
            LinkedListNode<int> currElement;

            for (var count = 0; count < k; count++)
            {
                Console.WriteLine(new string('-',50));
                var min = MinElement(n, a);

                Console.WriteLine($"min = {min.min}, ind = {min.minInd}.");

                currElement = a.First;
                for (var i = 0; i < min.minInd; i++)
                {
                    currElement = currElement.Next;
                }
                currElement.Value = 0;
                WriteList(a);
                Console.WriteLine(new string('=', 50));
            }

            var min1 = MinElement(n, a);
            Console.WriteLine($"min = {min1.min}, ind = {min1.minInd}.");
            return min1.min;
        }

        private static (int minInd,int min) MinElement(int n, LinkedList<int> a)
        {
            WriteList(a);
            var currElement = a.First;
            int minInd = 0;
            int min = SumMulty(currElement, n);
            Console.WriteLine($"{0} - {min}");
            

            for (var i = 1; i < n; i++)
            {
                currElement = currElement.NextOrFirst();
                var sum = SumMulty(currElement, n);
                if (sum > 0 && sum < min)
                {
                    min = sum;
                    minInd = i;
                }
                Console.WriteLine($"{i} - {sum}");
            }
            return (minInd, min);
        }

        private static void WriteList(LinkedList<int> a)
        {
            Console.WriteLine(string.Join(" ",a));
            Console.WriteLine();
        }

        private static int SumMulty(LinkedListNode<int> startSummMulty, int count)
        {
            
            if (startSummMulty.Value == 0)
            {
                return -1;
            }

            int sum = 0;
            var currElement = startSummMulty;
           
            int number = 0;
            for (int i = 1; i < count; i++)
            {
                currElement = currElement.NextOrFirst();
                number++;
                if (currElement.Value == 0)
                {
                    number = 0;
                    continue;
                }
                
                sum += number * currElement.Value;
            }
            return sum;
        }

        private static void Ver1(int n, int k, LinkedList<int> a)
        {
            LinkedListNode<int> EmptyEl = null;
            for (var cou = 0; cou < k; cou++)
            {
                var sumMass = new int[n];
                var elementForChech = a.First;

                for (var i = 0; i < n; i++)
                {
                    if (elementForChech.Value == 0)
                    {
                        elementForChech = elementForChech.NextOrFirst();
                        sumMass[i] = 0;
                        continue;
                    }

                    var chekedElement = elementForChech;
                    chekedElement = chekedElement.PreviousOrLast();

                    for (var j = 1; j < n; j++)
                    {
                        if (chekedElement.Value == 0)
                        {
                            break;
                        }

                        sumMass[i] += chekedElement.Value * j;
                        chekedElement = chekedElement.PreviousOrLast();
                    }

                    elementForChech = elementForChech.NextOrFirst();
                }

                int min = int.MaxValue, minInd = 0;

                for (var i = 1; i < n; i++)
                {
                    if (min > sumMass[i] && sumMass[i] > 0)
                    {
                        minInd = i;
                        min = sumMass[i];
                    }
                }

                elementForChech = a.First;
                for (var i = 0; i < minInd; i++)
                {
                    elementForChech = elementForChech.Next;
                }

                elementForChech.Value = 0;

                EmptyEl = elementForChech;
            }

            var sum = 0;
            var count = 0;
            for (var i = 1; i < n; i++)
            {
                EmptyEl = EmptyEl.NextOrFirst();

                if (EmptyEl.Value == 0)
                {
                    count = 0;
                    continue;
                }

                count++;
                sum += EmptyEl.Value * count;
            }

            Console.WriteLine(sum);
        }
    }

    public static class CircularLinkedList
    {
        public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current)
        {
            return current.Next ?? current.List.First;
        }

        public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> current)
        {
            return current.Previous ?? current.List.Last;
        }
    }
}
