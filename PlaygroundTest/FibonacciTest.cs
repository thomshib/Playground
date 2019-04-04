using Microsoft.VisualStudio.TestTools.UnitTesting;
using Playground.Recursion;

namespace PlaygroundTest
{
    [TestClass]
    public class FibonacciTest
    {
        [TestMethod]
        public void FibonacciTestWithRecursion()
        {
            //1,1,2,3,5
            long expectedResult = 5;
            var fib = new Fibonacci();
            var result = fib.FibonacciWithRecursion(5);

            Assert.AreEqual(result, expectedResult);

        }


        [TestMethod]
        public void FibonacciTestWithMemoization()
        {
            //1,1,2,3,5
            long expectedResult = 5;
            var fib = new Fibonacci();
            var result = fib.FibonacciWithMemoization(5);

            Assert.AreEqual(result, expectedResult);

        }


        [TestMethod]
        public void FibonacciTestWithIteration()
        {
            //1,1,2,3,5
            long expectedResult = 5;
            var fib = new Fibonacci();
            var result = fib.FibonacciWithIteration(5);

            Assert.AreEqual(result, expectedResult);

        }
    }
}

