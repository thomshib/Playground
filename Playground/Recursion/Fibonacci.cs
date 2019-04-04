using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.Recursion
{
    public class Fibonacci
    {

        public long FibonacciWithRecursion(int n)
        {

            if (n < 2)
            {
                return n;
            }

            return FibonacciWithRecursion(n - 1) + FibonacciWithRecursion(n - 2);

        }

        public long FibonacciWithMemoization(int n)
        {
            Dictionary<int, long> map = new Dictionary<int, long>();
            map[0] = 0;
            map[1] = 1;

            return FibWithMemoization(n, map);
        }

 
        public long FibonacciWithIteration(int n)
        {
            long previous = 0;
            long current = 1;
            long temp;
            for (int i = 2; i < n + 1; i++)
            {
                temp = previous;
                previous = current;

                current = temp + current;

            }

            return current;
        }


        private long FibWithMemoization(int n, Dictionary<int, long> map)
        {
            if (map.ContainsKey(n))
            {
                return map[n];
            }
            map[n] = FibWithMemoization(n - 1, map) + FibWithMemoization(n - 2, map);
            return map[n];
        }
    }
}
