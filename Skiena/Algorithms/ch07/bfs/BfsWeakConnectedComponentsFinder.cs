using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch07.bfs
{
    public class BfsWeakConnectedComponentsFinder : IWeakConnectedComponentsFinder
    {
        public IEnumerable<ISet<TVertex>> Find<TVertex>(IGraph<TVertex> graph) where TVertex : notnull
        {
            var components = new List<HashSet<TVertex>>();

            var bfs = BfsTraverseSession
                .For(graph)
                .BeforeTraversingComponent((vertex, session) => components.Add(new()))
                .BeforeExploration((vertex, session) => components[^1].Add(vertex));

            bfs.Run();

            return components;
        }
    }
}
