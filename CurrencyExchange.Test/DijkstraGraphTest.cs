using CurrencyExchange.Web.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyExchange.Test
{
    [TestClass]
    public class DijkstraGraphTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CurrencyExchangeGraph graph = BuildGraph();


            Assert.IsNotNull(graph);
            Assert.AreEqual(8, graph.V());
            Assert.AreEqual(16, graph.E().Count());

            DijkstraSP dijkstraSP = new DijkstraSP(graph, 0);
            IEnumerable<DirectedEdge> path = dijkstraSP.PathTo(5);
            List<int> list = new List<int>();
            list.Add(0);
            foreach (var edge in path)
            {
                list.Add(edge.To());
            }

            Assert.AreEqual(0, list[0]);
            Assert.AreEqual(4, list[1]);
            Assert.AreEqual(5, list[2]);

        }


        private CurrencyExchangeGraph BuildGraph()
        {
            CurrencyExchangeGraph graph = new CurrencyExchangeGraph(8);
            graph.AddEdge(new DirectedEdge(0, 1, 5.0));
            graph.AddEdge(new DirectedEdge(0, 4, 9.0));
            graph.AddEdge(new DirectedEdge(0, 7, 8.0));
            graph.AddEdge(new DirectedEdge(1, 2, 12.0));
            graph.AddEdge(new DirectedEdge(1, 3, 15.0));
            graph.AddEdge(new DirectedEdge(1, 7, 4.0));
            graph.AddEdge(new DirectedEdge(2, 3, 3.0));
            graph.AddEdge(new DirectedEdge(2, 6, 11.0));
            graph.AddEdge(new DirectedEdge(3, 6, 9.0));
            graph.AddEdge(new DirectedEdge(4, 5, 4.0));
            graph.AddEdge(new DirectedEdge(4, 6, 20.0));
            graph.AddEdge(new DirectedEdge(4, 7, 5.0));
            graph.AddEdge(new DirectedEdge(5, 2, 1.0));
            graph.AddEdge(new DirectedEdge(5, 6, 13.0));
            graph.AddEdge(new DirectedEdge(7, 5, 6.0));
            graph.AddEdge(new DirectedEdge(7, 2, 7.0));



            return graph;
        }
    }
}
