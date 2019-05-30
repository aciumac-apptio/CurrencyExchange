using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Web.Helpers
{
    public interface IGraph
    {
        void AddEdge(DirectedEdge e);
        IEnumerable<DirectedEdge> Adj(int v);
        int V();
        IEnumerable<DirectedEdge> E();
        string ToString();
    }

    public class CurrencyExchangeGraph : IGraph
    {
        private readonly int v;
        private readonly HashSet<DirectedEdge>[] adj;

        public CurrencyExchangeGraph(int V)
        {
            v = V;
            adj = new HashSet<DirectedEdge>[V];
            for (int v = 0; v < V; v++)
            {
                adj[v] = new HashSet<DirectedEdge>();
            }
        }

        public void AddEdge(DirectedEdge e)
        {
            int v = e.From();
            adj[v].Add(e);
        }

        public IEnumerable<DirectedEdge> E()
        {
            List<DirectedEdge> edges = new List<DirectedEdge>();
            foreach (var item in adj)
            {
                edges.AddRange(item);
            }
            return edges;
        }

        public int V()
        {
            return v;
        }

        public IEnumerable<DirectedEdge> Adj(int v)
        {
            return adj[v];
        }
    }
}
