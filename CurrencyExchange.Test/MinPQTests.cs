using CurrencyExchange.Web.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CurrencyExchange.Test
{
    [TestClass]
    public class MinPQTests
    {
        [TestMethod]
        public void CreateMinPQ()
        {
            MinPQ<int> pq = new MinPQ<int>(1);

            pq.Insert(3);
            pq.Insert(2);
            pq.Insert(1);

            List<int> list = new List<int>();
            while(!pq.IsEmpty())
            {
                list.Add(pq.DelMin());
            }

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(3, list[2]);
        }


        [TestMethod]
        public void MinPQResizesProperly()
        {
            MinPQ<int> pq = new MinPQ<int>(1);

            Assert.AreEqual(pq.Size(), 0);
            Assert.IsTrue(pq.IsEmpty());

            pq.Insert(2);
            Assert.AreEqual(pq.Size(), 1);

            pq.Insert(2);
            Assert.AreEqual(pq.Size(), 2);

            pq.Insert(2);
            Assert.AreEqual(pq.Size(), 3);

            pq.Insert(2);
            Assert.AreEqual(pq.Size(), 4);
        }

    }
}
