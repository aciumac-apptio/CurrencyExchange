using CurrencyExchange.Web.Helpers.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Remotion.Linq.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Web.Helpers
{
    public class BellmanFordSP : IShortestPath
    {
        private readonly double[] distTo;
        private readonly DirectedEdge[] edgeTo;
        private readonly CurrencyExchangeGraph G;

        public BellmanFordSP(CurrencyExchangeGraph G, int s)
        {
            // All distances inf, except distTo[s] = 0
            this.G = G;
            edgeTo = new DirectedEdge[G.V()];
            distTo = new double[G.V()];            

            for (int v = 0; v < G.V(); v++)
            {
                distTo[v] = double.MaxValue;
            }
            distTo[s] = 0;

            for (int i = 0; i < G.V(); i++)
            {
                for (int v = 0; v < G.V(); v++)
                {
                    foreach (var edge in G.Adj(v))
                    {
                        Relax(edge);
                    }
                }
            }

            

            //bool oneEdgeRelaxed;
            //do
            //{
            //    oneEdgeRelaxed = false;
            //    for (int v = 0; v < G.V(); v++)
            //    {
            //        foreach (var edge in G.Adj(v))
            //        {                        
            //            if (Relax(edge))
            //            {
            //                oneEdgeRelaxed = true;
            //            }
            //        }
            //    }
            //} while (oneEdgeRelaxed);
        }

        public double DistTo(int v)
        {
            return distTo[v];
        }

        public bool HasNegativeCycle()
        {
            for (int v = 0; v < G.V(); v++)
            {
                foreach (var edge in G.Adj(v))
                {
                    int w = edge.To();
                    if (distTo[w] != double.MaxValue && distTo[v] + edge.Weight() < distTo[w])
                    {
                        return true;
                    }
                }              
                
            }
            return false;
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

        //private bool Relax(DirectedEdge e)
        //{
        //    int v = e.From(), w = e.To();
        //    if (distTo[w] > distTo[v] + e.Weight())
        //    {
        //        distTo[w] = distTo[v] + e.Weight();
        //        edgeTo[w] = e;
        //        return true;
        //    }
        //    return false;
        //}

        //public bool HasPathTo(int v)
        //{
        //    return false;
        //}
    }
}
