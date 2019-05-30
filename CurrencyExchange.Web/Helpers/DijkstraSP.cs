using CurrencyExchange.Web.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Web.Helpers
{
    public class DijkstraSP : IShortestPath
    {
        public readonly double[] distTo;
        public readonly DirectedEdge[] edgeTo;

        public DijkstraSP(CurrencyExchangeGraph G, int s)
        {
            // All distances inf, except distTo[s] = 0
            distTo = new double[G.V()];
            for (int v = 0; v < G.V(); v++)
            {
                distTo[v] = double.MaxValue;
            }
            distTo[s] = 0;
            edgeTo = new DirectedEdge[G.V()];

            for(int v = 0; v < distTo.Length; v++)
            {                
                foreach (var edge in G.Adj(v))
                {
                    Relax(edge);
                }
            }
        }

        public double DistTo(int v)
        {
            return distTo[v];
        }

        public bool HasNegativeCycle()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DirectedEdge> NegativeCycle()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DirectedEdge> PathTo(int v)
        {
            Stack<DirectedEdge> path = new Stack<DirectedEdge>();
            for(DirectedEdge e = edgeTo[v]; e != null; e = edgeTo[e.From()])
            {
                path.Push(e);
            }
            return path;
        }

        private void Relax(DirectedEdge e)
        {
            int v = e.From(), w = e.To();
            if (distTo[w] > distTo[v] + e.Weight())
            {
                distTo[w] = distTo[v] + e.Weight();
                edgeTo[w] = e;
            }
        }

        //public bool HasPathTo(int v)
        //{
        //    return false;
        //}
    }
}
