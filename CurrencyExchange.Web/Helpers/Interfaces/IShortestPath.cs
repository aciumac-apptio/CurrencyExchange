using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Web.Helpers.Interfaces
{
    public interface IShortestPath
    {
        double DistTo(int v);
        IEnumerable<DirectedEdge> PathTo(int v);
        bool HasNegativeCycle();
        IEnumerable<DirectedEdge> NegativeCycle();

    }
}
