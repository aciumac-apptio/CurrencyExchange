using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CurrencyExchange.Web.Helpers
{
    public class MinPQ<T> where T : IComparable<T>
    {
        private T[] pq;
        private int N;

        public MinPQ(int capacity)
        {
            pq = new T[capacity + 1];
        }

        public void Insert(T v)
        {
            if (pq.Length == N + 1)
            {
                Resize(pq.Length * 2);
            }

            pq[++N] = v;
            Swim(N);
        }

        public T DelMin()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("PQ is empty. Cannot delete min.");
            }

            T min = pq[1];
            Exch(1, N--);
            Sink(1);
            pq[N + 1] = default;

            if (pq.Length / 2 > N )
            {
                Resize(pq.Length / 2);
            }

            return min;
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        public int Size()
        {
            return N;
        }

        private void Resize(int newCapacity)
        {
            T[] arr = new T[newCapacity];
            for (int i = 1; i <= N; i++)
            {
                arr[i] = pq[i];
            }

            pq = arr;
        }


        private void Swim(int k)
        {
            // While parent is greater than the child
            while (k > 1 && Greater(k/2, k))
            {
                Exch(k, k / 2);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2*k <= N)
            {
                int j = 2 * k;
                // Take smaller child
                if (j < N && Less(j, j + 1)) j++;
                // if child is not smaller than the parent stop
                if (!Greater(k, j)) break;
                Exch(k, j);
                k = j;
            }
        }

        private bool Less(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) < 0;
        }

        private bool Greater(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) > 0;
        }

        private void Exch(int i, int j)
        {
            T t = pq[i];
            pq[i] = pq[j];
            pq[j] = t;
        }
    }
}
