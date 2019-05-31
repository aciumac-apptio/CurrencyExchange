using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Web.Helpers.Interfaces
{
    public interface IGraph
    {
        void AddEdge(DirectedEdge e);
        IEnumerable<DirectedEdge> Adj(int v);
        int V();
        IEnumerable<DirectedEdge> E();
        string ToString();
    }
}
