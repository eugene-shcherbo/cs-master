using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch07.bfs
{
    public class BfsGraphTraverser<TVertex> : IGraphTraverser<TVertex> where TVertex : notnull
    {
        //public void Traverse(IGraph<TVertex> graph, IGraphTraverseProcessor<TVertex>? processor = null)
        //{
        //    var discovered = new HashSet<TVertex>();
        //    processor ??= new DefaultProcessor();

        //    foreach (TVertex vertex in graph.Vertices)
        //    {
        //        if (!discovered.Contains(vertex))
        //        {
        //            processor.BeforeTraversingWeakComponent(vertex);
        //            TraverseSubGraph(graph, vertex, processor, discovered);
        //        }
        //    }
        //}

        //public void Traverse(IGraph<TVertex> graph, IGraphTraverseProcessor<TVertex, BfsContext> processor)
        //{
        //    var discovered = new HashSet<TVertex>();

        //    foreach (TVertex vertex in graph.Vertices)
        //    {
        //        if (!discovered.Contains(vertex))
        //        {
        //            processor.BeforeTraversingWeakComponent(vertex);
        //            TraverseSubGraph(graph, vertex, processor, discovered);
        //        }
        //    }
        //}

        //public TraverseTree<TVertex> TraverseWeakComponent(IGraph<TVertex> graph, TVertex root, IGraphTraverseProcessor<TVertex> processor)
        //{
        //    var discovered = new HashSet<TVertex>();
        //    processor.BeforeTraversingWeakComponent(root);

        //    return TraverseSubGraph(graph, root, processor, discovered);
        //}

        //public TraverseTree<TVertex> TraverseWeakComponent(IGraph<TVertex> graph, TVertex root, IGraphTraverseProcessor<TVertex, BfsContext> processor)
        //{
        //    var discovered = new HashSet<TVertex>();
        //    processor.BeforeTraversingWeakComponent(root);

        //    return TraverseSubGraph(graph, root, processor, discovered);
        //}

        //private TraverseTree<TVertex> TraverseSubGraph(
        //    IGraph<TVertex> graph,
        //    TVertex from,
        //    IGraphTraverseProcessor<TVertex, BfsContext> processor,
        //    HashSet<TVertex> discovered)
        //{
        //    var context = new BfsContext();
        //    var toProcess = new Queue<TVertex>();
        //    var traverseTree = new TraverseTree<TVertex>(from);

        //    toProcess.Enqueue(from);
        //    discovered.Add(from);

        //    while (toProcess.Any())
        //    {
        //        var vertex = toProcess.Dequeue();
        //        processor.BeforeExploration(vertex, context);

        //        foreach (Edge<TVertex> edge in graph.GetOutgoingEdges(vertex))
        //        {
        //            processor.ProcessEdge(edge, context);

        //            if (!discovered.Contains(edge.End))
        //            {
        //                toProcess.Enqueue(edge.End);
        //                discovered.Add(edge.End);
        //                traverseTree.Add(vertex, edge.End);
        //            }
        //        }

        //        processor.AfterExploration(vertex, context);
        //    }

        //    return traverseTree;
        //}

        public TraverseTree<TVertex> TraverseFrom(IGraph<TVertex> graph, TVertex from, IGraphTraverseProcessor<TVertex>? processor = null)
        {
            var discovered = new HashSet<TVertex>();
            processor ??= new DefaultProcessor();

            return TraverseSubGraph(graph, from, processor, discovered);
        }

        private TraverseTree<TVertex> TraverseSubGraph(
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
                processor.BeforeExploration(vertex);

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

                processor.AfterExploration(vertex);
            }

            return traverseTree;
        }

        public class BfsContext
        {

        }

        private class DefaultProcessor : IGraphTraverseProcessor<TVertex>
        {
            public void ProcessEdge(Edge<TVertex> edge)
            {
            }

            public void ProcessVertexAfterExploration(TVertex vertex)
            {
            }

            public void ProcessVertexBeforeExploration(TVertex vertex)
            {
            }
        }
    }
}
