using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch07
{
    public class Edge<TVertex>
    {
        public TVertex Start { get; }

        public TVertex End { get; }

        public Edge(TVertex start, TVertex end)
        {
            Start = start;
            End = end;
        }
    }
}
