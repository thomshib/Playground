using Microsoft.VisualStudio.TestTools.UnitTesting;
using Playground.Knapsack;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaygroundTest
{
    [TestClass]
    public class KnapSackTest
    {

        int itemCount;
        int maxCapacity;
        int[] values;
        int[] weights;
        [TestInitialize]
        public void TestInitialize()
        {
             itemCount = 3;
             maxCapacity = 50;
            values = new int[] { 60, 100, 120 };
            weights = new int[] { 10, 20, 30 };


        }


        [TestMethod]
        public void KnapsackTest()
        {
            int result = 220;

            var testClient = new Knapsack();
            var expectedResult = testClient.KnapsackSolution(maxCapacity, weights, values, itemCount);

            Assert.AreEqual(result, expectedResult);

        }
    }
}
