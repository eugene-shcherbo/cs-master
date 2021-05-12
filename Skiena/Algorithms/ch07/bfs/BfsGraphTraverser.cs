using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch07.bfs
{
    public class BfsGraphTraverser<TVertex> : IGraphTraverser<TVertex> where TVertex : notnull
    {
        internal TraverseTree<TVertex> TraverseWeakComponent(
            IGraph<TVertex> graph,
            TVertex root,
            IGraphTraverseProcessor<TVertex> processor,
            HashSet<TVertex> discovered)
        {
            return TraverseSubGraph(graph, root, processor, discovered);
        }

        public TraverseTree<TVertex> TraverseWeakComponent(IGraph<TVertex> graph, TVertex root, IGraphTraverseProcessor<TVertex>? processor = null)
        {
            return BfsGraphTraverser<TVertex>.TraverseSubGraph(graph, root, processor ?? new DefaultProcessor(), new());
        }

        private static TraverseTree<TVertex> TraverseSubGraph(
            IGraph<TVertex> graph,
            TVertex from,
            IGraphTraverseProcessor<TVertex> processor,
            HashSet<TVertex> discovered)
        {
            var toProcess = new Queue<TVertex>();
            var traverseTree = new TraverseTree<TVertex>(from);

            toProcess.Enqueue(from);
            discovered.Add(from);

            while (toProcess.Any())
            {
                var vertex = toProcess.Dequeue();
                processor.BeforeExploration(from, vertex);

                foreach (Edge<TVertex> edge in graph.GetOutgoingEdges(vertex))
                {
                    processor.ProcessEdge(edge);

                    if (!discovered.Contains(edge.End))
                    {
                        toProcess.Enqueue(edge.End);
                        discovered.Add(edge.End);
                        traverseTree.Add(vertex, edge.End);
                    }
                }

                processor.AfterExploration(from, vertex);
            }

            return traverseTree;
        }

        private class DefaultProcessor : IGraphTraverseProcessor<TVertex>
        {
            public void AfterExploration(TVertex? parent, TVertex vertex)
            {
            }

            public void BeforeExploration(TVertex? parent, TVertex vertex)
            {
            }

            public void ProcessEdge(Edge<TVertex> edge)
            {
            }
        }
    }
}
