using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Web.Helpers
{
    public class DirectedEdge
    {
        public readonly int v, w;
        public readonly double weight;

        public DirectedEdge(int v, int w, double weight)
        {
            this.v = v;
            this.w = w;
            this.weight = weight;
        }

        public int From()
        {
            return v;
        }

        public int To()
        {
            return w;
        }

        public double Weight()
        {
            return weight;
        }
    }
}
