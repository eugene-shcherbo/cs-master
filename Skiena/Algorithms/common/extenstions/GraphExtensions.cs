using Algorithms.ch07;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.common.extenstions
{
    public static class GraphExtensions
    {
        public static void ConnectUndirected<TVertex>(this IGraph<TVertex> graph, TVertex from, TVertex to) where TVertex : notnull
        {
            graph.Connect(from, to);
            graph.Connect(to, from);
        }
    }
}
