using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.ch07.bfs
{
    public class BfsTraverseSession<TVertex> where TVertex : notnull
    {
        readonly BfsGraphTraverser<TVertex> traverser = new();
        readonly HashSet<TVertex> discovered = new();
        readonly IGraph<TVertex> graph;

        Action<TVertex> beforeTraverse = vertex => { };
        Action<TVertex> afterTraverse = vertex => { };

        internal BfsTraverseSession(IGraph<TVertex> graph)
        {
            this.graph = graph;
        }

        public BfsTraverseSession<TVertex> BeforeTraversingComponent(Action<TVertex>? action)
        {
            beforeTraverse = action ?? beforeTraverse;
            return this;
        }

        public BfsTraverseSession<TVertex> AfterTraversingComponent(Action<TVertex>? action)
        {
            afterTraverse = action ?? afterTraverse;
            return this;
        }

        //public BfsTraverseSession<TVertex> BeforeExploringVertex(Action<TVertex>? action)
        //{
        //    return this;
        //}

        //public BfsTraverseSession<TVertex> WhenExploringEdge(Action<Edge<TVertex>> action)
        //{
        //    return this;
        //}

        //public BfsTraverseSession<TVertex> AfterExploringVertex(Action<TVertex> action)
        //{
        //    return this;
        //}

        public BfsTraverseSession<TVertex> TraverseComponents()
        {
            foreach (TVertex vertex in graph.Vertices)
            {
                if (!Discovered(vertex))
                {
                    beforeTraverse(vertex);
                    traverser.TraverseFrom(graph, vertex);
                    afterTraverse(vertex);
                }
            }

            return this;
        }

        public bool Discovered(TVertex vertex) => discovered.Contains(vertex);

        private class BfsProcessor : IGraphTraverseProcessor<TVertex>
        {
            // readonly TraverseTree<TVertex> tree;
            readonly Dictionary<TVertex, int> entryTime = new();
            readonly Dictionary<TVertex, int> finishTime = new();
            int time = -1;

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

    public class BfsTraverseSession
    {
        private BfsTraverseSession() { }

        public static BfsTraverseSession<TVertex> For<TVertex>(IGraph<TVertex> graph) where TVertex : notnull
        {
            return new BfsTraverseSession<TVertex>(graph);
        }
    }
}